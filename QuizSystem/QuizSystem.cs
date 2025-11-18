using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    internal class QuizSystem
    {
        //private fields
        private List<Admin> adminUsers;
        private List<Student> studentUsers;
        private List<Quiz> quizList;
        private List<Category> categoryList;

        //public properties
        public List<Admin> AdminUsers
        {
            get { return adminUsers; }
            set { adminUsers = value; }
        }
        public List<Student> StudentUsers
        {
            get { return studentUsers; }
            set { studentUsers = value; }
        }
        public List<Quiz> QuizList
        {
            get { return quizList; }
            set { quizList = value; }
        }
        public List<Category> CategoryList
        {
            get { return categoryList; }
            set { categoryList = value; }
        }

        //constructor
        public QuizSystem(List<Admin> adminUsers, List<Student> studentUsers, List<Quiz> quizList, List<Category> categoryList)
        {
            this.adminUsers = adminUsers;
            this.studentUsers = studentUsers;
            this.quizList = quizList;
            this.categoryList = categoryList;
        }
    }
}
