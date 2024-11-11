using LeadsFrwk.Server.Domain.Entities;
using LeadsFrwk.Server.Domain.Enums;
using LeadsFrwk.Server.Domain.Interfaces.Services;
using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.AddLeadCommand
{
    public class AddLeadCommandHandler : IRequestHandler<AddLeadCommand, bool>
    {
        private readonly ILeadService _leadService;

        public AddLeadCommandHandler(ILeadService leadService)
        {
            _leadService = leadService;
        }

        public async Task<bool> Handle(AddLeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var lead = new Lead
                {
                    Category = request.Category,
                    ContactFirstName = request.ContactFirstName,
                    CreateDate = DateTime.Now,
                    Description = request.Description,
                    Price = request.Price,
                    Suburb = request.Suburb,
                    Status = StatusLeadEnum.Created,
                    ContactLastName = request.ContactLastName,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email
                };

                var result = await _leadService.AddAsync(lead, cancellationToken);
                if (result != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
