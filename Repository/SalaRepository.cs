using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly string _connectionString;

        public SalaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Sala>> GetAllAsync()
        {
            var salas = new List<Sala>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Capacidad, Nombre FROM sala";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        salas.Add(new Sala
                        {
                            Id = reader.GetInt32(0),
                            Capacidad = reader.GetInt32(1),
                            Nombre = reader.GetString(2)
                        });
                    }
                }
            }
            return salas;
        }

        public async Task<Sala?> GetByIdAsync(int id)
        {
            Sala? sala = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Capacidad, Nombre FROM sala WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            sala = new Sala
                            {
                                Id = reader.GetInt32(0),
                                Capacidad = reader.GetInt32(1),
                                Nombre = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return sala;
        }

        public async Task AddAsync(Sala sala)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO sala (Capacidad, Nombre) VALUES (@Capacidad, @Nombre)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Capacidad", sala.Capacidad);
                    command.Parameters.AddWithValue("@Nombre", sala.Nombre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Sala sala)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE sala SET Capacidad = @Capacidad, Nombre = @Nombre WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", sala.Id);
                    command.Parameters.AddWithValue("@Capacidad", sala.Capacidad);
                    command.Parameters.AddWithValue("@Nombre", sala.Nombre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM sala WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
