using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.DeleteLeadCommand
{
    public class DeleteLeadCommand : IRequest<bool>
    {
        public DeleteLeadCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
