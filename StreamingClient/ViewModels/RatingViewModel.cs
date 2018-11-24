using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StreamingModel.Models;

namespace StreamingClient.ViewModels
{
    public class RatingViewModel
    {
        public Rating Rating { get; set; }
      public Movie MOvie { get; set; }
        public bool is_following { get; set; }


    }
}