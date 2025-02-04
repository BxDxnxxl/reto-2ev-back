using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly string _connectionString;

        public AsientoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Asiento>> GetAllAsync()
        {
            var asientos = new List<Asiento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdSala, Fila, Numero FROM asientos";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        asientos.Add(new Asiento
                        {
                            Id = reader.GetInt32(0),
                            FkIdSala = reader.GetInt32(1),
                            Fila = reader.GetInt32(2),
                            Numero = reader.GetInt32(3)
                        });
                    }
                }
            }
            return asientos;
        }
        
        public async Task<Asiento?> GetByIdAsync(int id)
        {
            Asiento? asiento = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdSala, Fila, Numero FROM asientos WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            asiento = new Asiento
                            {
                                Id = reader.GetInt32(0),
                                FkIdSala = reader.GetInt32(1),
                                Fila = reader.GetInt32(2),
                                Numero = reader.GetInt32(3)
                            };
                        }
                    }
                }
            }
            return asiento;
        }

        public async Task AddAsync(Asiento asiento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO asientos (FkIdSala, Fila, Numero) VALUES (@FkIdSala, @Fila, @Numero)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FkIdSala", asiento.FkIdSala);
                    command.Parameters.AddWithValue("@Fila", asiento.Fila);
                    command.Parameters.AddWithValue("@Numero", asiento.Numero);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM asientos WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
