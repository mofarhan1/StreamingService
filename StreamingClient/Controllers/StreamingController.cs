using StreamingClient.ViewModels;
using StreamingModel.Model;
using StreamingModel.Models;
using StreamingModel.StreamingDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamingClient.Controllers
{
    public class StreamingController : Controller
    {
      
        private StreamingContext _db = new StreamingContext();


        [HttpPost]
        public ActionResult Index(User user)
        {
            
            foreach (StreamingService s in _db.GetAllStreamingServices())
            {
                foreach (User u in s.Users)
                {
                    if (u.UserName == user.UserName)
                    {
                      

                        Session["username"] = user.UserName;

                        return RedirectToAction("StreamingServices");

                    }
                }
            }

            return RedirectToAction("StreamingServices", "Streaming");

        }
        public ActionResult Index()
        {
            List<StreamingService> StreamingService = _db.GetAllStreamingServices();

            StreamingService St = _db.GetAllStreamingServices().FirstOrDefault<StreamingService>();
            _db.Entry(St).Collection(s => s.Users).Load();

            if (Session["username"] != null)
            {
                return RedirectToAction("StreamingServices","Streaming", new {username = Session["username"].ToString() });
            }
            return View();
        }

        public ActionResult StreamingServices()
        {

            return View(_db.GetAllStreamingServices());
        }


        public ActionResult Movies(int id)
        {
            // _db.Ratings.RemoveRange(_db.Ratings.Where(a => a.ID == a.ID));
            //_db.SaveChanges();

            var service = _db.StreamingServices.Find(id);
            _db.Entry(service).Collection(s => s.Movies).Load();
            Movie movie = _db.GetallMovies().FirstOrDefault<Movie>();
            _db.Entry(movie).Collection(m => m.Ratings).Load();
            return View(service);
        }
        public ActionResult MovieDetail(int id)
        {
            var movie = _db.Movies.Find(id);
            var rating = _db.Movies.Find(id).Ratings.FirstOrDefault<Rating>();
            _db.Entry(movie).Collection(s => s.Ratings).Load();
            _db.Entry(movie).Collection(s => s.Ratings).Load();



            return View(_db.Movies.Find(id));
        }
        public ActionResult RateMovie(int id)
        {



            RatingViewModel ratingViewModel = new RatingViewModel();

            ratingViewModel.MOvie = _db.Movies.Find(id);

            return View(ratingViewModel);
        }



        [HttpPost]
        public ActionResult RateMovie(RatingViewModel ratingViewModel)
        {
          
          Rating rating = new Rating();
            List<StreamingService> st = _db.GetAllStreamingServices();
            foreach (StreamingService s in st)
            {

                foreach (User u in s.Users)
                {

                    if (u.UserName== Session["username"].ToString())
                    {
                        rating.User = u;
                        _db.Entry(_db.Movies.Find(ratingViewModel.MOvie.ID)).Collection(m => m.Ratings).Load();


                        if (_db.Movies.Find(ratingViewModel.MOvie.ID) is Serie)
                        {
                            rating.is_following = ratingViewModel.is_following;
                            _db.Movies.Find(ratingViewModel.MOvie.ID).AddRating(rating);


                            _db.SaveChanges();


                        }
                        else
                        {

                            rating.Score = ratingViewModel.Rating.Score;
                            Movie movie = _db.Movies.Find(ratingViewModel.MOvie.ID);

                            movie.AddRating(rating);



                            _db.SaveChanges();

                        }


                    }
                }
            }



            return RedirectToAction("Movies", new { Id = _db.Movies.Find(ratingViewModel.MOvie.ID).StreamingId });
        }
    }
}