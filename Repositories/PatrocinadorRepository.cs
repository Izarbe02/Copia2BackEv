using Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Repositories
{
    public class PatrocinadorRepository : IPatrocinadorRepository
    {
        private readonly string _connectionString;

        public PatrocinadorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Patrocinador>> GetAllAsync()
        {
            var patrocinadores = new List<Patrocinador>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, descripcion, logo, contacto, idOrganizador FROM Patrocinadores";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patrocinador = new Patrocinador
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Logo = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Contacto = reader.IsDBNull(4) ? null : reader.GetString(4),
                                IdOrganizador = reader.GetInt32(5)
                            };
                            patrocinadores.Add(patrocinador);
                        }
                    }
                }
            }
            return patrocinadores;
        }

        public async Task<Patrocinador?> GetByIdAsync(int id)
        {
            Patrocinador? patrocinador = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ID, nombre, descripcion, logo, contacto, idOrganizador FROM Patrocinadores WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            patrocinador = new Patrocinador
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Logo = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Contacto = reader.IsDBNull(4) ? null : reader.GetString(4),
                                IdOrganizador = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }
            return patrocinador;
        }

        public async Task AddAsync(Patrocinador patrocinador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO Patrocinadores (nombre, descripcion, logo, contacto, idOrganizador) VALUES (@Nombre, @Descripcion, @Logo, @Contacto, @IdOrganizador)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", patrocinador.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", (object?)patrocinador.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Logo", (object?)patrocinador.Logo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Contacto", (object?)patrocinador.Contacto ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IdOrganizador", patrocinador.IdOrganizador);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Patrocinador patrocinador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE Patrocinadores SET nombre = @Nombre, descripcion = @Descripcion, logo = @Logo, contacto = @Contacto, idOrganizador = @IdOrganizador WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", patrocinador.Id);
                    command.Parameters.AddWithValue("@Nombre", patrocinador.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", (object?)patrocinador.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Logo", (object?)patrocinador.Logo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Contacto", (object?)patrocinador.Contacto ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IdOrganizador", patrocinador.IdOrganizador);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Patrocinadores WHERE ID = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
