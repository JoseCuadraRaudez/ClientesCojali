namespace Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public Usuario(Guid id, string nombre, string email)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
        }
    }
}