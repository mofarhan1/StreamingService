using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingModel.Models
{
    public class Episode
    {
        public int ID { get; set; }
        public String EpisodeNummer { get; set; }
        public String Titel { get; set; }
        public int SeasonID { get; set; }
        public Season Season { get; set; }


    }
}
