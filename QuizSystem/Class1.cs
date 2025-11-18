using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public class Quiz
    {
        //private fields
        private int quizID;
        private string quizTitle;
        private string quizDescription;
        private DateTime quizDate;
        private List<int> quizQuestions;
        //private catagory quizCatagory;

        //public fields
        public int QuizID
        {
            get { return quizID; }
            set { quizID = value; }
        }
        public string QuizTitle
        {
            get { return quizTitle; }
            set { quizTitle = value; }
        }
        public string QuizDescription
        {
            get { return quizDescription; }
            set { quizDescription = value; }
        }
        public DateTime QuizDate
        {
            get { return quizDate; }
            set { quizDate = value; }
        }
        public List<int> QuizQuestions
        {
            get { return quizQuestions; }
            set { quizQuestions = value; }
        }
        /*
        public catagory QuizCatagory
        {
            get { return quizCatagory; }
            set { quizCatagory = value; }
        }
        */

        //constructor
        public Quiz(int quizID, string quizTitle, string quizDescription, DateTime quizDate, List<int> quizQuestions)
        {
            this.quizID = quizID;
            this.quizTitle = quizTitle;
            this.quizDescription = quizDescription;
            this.quizDate = quizDate;
            this.quizQuestions = quizQuestions;
        }

    }
}

