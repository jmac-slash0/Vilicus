using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vilicus.Web.Models
{
    public class UserEditModel : UserLoginModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PasswordConfirmation { get; set; }

        // Eventually need to edit company name or something here
    }
}