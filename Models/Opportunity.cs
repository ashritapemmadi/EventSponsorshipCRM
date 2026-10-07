using System.ComponentModel.DataAnnotations;

namespace EventSponsorshipCRM.Models
{
    public class Opportunity
    {
        public int OpportunityId { get; set; }

        [Required]
        public string OpportunityName { get; set; } = "";

        [Required]
        public string SponsorName { get; set; } = "";

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Range(0, 100, ErrorMessage = "Probability must be between 0 and 100.")]
        public int Probability { get; set; }

        [Required]
        public string Stage { get; set; } = "Qualification";

        [DataType(DataType.Date)]
        public DateTime ExpectedCloseDate { get; set; }

        public string Status { get; set; } = "Active";

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? AssignedTo { get; set; }
    }
}