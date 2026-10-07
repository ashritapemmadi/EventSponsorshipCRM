using System.ComponentModel.DataAnnotations;

namespace EventSponsorshipCRM.Models
{
    public class FollowUp
    {
        public int FollowUpId { get; set; }

        [Required]
        public string SponsorName { get; set; } = "";

        [Required]
        public DateTime FollowUpDate { get; set; }

        [Required]
        public string FollowUpType { get; set; } = "Call";

        public string? Remarks { get; set; }

        [Required]
        public string Status { get; set; } = "Planned";

        public string? AssignedTo { get; set; }
    }
}