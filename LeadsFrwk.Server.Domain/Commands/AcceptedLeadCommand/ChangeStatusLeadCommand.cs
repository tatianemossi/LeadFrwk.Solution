using LeadsFrwk.Server.Domain.Enums;
using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.AcceptedLeadCommand
{
    public class ChangeStatusLeadCommand : IRequest<bool>
    {
        public ChangeStatusLeadCommand(int id, StatusLeadEnum status)
        {
            Id = id;
            Status = status;
        }

        public int Id { get; set; }
        public StatusLeadEnum Status { get; set; }
    }
}
