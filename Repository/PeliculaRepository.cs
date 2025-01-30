
using Microsoft.Data.SqlClient;
using Models;

namespace RestauranteAPI.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly string _connectionString;

        public PeliculaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Pelicula>> GetAllAsync()
        {
            var peliculas = new List<Pelicula>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, Descripcion, Director, AnioSalida, ImagenBannerUrl, ImagenPequeniaUrl, Duracion, Precio FROM pelicula";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var pelicula = new Pelicula
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Director = reader.GetString(3),
                                AnioSalida = (DateTime)reader.GetValue(4),
                                ImagenBannerUrl = reader.GetString(5),
                                ImagenPequeniaUrl = reader.GetString(6),
                                Duracion = reader.GetInt32(7),
                                Precio = (Double) reader.GetDecimal(8)
                            }; 

                            peliculas.Add(pelicula);
                            }
                    }
                }
            }
            return peliculas;
        }

        public async Task<Pelicula> GetByIdAsync(int id)
        {
            Pelicula pelicula = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, Descripcion, Director, AnioSalida, ImagenBannerUrl, ImagenPequeniaUrl, Duracion, Precio FROM pelicula Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            pelicula = new Pelicula
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Director = reader.GetString(3),
                                AnioSalida = (DateTime)reader.GetValue(4),
                                ImagenBannerUrl = reader.GetString(5),
                                ImagenPequeniaUrl = reader.GetString(6),
                                Duracion = reader.GetInt32(7),
                                Precio = (Double) reader.GetDecimal(8)
                            };
                        }
                    }
                }
            }
            return pelicula;
        }

        public async Task AddAsync(Pelicula pelicula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Bebida (Nombre, Descripcion, Director, AnioSalida, ImagenBannerUrl, ImagenPequeniaUrl, Duracion, Precio) VALUES (@Nombre, @Descripcion, @Director, @AnioSalida, @ImagenBannerUrl, @ImagenPequeniaUrl, @Duracion, @Precio)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", pelicula.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", pelicula.Descripcion);
                    command.Parameters.AddWithValue("@Director", pelicula.Director);
                    command.Parameters.AddWithValue("@AnioSalida", pelicula.AnioSalida);
                    command.Parameters.AddWithValue("@ImagenBannerUrl", pelicula.ImagenBannerUrl);
                    command.Parameters.AddWithValue("@ImagenPequeniaUrl", pelicula.ImagenPequeniaUrl);
                    command.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
                    command.Parameters.AddWithValue("@Precio", pelicula.Precio);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Pelicula pelicula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE pelicula SET Nombre = @Nombre, Precio = @Precio, esAlcoholica = @esAlcoholica WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", pelicula.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", pelicula.Descripcion);
                    command.Parameters.AddWithValue("@Director", pelicula.Director);
                    command.Parameters.AddWithValue("@AnioSalida", pelicula.AnioSalida);
                    command.Parameters.AddWithValue("@ImagenBannerUrl", pelicula.ImagenBannerUrl);
                    command.Parameters.AddWithValue("@ImagenPequeniaUrl", pelicula.ImagenPequeniaUrl);
                    command.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
                    command.Parameters.AddWithValue("@Precio", pelicula.Precio);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM pelicula WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}