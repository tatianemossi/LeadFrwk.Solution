using LeadsFrwk.Server.Domain.Enums;

namespace LeadsFrwk.Server.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string? ContactFirstName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Suburb { get; set; }
        public int Category { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public StatusLeadEnum Status { get; set; }
    }
}
