using MediatR;

namespace Application.Commands
{
    public class DeleteUsuarioCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteUsuarioCommand(Guid id)
        {
            Id = id;
        }
    }
}
