using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia_Tracker.Model;
using MySqlConnector;

namespace Trivia_Tracker.Helpers
{
    class PlayerQuery
    {
        public List<Player> GetAllPlayers()
        {
            string query = "SELECT * FROM players";
            List<Player> playerList = new List<Player>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int playerID = reader.GetInt32("player_ID");
                            string firstName = reader.GetString("first_name");
                            string lastName = reader.GetString("last_name");
                            string userName = reader.GetString("user_name");
                            DateTime createdDate = reader.GetDateTime("created_at");
                            DateTime lastGamePlayed = reader.GetDateTime("last_game_played");
                            int lastGameID = reader.GetInt32("last_game_ID");
                            int totalScore = reader.GetInt32("total_score");
                            int gamesPlayed = reader.GetInt32("games_played");
                            int totalGuesses = reader.GetInt32("total_guesses");
                            int totalCorrect = reader.GetInt32("total_correct");
                            int bestGameScore = reader.GetInt32("best_game_score");
                            int bestGameID = reader.GetInt32("best_game_ID");
                            Player player = new Player(
                                playerID, firstName, lastName, userName, createdDate,
                                lastGamePlayed, lastGameID, totalScore, gamesPlayed,
                                totalGuesses, totalCorrect, bestGameScore, bestGameID);
                            playerList.Add(player);
                        }
                    }
                }
            }

            return playerList;
        }

        public Player GetPlayerById(int playerId)
        {
            string query = "SELECT * FROM players WHERE player_ID = @playerId";
            Player player = null;
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@playerId", playerId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32("player_ID");
                            string firstName = reader.GetString("first_name");
                            string lastName = reader.GetString("last_name");
                            string userName = reader.GetString("user_name");
                            DateTime createdDate = reader.GetDateTime("created_at");
                            DateTime lastGamePlayed = reader.GetDateTime("last_game_played");
                            int lastGameID = reader.GetInt32("last_game_ID");
                            int totalScore = reader.GetInt32("total_score");
                            int gamesPlayed = reader.GetInt32("games_played");
                            int totalGuesses = reader.GetInt32("total_guesses");
                            int totalCorrect = reader.GetInt32("total_correct");
                            int bestGameScore = reader.GetInt32("best_game_score");
                            int bestGameID = reader.GetInt32("best_game_ID");
                            player = new Player(id, firstName, lastName, userName, createdDate,
                                lastGamePlayed, lastGameID, totalScore, gamesPlayed,
                                totalGuesses, totalCorrect, bestGameScore, bestGameID);
                        }
                    }
                }
            }
            return player;
        }

        public void AddPlayer(Player player)
        {
            string query = "INSERT INTO players (first_name, last_name, user_name, created_at, last_game_played, last_game_ID, total_score, games_played, total_guesses, total_correct, best_game_score, best_game_ID) " +
                           "VALUES (@firstName, @lastName, @userName, @createdAt, @lastGamePlayed, @lastGameID, @totalScore, @gamesPlayed, @totalGuesses, @totalCorrect, @bestGameScore, @bestGameID)";
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@firstName", player.FirstName);
                    command.Parameters.AddWithValue("@lastName", player.LastName);
                    command.Parameters.AddWithValue("@userName", player.Username);
                    command.Parameters.AddWithValue("@createdAt", player.CreatedDate);
                    command.Parameters.AddWithValue("@lastGamePlayed", player.LastGamePlayed);
                    command.Parameters.AddWithValue("@lastGameID", player.LastGameID);
                    command.Parameters.AddWithValue("@totalScore", player.TotalScore);
                    command.Parameters.AddWithValue("@gamesPlayed", player.GamesPlayed);
                    command.Parameters.AddWithValue("@totalGuesses", player.TotalGuesses);
                    command.Parameters.AddWithValue("@totalCorrect", player.TotalCorrect);
                    command.Parameters.AddWithValue("@bestGameScore", player.BestGameScore);
                    command.Parameters.AddWithValue("@bestGameID", player.BestGameID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePlayer(Player player)
        {
            string query = "UPDATE players SET first_name = @firstName, last_name = @lastName, user_name = @userName, created_at = @createdAt, last_game_played = @lastGamePlayed, last_game_ID = @lastGameID, total_score = @totalScore, games_played = @gamesPlayed, total_guesses = @totalGuesses, total_correct = @totalCorrect, best_game_score = @bestGameScore, best_game_ID = @bestGameID WHERE player_ID = @playerID";
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@firstName", player.FirstName);
                    command.Parameters.AddWithValue("@lastName", player.LastName);
                    command.Parameters.AddWithValue("@userName", player.Username);
                    command.Parameters.AddWithValue("@createdAt", player.CreatedDate);
                    command.Parameters.AddWithValue("@lastGamePlayed", player.LastGamePlayed);
                    command.Parameters.AddWithValue("@lastGameID", player.LastGameID);
                    command.Parameters.AddWithValue("@totalScore", player.TotalScore);
                    command.Parameters.AddWithValue("@gamesPlayed", player.GamesPlayed);
                    command.Parameters.AddWithValue("@totalGuesses", player.TotalGuesses);
                    command.Parameters.AddWithValue("@totalCorrect", player.TotalCorrect);
                    command.Parameters.AddWithValue("@bestGameScore", player.BestGameScore);
                    command.Parameters.AddWithValue("@bestGameID", player.BestGameID);
                    command.Parameters.AddWithValue("@playerID", player.PlayerID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePlayer(int playerId)
        {
            string query = "DELETE FROM players WHERE player_ID = @playerID";
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@playerID", playerId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
