using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceWebApp.Data
{
    public class SMTPSettings
    {
        [NotMapped]
        public string Server { get; set; }
        [NotMapped]
        public int Port { get; set; }
        [NotMapped]
        public string SenderName { get; set; }
        [NotMapped]
        public string SenderEmail { get; set; }
        [NotMapped]
        public string Username { get; set; }
        [NotMapped]
        public string Password { get; set; }
    }
}
