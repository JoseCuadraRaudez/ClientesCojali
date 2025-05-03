using Application.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
{
    private readonly IUsuarioRepository _repository;

    public UpdateUsuarioHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario(
            Guid.Parse(request.Usuario.Id),
            request.Usuario.Nombre,
            request.Usuario.Email
        );

        await _repository.UpdateAsync(usuario); // Asegúrate que UpdateAsync acepte el tipo correcto

        return Unit.Value;
    }
}
