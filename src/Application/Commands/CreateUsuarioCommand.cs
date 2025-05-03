using MediatR;

namespace Application.Commands
{
    public class CreateUsuarioCommand : IRequest<Unit>
    {
        public string Nombre { get; set; }
        public string Email { get; set; }

        public CreateUsuarioCommand(string nombre, string email)
        {
            Nombre = nombre;
            Email = email;
        }
    }
}
