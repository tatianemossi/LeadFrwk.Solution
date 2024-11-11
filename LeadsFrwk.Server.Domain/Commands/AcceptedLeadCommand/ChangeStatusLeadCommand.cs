using LeadsFrwk.Server.Domain.Enums;
using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.AcceptedLeadCommand
{
    public class ChangeStatusLeadCommand : IRequest<bool>
    {
        public ChangeStatusLeadCommand(int id, StatusLeadEnum status, double price)
        {
            Id = id;
            Status = status;
            Price = price;
        }

        public int Id { get; set; }
        public StatusLeadEnum Status { get; set; }
        public double Price { get; set; }
    }
}
