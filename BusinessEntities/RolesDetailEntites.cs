using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class RolesDetailEntites
    {
        public string RoleDetailID { get; set; }
        public string RolesID { get; set; }
        public string GroupID { get; set; }
        public bool View_ { get; set; }
        public bool Add_ { get; set; }
        public bool Update_ { get; set; }
        public bool Delete_ { get; set; }
    }
}
