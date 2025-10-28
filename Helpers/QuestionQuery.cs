using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia_Tracker.Model;
using MySqlConnector;

namespace Trivia_Tracker.Helpers
{
    class QuestionQuery
    {
        public List<Question> GetAllQuestions()
        {
            string query = "SELECT * FROM questions";
            List<Question> questionList = new List<Question>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int questionID = reader.GetInt32("question_id");
                            int gameID = reader.GetInt32("game_id");
                            int roundNum = reader.GetInt32("round_num");
                            string questionText = reader.GetString("question_text");
                            string category = reader.GetString("category");
                            string correctAnswer = reader.GetString("correct_answer");
                            string questionType = reader.GetString("question_type");
                            int pointValue = reader.GetInt32("point_value");

                            Question question = new Question(
                                questionID, gameID, roundNum, questionText, category,
                                correctAnswer, questionType, pointValue);
                            questionList.Add(question);

                        }
                    }
                }
            }
                return questionList;
        }
    }
}
