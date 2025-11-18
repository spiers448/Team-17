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
        private string questionCorrectAnwser;
        private string questionDifficultyLevel;

        //public properties
        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
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
        public string QuestionCorrectAnwser
        {
            get { return questionCorrectAnwser; }
            set { questionCorrectAnwser = value; }
        }
        public string QuestionDifficultyLevel
        {
            get { return questionDifficultyLevel; }
            set { questionDifficultyLevel = value; }
        }

        //constructor
        public Question(int questionID, string questionText, List<string> questionOptions, string questionCorrectAnwser, string questionDifficultyLevel)
        {
            this.questionID = questionID;
            this.questionText = questionText;
            this.questionOptions = questionOptions;
            this.questionCorrectAnwser = questionCorrectAnwser;
            this.questionDifficultyLevel = questionDifficultyLevel;
        }

    }
}
