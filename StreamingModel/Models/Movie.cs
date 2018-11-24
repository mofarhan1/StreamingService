using StreamingModel.Model;
using StreamingModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StreamingModel.StreamingDatabase;


namespace StreamingModel.Models
{

    /*
     * Filmens titel.
 Hvilken streamingtjeneste denne kan ses på.
 Hvornår den er tilgængelig fra og hvornår den er tilgængelig til.
 Hvem instruktøren er. 
      */
    public class Movie : IEquatable<Movie>, IComparable<Movie>
    {
        private StreamingContext db = new StreamingContext();
        public int ID { get; set; }
        public String Titel { get; set; }
        public String Instruktoer { get; set; }
        public DateTime Tilgaengelig_Fra { get; set; }
        public DateTime Tilgaengelig_Til { get; set; }

        public virtual StreamingService StreamingService { get; set; }
        public int StreamingId { get; set; }
        public virtual List<Genre> Genres { get; set; }

        public virtual List<Rating> Ratings { get; set; }

        public Movie()
        {
            this.Genres = new List<Genre>();
            this.Ratings = new List<Rating>();

        }



        public bool Equals(Movie other)
        {
            if (other != null)
            {
                return this.Titel == other.Titel;
            }
            return false;
        }

        public int CompareTo(Movie other)
        {
            if (other != null)
            {
                return this.Titel.GetHashCode() - other.Titel.GetHashCode();
            }
            return -1;

        }

        public void AddRating(Rating rating)
        {

            if (!Ratings.Contains(rating))
            {
                Ratings.Add(rating);
                db.SaveChanges();

            }









        }
        public int getAverageScore()
        {
            int sumscore = 0;

            foreach (Rating r in this.Ratings)
            {
                sumscore += r.Score;
            }
            if (sumscore == 0)
            {
                return -1;
            }


            return sumscore / this.Ratings.Count;
        }


        public int getMyScore(String userName)
        {


            foreach (Rating r in this.Ratings)
            {

                if (r.User.UserName == userName)
                {
                    return r.Score;
                }
            }
            return 0;

        }
        public bool getFollowing(String ID)
        {
            if (this is Serie)
            {

                foreach (Rating r in this.Ratings)
                {

                    if (r.User.ID+"" == ID)
                    {
                        return r.is_following;
                    }

                }





            }

            return false;
        }



    }


}