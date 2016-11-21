using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Model.Models
{
    public class CreateUserWrapper
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
    }
}
