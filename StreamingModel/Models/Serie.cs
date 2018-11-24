using StreamingModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamingModel.Models;
using StreamingModel.StreamingDatabase;

namespace StreamingModel.Models
{
    public class Serie : Movie
    {

        public virtual List<Season> Seasons { get; set; }
     
        public StreamingContext db = new StreamingContext();



        public Serie()
        {
            this.Genres = new List<Genre>();
            this.Seasons = new List<Season>();
            this.StreamingService = new StreamingService();
         
        }

        public override string ToString()
        {
            return "hej jeg er en sere";
        }
     
    }
}
