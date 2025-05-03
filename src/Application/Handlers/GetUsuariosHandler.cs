using Application.Queries;
using Application.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers
{
    public class GetUsuariosHandler : IRequestHandler<GetUsuariosQuery, List<UsuarioDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public GetUsuariosHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioDto>> Handle(GetUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id.ToString(),
                Nombre = u.Nombre,
                Email = u.Email
            }).ToList();
        }
    }
}
