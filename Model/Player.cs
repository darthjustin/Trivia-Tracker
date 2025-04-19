using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Tracker.Model
{
    class Player
    {
        private int playerID;
        private string firstName;
        private string lastName;
        private string username;
        private DateTime createdDate;
        private DateTime lastGamePlayed;
        private int lastGameID;
        private int totalScore;
        private int gamesPlayed;
        private int totalGuesses;
        private int totalCorrect;
        private int bestGameScore;
        private int bestGameID;

        public Player(int playerID, string firstName, string lastName, string username, DateTime createdDate, DateTime lastGamePlayed, int lastGameID, int totalScore, int gamesPlayed, int totalGuesses, int totalCorrect, int bestGameScore, int bestGameID)
        {
            this.playerID = playerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.createdDate = createdDate;
            this.lastGamePlayed = lastGamePlayed;
            this.lastGameID = lastGameID;
            this.totalScore = totalScore;
            this.gamesPlayed = gamesPlayed;
            this.totalGuesses = totalGuesses;
            this.totalCorrect = totalCorrect;
            this.bestGameScore = bestGameScore;
            this.bestGameID = bestGameID;
        }

        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public DateTime LastGamePlayed
        {
            get { return lastGamePlayed; }
            set { lastGamePlayed = value; }
        }

        public int LastGameID
        {
            get { return lastGameID; }
            set { lastGameID = value; }
        }

        public int TotalScore
        {
            get { return totalScore; }
            set { totalScore = value; }
        }

        public int GamesPlayed
        {
            get { return gamesPlayed; }
            set { gamesPlayed = value; }
        }

        public int TotalGuesses
        {
            get { return totalGuesses; }
            set { totalGuesses = value; }
        }

        public int TotalCorrect
        {
            get { return totalCorrect; }
            set { totalCorrect = value; }
        }

        public int BestGameScore
        {
            get { return bestGameScore; }
            set { bestGameScore = value; }
        }

        public int BestGameID
        {
            get { return bestGameID; }
            set { bestGameID = value; }
        }

    }
}
