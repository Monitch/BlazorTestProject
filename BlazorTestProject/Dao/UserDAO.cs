using BlazorTestProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTestProject.Dao
{
    public class UserDAO
    {
        private int idIncrement;
        private List<User> people;
        public UserDAO()
        {
            people = new List<User>();
            people.Add(new User { Id = ++idIncrement, Name = "Vitaliy Monich", Email = "Monich@gmail.com", Number = "1111" });
            people.Add(new User { Id = ++idIncrement, Name = "Vasyl Luck", Email = "vlook@test.com", Number = "2222" });
            people.Add(new User { Id = ++idIncrement, Name = "Dovbaka Mukola", Email = "Azur@test.com", Number = "3333" });
            people.Add(new User { Id = ++idIncrement, Name = "Denis Vakar", Email = "vakarov@test.com", Number = "4444" });
        }
        public List<User> takeList()
        {
            return people;
        }
        public void save(User contact)
        {
            contact.Id = ++idIncrement;
            people.Add(contact);
        }
        public void remove(int id)
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
            people.RemoveAt(index);
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
