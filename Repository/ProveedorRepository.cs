using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly string _connectionString;

        public ProveedorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            var proveedores = new List<Proveedor>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Provincia, Direccion, NIF FROM proveedor";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        proveedores.Add(new Proveedor
                        {
                            Id = reader.GetInt32(0),
                            Provincia = reader.GetString(1),
                            Direccion = reader.GetString(2),
                            NIF = reader.GetString(3)
                        });
                    }
                }
            }
            return proveedores;
        }

        public async Task<Proveedor?> GetByIdAsync(int id)
        {
            Proveedor? proveedor = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Provincia, Direccion, NIF FROM proveedor WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            proveedor = new Proveedor
                            {
                                Id = reader.GetInt32(0),
                                Provincia = reader.GetString(1),
                                Direccion = reader.GetString(2),
                                NIF = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return proveedor;
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO proveedor (Provincia, Direccion, NIF) VALUES (@Provincia, @Direccion, @NIF)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Provincia", proveedor.Provincia);
                    command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    command.Parameters.AddWithValue("@NIF", proveedor.NIF);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Proveedor proveedor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE proveedor SET Provincia = @Provincia, Direccion = @Direccion, NIF = @NIF WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", proveedor.Id);
                    command.Parameters.AddWithValue("@Provincia", proveedor.Provincia);
                    command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    command.Parameters.AddWithValue("@NIF", proveedor.NIF);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM proveedor WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
