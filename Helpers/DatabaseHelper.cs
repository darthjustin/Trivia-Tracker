using System;
using System.Diagnostics;
using MySqlConnector;

namespace Trivia_Tracker.Helpers
{
    public class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Port=3306;Database=trivia_tracker;User Id=root;Password=Homieg11!;";
        // This class will handle database connections and queries
        public static MySqlConnection GetConnection()
        {
            // Code to establish a connection to the database
            var connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Debug.WriteLine("Database connection established successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions related to database connection
                Debug.WriteLine("An error occurred while connecting to the database: " + ex.Message);
                throw; // Re-throw the exception for further handling if necessary
            }
                return connection;

        }
        public void ExecuteQuery(string query)
        {
            // Code to execute a query against the database
            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Query executed successfully: " + query);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while executing the query: " + ex.Message);
            }
        }
        public void CloseConnection()
        {
            // Code to close the database connection
            try
            {
                var connection = GetConnection();
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Debug.WriteLine("Database connection closed successfully.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while closing the database connection: " + ex.Message);
            }
        }

        // Additional methods for CRUD operations can be added here
    }
}
