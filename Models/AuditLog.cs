using System.ComponentModel.DataAnnotations;

namespace EventSponsorshipCRM.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        public string? UserId { get; set; }

        [Required]
        public string Action { get; set; } = "";

        [Required]
        public string EntityName { get; set; } = "";

        public int? RecordId { get; set; }

        public string? Details { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}