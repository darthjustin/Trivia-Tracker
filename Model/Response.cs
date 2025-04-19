using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Tracker.Model
{
    class Response
    {
        private int responseID;
        private int questionID;
        private string responseText;
        private bool isCorrect;
        private int playerID;
        private bool bonusUsed;

        public Response(int responseID, int questionID, string responseText, bool isCorrect, int playerID, bool bonusUsed)
        {
            this.responseID = responseID;
            this.questionID = questionID;
            this.responseText = responseText;
            this.isCorrect = isCorrect;
            this.playerID = playerID;
            this.bonusUsed = bonusUsed;
        }

        public int ResponseID
        {
            get { return responseID; }
            set { responseID = value; }
        }

        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }

        public string ResponseText
        {
            get { return responseText; }
            set { responseText = value; }
        }

        public bool IsCorrect
        {
            get { return isCorrect; }
            set { isCorrect = value; }
        }

        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

        public bool BonusUsed
        {
            get { return bonusUsed; }
            set { bonusUsed = value; }
        }

    }
}
