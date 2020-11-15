using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouseBHK.BHKDTO
{
    class UsersDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public UsersDTO()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsAdmin = false;
            this.IsActive = false;
        }

        public UsersDTO(UsersDTO _User)
        {
            this.UserName = _User.UserName;
            this.Password = string.Empty;
            this.IsAdmin = _User.IsAdmin;
            this.IsActive = true;
        }

        public UsersDTO(string _UserName, bool _IsAdmin)
        {
            this.UserName = _UserName;
            this.Password = string.Empty;
            this.IsAdmin = _IsAdmin;
            this.IsActive = true;
        }
    }
}
