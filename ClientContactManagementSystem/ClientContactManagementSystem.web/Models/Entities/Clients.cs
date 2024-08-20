using System.ComponentModel.DataAnnotations;

namespace ClientContactManagementSystem.web.Models.Entities
{
    public class Clients
    {
        [Key]
        public Guid ClientId { get; set; }
        public String ClientCode {  get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientEmail { get; set; }
        public int NumberOfLinkedContact {  get; set; }


        public ICollection<Contact> Contacts { get; set; }
    }
}
