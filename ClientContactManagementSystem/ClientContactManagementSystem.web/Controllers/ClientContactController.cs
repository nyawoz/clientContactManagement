using ClientContactManagementSystem.web.Data;
using ClientContactManagementSystem.web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ClientContactManagementSystem.web.Controllers
{
    public class ClientContactController : Controller
    {
        private static Dictionary<string, int> clientCodeTracker = new Dictionary<string, int>();
        private readonly ClientManagementDbContext dbContext;
        public ClientContactController(ClientManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult AddNewClient()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewClient(Clients addClient)
        {
            var clientCode = GenerateClientCode(addClient.ClientName);
            var Clients = new Clients
            {
                ClientName = addClient.ClientName,
                ClientSurname = addClient.ClientSurname,
                ClientEmail = addClient.ClientSurname,
                ClientCode = clientCode,
                NumberOfLinkedContact = 0
            };
            await dbContext.tblClients.AddAsync(Clients);
            await dbContext.SaveChangesAsync();
            return View("AddNewClient");
        }

        public string GenerateClientCode(string clientName)
        {
            // Split the client name into words
            var nameParts = clientName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Get the first letter of each word
            var codePrefix = string.Concat(nameParts.Select(part => part[0]));
            char codeAlphabets = 'A';
            if (clientCodeTracker.ContainsKey(codePrefix))
            {
                codeAlphabets = (char)(clientCodeTracker[codePrefix] + 65);
            }
            else
            {
                codeAlphabets = 'A';
            }

            if (nameParts.Length == 1)
            {
                codePrefix = clientName.Substring(0, 3);
            }
            else if (nameParts.Length == 2)
            {
                codePrefix = string.Concat(nameParts.Select(part => part[0])) + codeAlphabets;
            }

            // Increment the client code number
            int codeNumber = 0;
            if (clientCodeTracker.ContainsKey(codePrefix))
            {
                codeNumber = clientCodeTracker[codePrefix] + 1;
            }
            else
            {
                codeNumber = 1;
            }

            // Update the tracker
            clientCodeTracker[codePrefix] = codeNumber;

            // Generate the final client code
            var clientCode = $"{codePrefix.ToUpper()}{codeNumber:D3}";

            return clientCode;
        }

        [HttpGet]
        //public async Task<IActionResult> DisplayClients()
        //{

        //    var clients = await dbContext.tblClients.OrderBy(c => c.ClientName).ToListAsync();

        //    return View(clients);
        //}

        [HttpGet]
        public IActionResult NewContact() { return View(); }
        [HttpPost]
        public async Task<IActionResult> NewContact(Contact addcontact)
        {
            var newcontact = new Contact
            {
                ContactName = addcontact.ContactName,
                ContactSurname = addcontact.ContactSurname,
                ContactEmail = addcontact.ContactEmail,
                linkClientCheck = addcontact.linkClientCheck
            };
            await dbContext.tblContacts.AddAsync(newcontact);
            await dbContext.SaveChangesAsync();
            return View("NewContact");
        }

        [HttpGet]
        public async Task<IActionResult> DisplayContact()
        {
            var contact = await dbContext.tblContacts.OrderBy(c =>c.ContactSurname).ToListAsync();
            return View(contact);
        }

        public async Task<IActionResult> LinkContactClientView()
        {
            var linkedContact = new LinkContactClientView
            {
                Clients = await dbContext.tblClients.ToListAsync(),
                Contacts = await dbContext.tblContacts.Include(p => p.Client).ToListAsync(),
            };
            return View(linkedContact);
        }


        [HttpPost]
        public async Task<IActionResult> updatenumberofLinkingContact(String code, int status)
        {
            try
            {
                // Find the client by id
                var client = await dbContext.tblClients.FirstOrDefaultAsync(c => c.ClientCode == code);
                if (client == null)
                {
                    return NotFound();
                }

                // Update the status field
                client.NumberOfLinkedContact = status;

                // Save changes to the database
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

