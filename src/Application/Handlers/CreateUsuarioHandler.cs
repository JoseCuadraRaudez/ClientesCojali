using MediatR;
using Domain.Entities;
using Domain.Interfaces;
using Application.Commands;
using Infrastructure.Services;

namespace Application.Handlers
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;

        public CreateUsuarioHandler(IUsuarioRepository usuarioRepository, IEmailService emailService)
        {
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(Guid.NewGuid(), request.Nombre, request.Email);
            await _usuarioRepository.AddAsync(usuario);
            await _emailService.SendEmailAsync(usuario.Email, "Bienvenido", "Gracias por registrarte.");
            return Unit.Value;
        }
    }
}
