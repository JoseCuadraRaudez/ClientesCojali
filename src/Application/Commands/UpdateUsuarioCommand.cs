using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class UpdateUsuarioCommand : IRequest<Unit>
    {
        public UsuarioDto Usuario { get; }

        public UpdateUsuarioCommand(UsuarioDto usuario)
        {
            Usuario = usuario;
        }
    }
}
