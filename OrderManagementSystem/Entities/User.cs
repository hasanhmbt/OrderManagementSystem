using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entities
{
    public class User:BaseEntities
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool Status { get; set; }
        public bool ChangePassword { get; set; }
        public DateTime AddDate { get; set; }

    }
}
