using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public class Student : User
    {
        //private fields
        private string status;

        //public properties
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        //constructor
        public Student(int userID, string userName, string password, string email, string role, string status) : base(userID, userName, password, email, role)
        {
            this.status = status;
        }
    }
}
