
using StreamingModel.Model;
using StreamingModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingModel.StreamingDatabase
{
    public class StreamingContext : DbContext
    {
        public StreamingContext() : base("name=StreamingDb")
        {

        }
        public DbSet<StreamingService> StreamingServices { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public List<StreamingService> GetAllStreamingServices() { return StreamingServices.ToList(); }
        public List<Serie> GetAllSeries() { return Series.ToList(); }

        public List<Movie> GetallMovies() { return Movies.ToList(); }
        public List<Genre> GetallGenre() { return Genres.ToList(); }

        public void AddStreamingService(StreamingService streamingService)
        {
            StreamingServices.Add(streamingService);
            SaveChanges();
        }
        public void AddGenre(Genre genres)
        {
            Genres.Add(genres);
            SaveChanges();
        }
        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
            SaveChanges();
        }

        public void AddSerie(Serie serie)
        {
            Series.Add(serie);
            SaveChanges();
        }

        public System.Data.Entity.DbSet<StreamingModel.Models.User> Users { get; set; }
    }
}
