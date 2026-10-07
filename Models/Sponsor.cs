using System.ComponentModel.DataAnnotations;

namespace EventSponsorshipCRM.Models
{
    public class Sponsor
    {
        public int SponsorId { get; set; }

        [Required]
        public string SponsorCode { get; set; } = "";

        [Required]
        public string SponsorName { get; set; } = "";

        [Required]
        public string ContactPerson { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Phone { get; set; } = "";

        public string? City { get; set; }

        public string? State { get; set; }

        public string Status { get; set; } = "Active";

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}