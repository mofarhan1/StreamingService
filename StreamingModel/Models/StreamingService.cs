using StreamingModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamingModel.StreamingDatabase;


namespace StreamingModel.Model
{

    public class StreamingService
    {
        public StreamingContext db = new StreamingContext();
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Movie> Movies { get; set; }
        public int StreamingId { get; set; }
        public StreamingService()
        {
            this.Users = new List<User>();
        }

        public override string ToString()
        {
            return this.Name;

        }
        public void AddUser(User user)
        {

            if (!Users.Contains(user))
            {
                Users.Add(user);
                db.SaveChanges();
            }
            

        }
        public User GetUser(String Username)
        {
            foreach(User u in this.Users)
            {
                if (u.UserName == Username)
                {
                    return u;
                }
            }
            return null;
        }

    }



   

}
