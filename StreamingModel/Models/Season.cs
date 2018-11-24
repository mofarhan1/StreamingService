using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingModel.Models
{
    public class Season
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public virtual List<Episode> Episodes { get; set; }
        public virtual Serie Serie { get; set; }
        public int SerieId { get; set; }


        public Season()
        {
            this.Episodes = new List<Episode>();
        }
    }
}
