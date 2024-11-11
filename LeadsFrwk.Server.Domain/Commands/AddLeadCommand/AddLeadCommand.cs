using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.AddLeadCommand
{
    public class AddLeadCommand : IRequest<bool>
    {
        public string? ContactFirstName { get; set; }
        public string? Suburb { get; set; }
        public int Category { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ContactLastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
