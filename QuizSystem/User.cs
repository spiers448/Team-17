using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{

    //Enum definition for User Roles
    public enum UserRole
    {
        Admin,
        User
    }


    public class User
    {
        // Private fields
        private int userId;
        private string username;
        private string password;
        private UserRole role;
        private string contactinfo;
        private bool isLoggedIn;

        // Public properties
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public UserRole Role
        {
            get { return role; }
            set { role = value; }
        }
        public string ContactInfo
        {
            get { return contactinfo; }
            set { contactinfo = value; }
        }
        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set { isLoggedIn = value; }
        }

        //default constructor
        public User()
        {

        }

        //Paramaterised Constructor
        public User(int userId, string username, string password, UserRole role, string contactInfo, bool IsLoggedIn)
        {
            UserId = userId;
            UserName = username;
            Password = password;
            Role = role;
            ContactInfo = contactinfo;
            IsLoggedIn = false;
        }

        // Methods
        public bool Login(string userName, string password)
        {
            if (UserName == userName && Password == password)
            {
                // username and password are authenticated.
                // Advise user that their login is successful.
                IsLoggedIn = true;
                Console.WriteLine("Login successful");
            }
            else
            {
                // username and/or password are incorrect. Advise user
                // that their login details are incorrect.
                IsLoggedIn = false;
                Console.WriteLine($"Login failed. Username {userName} or password is incorrect");
            }
            return IsLoggedIn;
        }

        public void Logout()
        {
            if (IsLoggedIn)
            {
                IsLoggedIn = false;
                Console.WriteLine("User is logged out successfully.");
            }
            else
            {
                Console.WriteLine("User is not logged in");
            }
        }

        public void ControlDevice(int deviceId, string deviceName, string deviceAction)
        {
            if (isLoggedIn)
            {
                Console.WriteLine($"Performing action {deviceAction} on {deviceName}");
                // Add logic to control the smart device here
            }
            else
            {
                Console.WriteLine("Please log in to control the device");
            }
        }

    }
}

