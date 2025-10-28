using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia_Tracker.Model;
using MySqlConnector;

namespace Trivia_Tracker.Helpers
{
    class ResponseQuery
    {
        public List<Response> getAllResponses()
        {
            string query = "SELECT * FROM responses";
            List<Response> responseList = new List<Response>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int responseID = reader.GetInt32("response_id");
                            int questionID = reader.GetInt32("question_id");
                            int playerID = reader.GetInt32("player_id");
                            string playerResponse = reader.GetString("player_answer");
                            bool isCorrect = reader.GetBoolean("is_correct");
                            bool isBonusUsed = reader.GetBoolean("is_bonus_used");

                            Response response = new Response(
                                responseID, questionID, playerResponse, isCorrect, playerID, isBonusUsed);
                            responseList.Add(response);
                        }
                    }
                }
            }

            return responseList;

        }

        public Response getResponseByID(int responseID)
        {
            string query = "SELECT * FROM responses WHERE response_id = @responseID";
            Response response = null;

            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("responseID", responseID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int questionID = reader.GetInt32("question_id");
                            int playerID = reader.GetInt32("player_id");
                            string playerResponse = reader.GetString("player_answer");
                            bool isCorrect = reader.GetBoolean("is_correct");
                            bool isBonusUsed = reader.GetBoolean("is_bonus_used");

                            response = new Response(responseID, questionID, playerResponse, isCorrect, playerID, isBonusUsed);
                        }
                    }
                }
            }

            return response;

        }

        public void addResponse(Response response)
        {
            string query = "INSERT INTO responses (question_id, player_id, player_answer, is_correct, is_bonus_used) " + 
                           "VALUES (@questionID, @playerID, @playerAnswer, @isCorrect, @isBonusUsed)";

            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@questionID", response.QuestionID);
                    command.Parameters.AddWithValue("playerID", response.PlayerID);
                    command.Parameters.AddWithValue("@playerAnswer", response.ResponseText);
                    command.Parameters.AddWithValue("@isCorrect", response.IsCorrect);
                    command.Parameters.AddWithValue("@isBonusUsed", response.BonusUsed);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
