using BlazorTestProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace BlazorTestProject.Dao
{
    public class UserDAO
    {
        static string connectionString = "Data Source=DESKTOP-3D3OK6O\\MSQL;Initial Catalog=contact;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public List<User> takeList()
        {
            List<User> people = new List<User>();
            try
            {
                connection.Open();
                string sqlExpression = string.Format("SELECT * FROM [User]");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader number = command.ExecuteReader();
                if (number.HasRows)
                {
                    while (number.Read())
                    {
                        User user = new User();
                        user.Id = number.GetInt32(0);
                        user.Name = number.GetString(1);
                        user.Number = number.GetString(2);
                        user.Email = number.GetString(3);
                        people.Add(user);
                    }
                }
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return people;
        }

        public void save(User contact)
        {
            string sqlExpression = String.Format("INSERT INTO [User] (Name, Number, Email) VALUES ('{0}', '{1}', '{2}')",
                contact.Name,contact.Number,contact.Email);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void remove(int id)
        {
            string sqlExpression = String.Format("DELETE FROM [User] WHERE id='{0}'",id);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public void updateContact(int id, User contact)
        {
            string sqlExpression = String.Format("UPDATE [User] set Name = '{1}', Number = '{2}', Email = '{3}' WHERE id = '{0}'",
                id, contact.Name, contact.Number, contact.Email);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<User> filtrate(String column, String parametr)
        {
            List<User> people = new List<User>();
            string sqlExpression = String.Format("SELECT * FROM [User] where {0} LIKE '%{1}%'",column,parametr);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader number = command.ExecuteReader();
                if (number.HasRows)
                {
                    while (number.Read())
                    {
                        User user = new User();
                        user.Name = number.GetString(1);
                        user.Number = number.GetString(2);
                        user.Email = number.GetString(3);
                        people.Add(user);
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return people;

        }
    }
}
