using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly string _connectionString;

        public CompraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Compra>> GetAllAsync()
        {
            var compras = new List<Compra>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdUsuario FROM compra";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        compras.Add(new Compra
                        {
                            Id = reader.GetInt32(0),
                            FkIdUsuario = reader.GetInt32(1)
                        });
                    }
                }
            }
            return compras;
        }

        public async Task<Compra?> GetByIdAsync(int id)
        {
            Compra? compra = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdUsuario FROM compra WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            compra = new Compra
                            {
                                Id = reader.GetInt32(0),
                                FkIdUsuario = reader.GetInt32(1)
                            };
                        }
                    }
                }
            }
            return compra;
        }

        public async Task AddAsync(Compra compra)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO compra (FkIdUsuario) VALUES (@FkIdUsuario)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FkIdUsuario", compra.FkIdUsuario);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Compra compra)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE compra SET FkIdUsuario = @FkIdUsuario WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", compra.Id);
                    command.Parameters.AddWithValue("@FkIdUsuario", compra.FkIdUsuario);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM compra WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
