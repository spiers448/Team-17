using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public class Result
    {
        //private fields
        private int attemptID;
        private Student student;
        private Quiz quizTaken;
        private int score;
        private DateTime dateCompleted;

        //public properties
        public int AttemptID
        {
            get { return attemptID; }
            set { attemptID = value; }
        }
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
        public Quiz QuizTaken
        {
            get { return quizTaken; }
            set { quizTaken = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public DateTime DateCompleted
        {
            get { return dateCompleted; }
            set { dateCompleted = value; }
        }

        //constructor
        public Result(int attemptID, Student student, Quiz quizTaken, int score, DateTime dateCompleted)
        {
            this.attemptID = attemptID;
            this.student = student;
            this.quizTaken = quizTaken;
            this.score = score;
            this.dateCompleted = dateCompleted;
        }

    }
}
