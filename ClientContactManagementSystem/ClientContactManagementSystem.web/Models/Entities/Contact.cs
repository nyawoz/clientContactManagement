using System.ComponentModel.DataAnnotations;

namespace ClientContactManagementSystem.web.Models.Entities
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname {  get; set; }
        public string ContactEmail { get; set; }
        public bool linkClientCheck {  get; set; }

        public ICollection<Clients> Client { get; set; }

    }
}
