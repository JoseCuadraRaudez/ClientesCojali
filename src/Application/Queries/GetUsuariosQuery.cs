using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetUsuariosQuery : IRequest<List<UsuarioDto>> { }
}
