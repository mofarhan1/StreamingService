using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingModel.Models
{
    public class User : IEquatable<User>, IComparable<User>
    {
        public int ID { get; set; }
        public String UserName { get; set; }

        public List<Serie> Following { get; set; }



        public User()
        {

            this.Following = new List<Serie>();
        }

        public bool Equals(User other)
        {

            return this.UserName == other.UserName;


        }

        public int CompareTo(User other)
        {
            return this.UserName.GetHashCode() - UserName.GetHashCode();
        }
    }
}

