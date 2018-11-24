using StreamingModel.Model;
using StreamingModel.Models;
using StreamingModel.StreamingDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static StreamingModel.Models.Genre;
using System.Windows;

namespace StreamingAdmin
{
    class Service
    {
        private StreamingContext db = new StreamingContext();


        internal void updateListViewStreamingServices(ListView lvDataBinding)
        {
            using (var db = new StreamingContext())
            {
                List<StreamingService> items = new List<StreamingService>();
                foreach (StreamingService el in db.GetAllStreamingServices())
                {
                    items.Add(el);
                    //MessageBox.Show(el.Name);
                }
                lvDataBinding.ItemsSource = items;

            }

        }
        internal void fillComboboxStreamingTjensterSerie( ComboBox comboboxStreamingtjenesterSeries)
        {
            using (var db = new StreamingContext())
            {

                List<StreamingService> items = new List<StreamingService>();
                foreach (StreamingService el in db.GetAllStreamingServices())
                {
                    items.Add(el);
                }


                comboboxStreamingtjenesterSeries.ItemsSource = items;

             

                comboboxStreamingtjenesterSeries.SelectedValuePath = "ID";

            }
        }

        internal void fillComboboxStreamingTjenster(ComboBox comboboxStreamingtjenester)
        {
            using (var db = new StreamingContext())
            {

                List<StreamingService> items = new List<StreamingService>();
                foreach (StreamingService el in db.GetAllStreamingServices())
                {
                    items.Add(el);
                }

              
                

                 comboboxStreamingtjenester.ItemsSource = items;

                comboboxStreamingtjenester.SelectedValuePath = "ID";
         

            }
        }
        internal void fillComboboxSeries(ComboBox comboboxSeries)
        {
            using (var db = new StreamingContext())
            {

                List<StreamingService> items = new List<StreamingService>();
                foreach (StreamingService el in db.GetAllStreamingServices())
                {
                    items.Add(el);
                }


                comboboxSeries.ItemsSource = items;


                comboboxSeries.SelectedValuePath = "ID";


               

            }
        }

        internal void fillDetailMovie(ListView listviewDetailMovie)
        {

            List<Movie> movies = new List<Movie>();

            foreach(Movie movie in db.GetallMovies())
            {
                movies.Add(movie);
            }

            listviewDetailMovie.ItemsSource = movies;
           
        }

        internal void fill_ListviewFilm(ListView listviewFilm)
        {
            using (var db = new StreamingContext())
            {
                List<Movie> items = new List<Movie>();
                foreach (Movie el in db.GetallMovies())
                {
                    items.Add(el);
                    //MessageBox.Show(el.Name);
                }
                listviewFilm.ItemsSource = items;

            }
        }

        public void addGenres()
        {

            using (var db = new StreamingContext())
            {
              
                db.SaveChanges();
                if (db.GetallGenre().Count <= 0 )
                {
                    Genre genre1 = new Genre { Name= "Drama"};
                    Genre genre2 = new Genre { Name = "Action" };
                    Genre genre3 = new Genre { Name = "Science fiction" };
                    Genre genre4 = new Genre { Name = "Documentar"};
                    Genre genre5 = new Genre { Name = "Komodie" };
                    db.AddGenre(genre1);
                    db.AddGenre(genre2);
                    db.AddGenre(genre3);
                    db.AddGenre(genre4);
                    db.AddGenre(genre5);
                    db.SaveChanges();
                }
                if(db.GetallGenre().Count > 5)
                {
                    db.Genres.RemoveRange(db.Genres.Where(a => a.Name == a.Name));
                    db.SaveChanges();
                }





            }
        }

        internal void addMovie(Movie movie)
        {

            using (var db = new StreamingContext())
            {
                db.Movies.Add(movie);
              // db.SaveChanges();
                


            }

        }

        internal void fill_ListviewSerie(ListView listviewSerie)
        {
            using (var db = new StreamingContext())
            {
                List<Serie> items = new List<Serie>();
                foreach (Serie el in db.GetAllSeries())
                {
                    items.Add(el);
                    //MessageBox.Show(el.Name);
                }
                listviewSerie.ItemsSource = items;

            }
        }
        

        public void fillGenre(ListBox comboboxGenreFilm, ListBox comboBoxGenreSerie)
        {

            using (var db = new StreamingContext())
            {

                List<Genre> items = new List<Genre>();
                foreach (Genre el in db.GetallGenre())
                {
                    items.Add(el);
                }
   comboBoxGenreSerie.ItemsSource = items;
                comboboxGenreFilm.ItemsSource = items;
             
                comboboxGenreFilm.SelectedIndex = 1;
                comboBoxGenreSerie.SelectedIndex = 1;



            }


        }

      

      
    }
}

