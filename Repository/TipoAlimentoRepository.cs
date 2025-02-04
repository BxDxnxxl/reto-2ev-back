using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class TipoAlimentoRepository : ITipoAlimentoRepository
    {
        private readonly string _connectionString;

        public TipoAlimentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<TipoAlimento>> GetAllAsync()
        {
            var tiposAlimentos = new List<TipoAlimento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Tipo FROM tipoalimento";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        tiposAlimentos.Add(new TipoAlimento
                        {
                            Id = reader.GetInt32(0),
                            Tipo = reader.GetString(1)
                        });
                    }
                }
            }
            return tiposAlimentos;
        }

        public async Task<TipoAlimento?> GetByIdAsync(int id)
        {
            TipoAlimento? tipoAlimento = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Tipo FROM tipoalimento WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            tipoAlimento = new TipoAlimento
                            {
                                Id = reader.GetInt32(0),
                                Tipo = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return tipoAlimento;
        }

        public async Task AddAsync(TipoAlimento tipoAlimento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO tipoalimento (Tipo) VALUES (@Tipo)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tipo", tipoAlimento.Tipo);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(TipoAlimento tipoAlimento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE tipoalimento SET Tipo = @Tipo WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", tipoAlimento.Id);
                    command.Parameters.AddWithValue("@Tipo", tipoAlimento.Tipo);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM tipoalimento WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
