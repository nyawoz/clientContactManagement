namespace ClientContactManagementSystem.web.Models.Entities
{
    public class LinkContactClientView
    {
        public IEnumerable<Clients> Clients { get; set; }   
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
