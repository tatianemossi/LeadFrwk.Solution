using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.SendMailAcceptedCommand
{
    public class SendMailAcceptedCommand : IRequest<bool>
    {
        public SendMailAcceptedCommand(int id, string email)
        {
            Id = id;
            Email = email;
        }

        public int Id {get; set;}
        public string Email {get; set;}
    }
}
