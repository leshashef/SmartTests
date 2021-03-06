using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<UserModel> Users { get; set; }
        public RoleModel()
        {
            Users = new List<UserModel>();
        }
    }
}
