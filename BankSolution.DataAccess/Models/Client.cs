using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSolution.DataAccess.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public DateTime FirstOrder { get; set; }
        public string Email { get; set; }
        public List<Project> projects { get; set; } = new List<Project>();
    }
}
