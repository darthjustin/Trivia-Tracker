using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Tracker.Model
{
    class Game
    {
        private int gameID;
        private DateTime gameDate;
        private int totalScore;

        public Game(int gameID, DateTime gameDate, int totalScore)
        {
            this.gameID = gameID;
            this.gameDate = gameDate;
            this.totalScore = totalScore;
        }

        public int GameID
        {
            get { return gameID; }
            set { gameID = value; }
        }

        public DateTime GameDate
        {
            get { return gameDate; }
            set { gameDate = value; }
        }

        public int TotalScore
        {
            get { return totalScore; }
            set { totalScore = value; }
        }
    }
}
