using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public class Question
    {
        //private fields
        private int questionID;
        private string questionText;
        private List<string> questionOptions;
        private string questionCorrectAnswer;
        private string questionDifficultyLevel;
        
        //public properties
        public int QuestionID
        {
            get { return questionID; }
        }
        
        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }
        
        public List<string> QuestionOptions
        {
            get { return questionOptions; }
            set { questionOptions = value; }
        }
        
        public string QuestionCorrectAnswer
        {
            get { return questionCorrectAnswer; }
            set { questionCorrectAnswer = value; }
        }
        
        public string QuestionDifficultyLevel
        {
            get { return questionDifficultyLevel; }
            set { questionDifficultyLevel = value; }
        }
        
        //default constructor
        public Question()
        {
        }
        
        //constructor
        public Question(int questionID, string questionText, List<string> questionOptions, string questionCorrectAnswer, string questionDifficultyLevel)
        {
            this.questionID = questionID;
            this.questionText = questionText;
            this.questionOptions = questionOptions;
            this.questionCorrectAnswer = questionCorrectAnswer;
            this.questionDifficultyLevel = questionDifficultyLevel;
        }
    }
}