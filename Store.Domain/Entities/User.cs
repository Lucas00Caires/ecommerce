using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class User : BaseEntity
    {
        private User() { }
        public User(string name, string email, string password) { 
            Name= name;
            Email= email;
            Password= password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
