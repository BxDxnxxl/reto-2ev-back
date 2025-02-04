using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Username, Nombre, Apellido1, Apellido2, Contraseña, ProfilePic FROM usuarios";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Nombre = reader.GetString(2),
                            Apellido1 = reader.GetString(3),
                            Apellido2 = reader.GetString(4),
                            Contraseña = reader.GetString(5),
                            ProfilePic = reader.GetString(6)
                        });
                    }
                }
            }
            return usuarios;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            Usuario? usuario = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Username, Nombre, Apellido1, Apellido2, Contraseña, ProfilePic FROM usuarios WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new Usuario
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                Apellido1 = reader.GetString(3),
                                Apellido2 = reader.GetString(4),
                                Contraseña = reader.GetString(5),
                                ProfilePic = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            return usuario;
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            Usuario? usuario = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Username, Nombre, Apellido1, Apellido2, Contraseña, ProfilePic FROM usuarios WHERE Username = @Username";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new Usuario
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                Apellido1 = reader.GetString(3),
                                Apellido2 = reader.GetString(4),
                                Contraseña = reader.GetString(5),
                                ProfilePic = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            return usuario;
        }

        public async Task AddAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO usuarios (Username, Nombre, Apellido1, Apellido2, Contraseña, ProfilePic) VALUES (@Username, @Nombre, @Apellido1, @Apellido2, @Contraseña, @ProfilePic)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", usuario.Username);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido1", usuario.Apellido1);
                    command.Parameters.AddWithValue("@Apellido2", usuario.Apellido2);
                    command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    command.Parameters.AddWithValue("@ProfilePic", usuario.ProfilePic);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE usuarios SET Username = @Username, Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, Contraseña = @Contraseña, ProfilePic = @ProfilePic WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", usuario.Id);
                    command.Parameters.AddWithValue("@Username", usuario.Username);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido1", usuario.Apellido1);
                    command.Parameters.AddWithValue("@Apellido2", usuario.Apellido2);
                    command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    command.Parameters.AddWithValue("@ProfilePic", usuario.ProfilePic);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM usuarios WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
