using System.ComponentModel.DataAnnotations;

namespace EventSponsorshipCRM.Models
{
    public class Lead
    {
        public int LeadId { get; set; }

        [Required]
        public string LeadCode { get; set; } = "";

        [Required]
        public string LeadName { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Phone { get; set; } = "";

        public string? CompanyName { get; set; }

        public string? Source { get; set; }

        [Required]
        public string Status { get; set; } = "New";

        [Range(0, double.MaxValue)]
        public decimal ExpectedValue { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? AssignedTo { get; set; }
    }
}