using LeadsFrwk.Server.Domain.Enums;

namespace LeadsFrwk.Server.Domain.LeadChangeStatus
{
    public class LeadChangeStatusRequestModel
    {
        public StatusLeadEnum Status { get; set; }
        public double Price { get; set; }
        public string Email { get; set; }
    }
}
