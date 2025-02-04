using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class SesionRepository : ISesionRepository
    {
        private readonly string _connectionString;

        public SesionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Sesion>> GetAllAsync()
        {
            var sesiones = new List<Sesion>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdPelicula, FkIdSala, FechaInicio, FechaFin FROM sesion";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        sesiones.Add(new Sesion
                        {
                            Id = reader.GetInt32(0),
                            FkIdPelicula = reader.GetInt32(1),
                            FkIdSala = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaFin = reader.GetDateTime(4)
                        });
                    }
                }
            }
            return sesiones;
        }

        public async Task<Sesion?> GetByIdAsync(int id)
        {
            Sesion? sesion = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdPelicula, FkIdSala, FechaInicio, FechaFin FROM sesion WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            sesion = new Sesion
                            {
                                Id = reader.GetInt32(0),
                                FkIdPelicula = reader.GetInt32(1),
                                FkIdSala = reader.GetInt32(2),
                                FechaInicio = reader.GetDateTime(3),
                                FechaFin = reader.GetDateTime(4)
                            };
                        }
                    }
                }
            }
            return sesion;
        }

        public async Task AddAsync(Sesion sesion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO sesion (FkIdPelicula, FkIdSala, FechaInicio, FechaFin) VALUES (@FkIdPelicula, @FkIdSala, @FechaInicio, @FechaFin)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FkIdPelicula", sesion.FkIdPelicula);
                    command.Parameters.AddWithValue("@FkIdSala", sesion.FkIdSala);
                    command.Parameters.AddWithValue("@FechaInicio", sesion.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", sesion.FechaFin);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM sesion WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
