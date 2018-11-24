
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingModel.Models
{
    public class Rating : IEquatable<Rating>, IComparable<Rating>
    {
        public int ID { get; set; }
        public int Score { get; set; }
        public virtual User User { get; set; }

        public bool is_following { get; set; }
       
        public bool Equals(Rating other)
        {

            if (other.User != null)
            {
   return this.User.UserName == other.User.UserName;
            }
            return false;
             
            
            
        }

        public int CompareTo(Rating other)
        {
            if (other != null)
            {
                return this.User.UserName.GetHashCode() - other.User.UserName.GetHashCode();
            }
            return -1;

        }
        public override int GetHashCode()
        {
            return User.UserName.GetHashCode();
        }

      

       
    }
}
