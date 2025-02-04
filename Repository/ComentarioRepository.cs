using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly string _connectionString;

        public ComentarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Comentario>> GetAllAsync()
        {
            var comentarios = new List<Comentario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdPelicula, FkIdUsuario, Valoracion, Comentario FROM comentarios";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        comentarios.Add(new Comentario
                        {
                            Id = reader.GetInt32(0),
                            FkIdPelicula = reader.GetInt32(1),
                            FkIdUsuario = reader.GetInt32(2),
                            Valoracion = reader.GetInt32(3),
                            ComentarioTexto = reader.GetString(4)
                        });
                    }
                }
            }
            return comentarios;
        }

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            Comentario? comentario = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdPelicula, FkIdUsuario, Valoracion, Comentario FROM comentarios WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            comentario = new Comentario
                            {
                                Id = reader.GetInt32(0),
                                FkIdPelicula = reader.GetInt32(1),
                                FkIdUsuario = reader.GetInt32(2),
                                Valoracion = reader.GetInt32(3),
                                ComentarioTexto = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return comentario;
        }

        public async Task<List<Comentario>> GetByPeliculaIdAsync(int peliculaId)
        {
            var comentarios = new List<Comentario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, FkIdPelicula, FkIdUsuario, Valoracion, Comentario FROM comentarios WHERE FkIdPelicula = @PeliculaId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PeliculaId", peliculaId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            comentarios.Add(new Comentario
                            {
                                Id = reader.GetInt32(0),
                                FkIdPelicula = reader.GetInt32(1),
                                FkIdUsuario = reader.GetInt32(2),
                                Valoracion = reader.GetInt32(3),
                                ComentarioTexto = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return comentarios;
        }

        public async Task AddAsync(Comentario comentario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO comentarios (FkIdPelicula, FkIdUsuario, Valoracion, Comentario) VALUES (@FkIdPelicula, @FkIdUsuario, @Valoracion, @Comentario)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FkIdPelicula", comentario.FkIdPelicula);
                    command.Parameters.AddWithValue("@FkIdUsuario", comentario.FkIdUsuario);
                    command.Parameters.AddWithValue("@Valoracion", comentario.Valoracion);
                    command.Parameters.AddWithValue("@Comentario", comentario.ComentarioTexto);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Comentario comentario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE comentarios SET FkIdPelicula = @FkIdPelicula, FkIdUsuario = @FkIdUsuario, Valoracion = @Valoracion, Comentario = @Comentario WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", comentario.Id);
                    command.Parameters.AddWithValue("@FkIdPelicula", comentario.FkIdPelicula);
                    command.Parameters.AddWithValue("@FkIdUsuario", comentario.FkIdUsuario);
                    command.Parameters.AddWithValue("@Valoracion", comentario.Valoracion);
                    command.Parameters.AddWithValue("@Comentario", comentario.ComentarioTexto);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM comentarios WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
