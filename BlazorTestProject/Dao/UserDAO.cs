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

        public List<User> takeListOfUser()
        {
            List<User> people = new List<User>();
            try
            {
                connection.Open();
                string sqlExpression = string.Format("SELECT * FROM [User] ORDER BY Name ASC");
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader selectRes = command.ExecuteReader();
                if (selectRes.HasRows)
                {
                    while (selectRes.Read())
                    {
                        User user = new User();
                        user.Id = selectRes.GetInt32(0);
                        user.Name = selectRes.GetString(1);
                        user.Number = selectRes.GetString(2);
                        user.Email = selectRes.GetString(3);
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

        public void saveUser(User contact)
        {
            string sqlExpression = "addContact";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = contact.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter numberParam = new SqlParameter
                {
                    ParameterName = "@number",
                    Value = contact.Number
                };
                command.Parameters.Add(numberParam);
                SqlParameter emailParam = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = contact.Email
                };
                command.Parameters.Add(emailParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void removeUser(int id)
        {
            string sqlExpression = "deleteContact";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        public void updateUser(User contact)
        {
            string sqlExpression = "updateContact";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = contact.Id
                };
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = contact.Name
                };
                SqlParameter numberParam = new SqlParameter
                {
                    ParameterName = "@number",
                    Value = contact.Number
                };
                SqlParameter emailParam = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = contact.Email
                };
                command.Parameters.Add(idParam);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(numberParam);
                command.Parameters.Add(emailParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<User> findUser(String column, String parametr)
        {
            List<User> people = new List<User>();
            string sqlExpression = String.Format("SELECT * FROM [User] where {0} LIKE '%{1}%' ORDER BY Name ASC", column, parametr);
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

        public User getUserForEditing(int id)
        {
            User contact = new User();
            try
            {
                connection.Open();
                string sqlExpression = string.Format("SELECT * FROM [User] WHERE id = {0}", id);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader selectRes = command.ExecuteReader();
                if (selectRes.HasRows)
                {
                    while (selectRes.Read())
                    {
                        contact.Id = selectRes.GetInt32(0);
                        contact.Name = selectRes.GetString(1);
                        contact.Number = selectRes.GetString(2);
                        contact.Email = selectRes.GetString(3);
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
            return contact;
        }
    }
}
