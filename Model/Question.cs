using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Tracker.Model
{
    class Question
    {
        private int questionID;
        private int gameID;
        private int roundNum;
        private string questionText;
        private string category;
        private string correctAnswer;
        private string questionType;
        private int pointValue;

        public Question(int questionID, int gameID, int roundNum, string questionText, string category, string correctAnswer, string questionType)
        {
            this.questionID = questionID;
            this.gameID = gameID;
            this.roundNum = roundNum;
            this.questionText = questionText;
            this.category = category;
            this.correctAnswer = correctAnswer;
            this.questionType = questionType;
        }

        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }

        public int GameID
        {
            get { return gameID; }
            set { gameID = value; }
        }

        public int RoundNum
        {
            get { return roundNum; }
            set { roundNum = value; }
        }

        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        public string QuestionType
        {
            get { return questionType; }
            set { questionType = value; }
        }

        public int PointValue
        {
            get { return pointValue; }
            set
            {
                if (roundNum == 1) { pointValue = 5; }
                else if (roundNum == 2) { pointValue = 10; }
                else if (roundNum == 3) { pointValue = 20; }
                else if (roundNum == 4) { pointValue = 40; }
            }
        }


    }
}
