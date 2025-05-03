using Domain.Entities;
using Domain.Interfaces;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class FileUsuarioRepository : IUsuarioRepository
    {

        private readonly string FilePath;

        public FileUsuarioRepository()
        {
            FilePath = Path.Combine(AppContext.BaseDirectory, "Persistence/usuarios.json"); // Una ruta meramente basica....
        }



        // Cargar usuarios desde el archivo JSON
        private List<Usuario> LoadUsuarios()
        {
            if (!File.Exists(FilePath))
                return new List<Usuario>();

            var json = File.ReadAllText(FilePath);
            var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Usuario>();

            // Convertir id de string a Guid si es necesario
            foreach (var usuario in usuarios)
            {
                if (usuario.Id == Guid.Empty && Guid.TryParse(usuario.Id.ToString(), out var guidId))
                {
                    usuario.Id = guidId;
                }
            }

            return usuarios;
        }

        // Guardar usuarios al archivo JSON
        private void SaveUsuarios(List<Usuario> usuarios)
        {
            var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        // Obtener todos los usuarios
        public Task<List<Usuario>> GetAllAsync()
        {
            var usuarios = LoadUsuarios();
            return Task.FromResult(usuarios);
        }

        // Reemplazar el método GetByIdAsync(string id) para corregir el error CS0019
        public Task<Usuario?> GetByIdAsync(string id)
        {
            var usuarios = LoadUsuarios();
            if (Guid.TryParse(id, out var guidId)) // Convertir el string a Guid
            {
                var usuario = usuarios.FirstOrDefault(u => u.Id == guidId); // Comparar Guid con Guid
                return Task.FromResult(usuario);
            }
            return Task.FromResult<Usuario?>(null); // Retornar null si la conversión falla
        }

        // Agregar un nuevo usuario
        public Task AddAsync(Usuario usuario)
        {
            var usuarios = LoadUsuarios();
            usuarios.Add(usuario);
            SaveUsuarios(usuarios);
            return Task.CompletedTask;
        }

        // Actualizar un usuario existente
        public Task UpdateAsync(Usuario usuario)
        {
            var usuarios = LoadUsuarios();
            var index = usuarios.FindIndex(u => u.Id == usuario.Id);
            if (index != -1)
            {
                usuarios[index] = usuario;
                SaveUsuarios(usuarios);
            }
            return Task.CompletedTask;
        }

        // Reemplazar el método DeleteAsync(string id) para corregir el error CS0019
        public Task DeleteAsync(Guid id)
        {
            var usuarios = LoadUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
                SaveUsuarios(usuarios);
            }
            return Task.CompletedTask;
        }

        public Task<Usuario> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
