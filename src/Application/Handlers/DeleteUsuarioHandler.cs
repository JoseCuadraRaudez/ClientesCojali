using Application.Commands;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.Handlers
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;

        public DeleteUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            await _repository.DeleteAsync(id);
            return Unit.Value;
        }
    }
}
