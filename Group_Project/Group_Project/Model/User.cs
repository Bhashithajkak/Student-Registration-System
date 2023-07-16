using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Group_Project.Model
{
    public class User
    {

        [Key]
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string userID, string userName, string password)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
        }

        public User()
        {
        }


    }
}