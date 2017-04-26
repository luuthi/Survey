using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AcountsEntities
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string GroupId { get; set; }
        public string Passwords { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string Mail { get; set; }
        public string Avatar { get; set; }
        public bool Status { get; set; }
    }
}
