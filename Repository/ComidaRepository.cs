using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class ComidaRepository : IComidaRepository
    {
        private readonly string _connectionString;

        public ComidaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Comida>> GetAllAsync()
        {
            var comidas = new List<Comida>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdTipoAlimento, Nombre FROM comida";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        comidas.Add(new Comida
                        {
                            Id = reader.GetInt32(0),
                            FkIdTipoAlimento = reader.GetInt32(1),
                            Nombre = reader.GetString(2)
                        });
                    }
                }
            }
            return comidas;
        }

        public async Task<Comida?> GetByIdAsync(int id)
        {
            Comida? comida = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdTipoAlimento, Nombre FROM comida WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            comida = new Comida
                            {
                                Id = reader.GetInt32(0),
                                FkIdTipoAlimento = reader.GetInt32(1),
                                Nombre = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return comida;
        }

        public async Task AddAsync(Comida comida)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO comida (FkIdTipoAlimento, Nombre) VALUES (@FkIdTipoAlimento, @Nombre)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FkIdTipoAlimento", comida.FkIdTipoAlimento);
                    command.Parameters.AddWithValue("@Nombre", comida.Nombre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Comida comida)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE comida SET FkIdTipoAlimento = @FkIdTipoAlimento, Nombre = @Nombre WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", comida.Id);
                    command.Parameters.AddWithValue("@FkIdTipoAlimento", comida.FkIdTipoAlimento);
                    command.Parameters.AddWithValue("@Nombre", comida.Nombre);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM comida WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
