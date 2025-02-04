using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class AsientoSesionRepository : IAsientoSesionRepository
    {
        private readonly string _connectionString;

        public AsientoSesionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<AsientoSesion>> GetAllAsync()
        {
            var asientosSesion = new List<AsientoSesion>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdSesion, FkIdAsiento, FkIdUsuario, FechaReserva, Ocupado FROM asientos_sesion";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        asientosSesion.Add(new AsientoSesion
                        {
                            Id = reader.GetInt32(0),
                            FkIdSesion = reader.GetInt32(1),
                            FkIdAsiento = reader.GetInt32(2),
                            FkIdUsuario = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                            FechaReserva = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            Ocupado = reader.GetBoolean(5)
                        });
                    }
                }
            }
            return asientosSesion;
        }

        public async Task<List<AsientoSesion>> GetBySesionAsync(int sesionId)
        {
            var asientosSesion = new List<AsientoSesion>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdSesion, FkIdAsiento, FkIdUsuario, FechaReserva, Ocupado FROM asientos_sesion WHERE FkIdSesion = @SesionId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SesionId", sesionId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            asientosSesion.Add(new AsientoSesion
                            {
                                Id = reader.GetInt32(0),
                                FkIdSesion = reader.GetInt32(1),
                                FkIdAsiento = reader.GetInt32(2),
                                FkIdUsuario = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                                FechaReserva = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                Ocupado = reader.GetBoolean(5)
                            });
                        }
                    }
                }
            }
            return asientosSesion;
        }

        public async Task AddAsync(AsientoSesion asientoSesion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO asientos_sesion (FkIdSesion, FkIdAsiento, FkIdUsuario, FechaReserva, Ocupado) VALUES (@FkIdSesion, @FkIdAsiento, @FkIdUsuario, @FechaReserva, @Ocupado)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FkIdSesion", asientoSesion.FkIdSesion);
                    command.Parameters.AddWithValue("@FkIdAsiento", asientoSesion.FkIdAsiento);
                    command.Parameters.AddWithValue("@FkIdUsuario", asientoSesion.FkIdUsuario.HasValue ? (object)asientoSesion.FkIdUsuario.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@FechaReserva", asientoSesion.FechaReserva.HasValue ? (object)asientoSesion.FechaReserva.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@Ocupado", asientoSesion.Ocupado);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
