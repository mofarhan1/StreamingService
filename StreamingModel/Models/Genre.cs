using StreamingModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamingModel.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public virtual List<Movie> Movies { get; set; }
       public List<Serie> Series { get; set; }

        public Genre()
        {
            this.Series = new List<Serie>();
        }


    }
}