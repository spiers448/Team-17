using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public class Admin : User
    {
        //private fields
        private DateTime loginDate;
        private string status;

        //public properties
        public DateTime LoginDate
        {
            get { return loginDate; }
            set { loginDate = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }   

        //constructor
        public Admin(int userID, string userName, string password, string email, UserRole role, string status, DateTime loginDate, bool isLoggedIn) : base(userID, userName, password, role, email, isLoggedIn)
        {
            this.IsLoggedIn = isLoggedIn;
            this.loginDate = loginDate;
            this.status = status;
        }
    }
}
