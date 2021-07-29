﻿using BlazorTestProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTestProject.Dao
{
    public class UserDAO
    {
        static string connectionString = "Data Source=DESKTOP-3D3OK6O\\MSQL;Initial Catalog=contact;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        private List<User> people = new List<User>();

        public List<User> takeList()
        {
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
            int index = 0;
            foreach (var user in people)
            {
                if (user.Id == id)
                {
                    break;
                }
                index++;
            }
            people[index] = (new User { Id = id, Name = contact.Name, Email = contact.Email, Number = contact.Number });
        }
    }
}