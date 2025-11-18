using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    internal class Admin : User
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
        public Admin(int userID, string userName, string password, string email, string role, string status, DateTime loginDate) : base(userID, userName, password, email, role)
        {
            this.loginDate = loginDate;
            this.status = status;
        }
    }
}
