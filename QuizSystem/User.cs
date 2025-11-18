using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public class User
    {
        //private fields
        private int userID;
        private string userName;
        private string password;
        private string email;
        private string role;

        //public fields
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }


        //constructor
        public User(int userID, string userName, string password, string email, string role)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.role = role;

        }

    }
}

