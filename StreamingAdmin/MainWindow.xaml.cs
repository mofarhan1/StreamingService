using StreamingModel.Model;
using StreamingModel.Models;
using StreamingModel.StreamingDatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static StreamingModel.Models.Genre;

namespace StreamingAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Service service;
        private StreamingService _streamingService;
        private Movie _movie;
        private Movie _serie;
        private Season _season;
        private Episode _episode;
        private StreamingContext db;
        public MainWindow()
        {

            db = new StreamingContext();
            InitializeComponent();
            _streamingService = new StreamingService();
            _movie = new Movie();
            _serie = new Serie();
            _season = new Season();
            _episode = new Episode();


            stpMovie.DataContext = _movie;
            stpSerie.DataContext = _serie;


            DataContext = _streamingService;
            service = new Service();
            service.updateListViewStreamingServices(lvDataBinding);
            service.fillComboboxStreamingTjenster(comboboxStreamingtjenester);
            service.fillComboboxStreamingTjensterSerie(comboboxStreamingtjenesterSeries);


            service.addGenres();
            service.fillDetailMovie(listviewDetailMovie);
            service.fillGenre(listboxGenreFilm, listboxGenreTabSeries);
            service.fill_ListviewFilm(listviewFilm);
            service.fill_ListviewSerie(listviewSerie);

            // listviewSerieSeasonslist.ItemsSource = db.GetallSeasons();

            date_fra.DisplayDateStart = DateTime.Now.Date;
            date_til.DisplayDateStart = DateTime.Now.Date;
            //db.Movies.RemoveRange(db.Movies.Where(a => a.Titel == a.Titel));
            //db.Genres.RemoveRange(db.Genres.Where(a => a.Name == a.Name));
            //db.Users.RemoveRange(db.Users.Where(a => a.ID == a.ID));


            //db.StreamingServices.RemoveRange(db.StreamingServices.Where(a => a.Name == a.Name));
            //returns a single item.



            // db.SaveChanges();

            List<StreamingService> st = db.GetAllStreamingServices();

            // List<Genre> genres = db.GetallGenre();

            List<Movie> movies = db.GetallMovies();

            List<Serie> series = db.GetAllSeries();


          
            //db.SaveChanges();
            //List<Movie> moviesasas = db.GetallMovies();


            listviewDetailSerie.ItemsSource = series;
            //  listviewDetailEpisode.ItemsSource = db.GetAllEpisodes();




















        }
    public void onlistviewDetailEpisodeClicked(object sender, RoutedEventArgs e)
    {
        try
        {
            ListView listView = sender as ListView;
            if (((Episode)listView.SelectedItem) != null)
            {
                // Episode episode = db.Episodes.Find(((Episode)listView.SelectedItem).ID);
                //MessageBox.Show(episode.EpisodeNummer + " :" + episode.Titel);
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show("fejl" + ex.Message + " :" + ex.StackTrace);
        }

    }


    public void onlistviewDetailSeasonClicked(object sender, RoutedEventArgs e)
    {
        ListView listView = sender as ListView;
        //Season serie = db.Seasons.Find(((Season)listView.SelectedItem).ID);
        //listviewDetailEpisode.ItemsSource = serie.Episodes;
        //stpDetailSeason.DataContext = serie;

    }
    public void onDetailSerieSelctChange(object sender, RoutedEventArgs e)
    {
        ListView listView = sender as ListView;
        Serie serie = db.Series.Find(((Serie)listView.SelectedItem).ID);
        listviewDetailSeason.ItemsSource = serie.Seasons;

    }
    public void onDetailMovieSelctionChange(object sender, RoutedEventArgs e)
    {
        ListView listView = sender as ListView;
        int id = ((Movie)listView.SelectedItem).ID;
        Movie movie = db.Movies.Find(id);

        stpDetailMovie.DataContext = db.Movies.Find(((Movie)listView.SelectedItem).ID);
        var a = 2;



    }




    public void OnAddMovieCliked(object sender, RoutedEventArgs e)
    {
        _movie.StreamingId = (int)comboboxStreamingtjenester.SelectedValue;

        _movie.StreamingService = db.StreamingServices.Find(_movie.StreamingId);

        _movie.Tilgaengelig_Fra = date_fra.SelectedDate.Value;
        _movie.Tilgaengelig_Til = date_til.SelectedDate.Value;

        foreach (Genre g_listbox in listboxGenreFilm.SelectedItems)
        {

            foreach (Genre g_db in db.GetallGenre())
            {

                if (g_listbox.Name == g_db.Name)
                {
                    g_db.Movies.Add(_movie);
                    _movie.Genres.Add(g_db);

                }




            }

        }




        db.SaveChanges();
        db.Movies.Add(_movie);
        MessageBox.Show(_movie.Titel + "er tilføjet");




        service.fill_ListviewFilm(listviewFilm);


    }

    public void onCreateSerieClicked(object sender, RoutedEventArgs e)
    {
        int StreamingId = (int)comboboxStreamingtjenesterSeries.SelectedValue;
        // _serie.StreamingId = (int)comboboxStreamingtjenesterSeries.SelectedValue;

        _serie.StreamingService = db.StreamingServices.Find(StreamingId);
        _serie.Tilgaengelig_Fra = date_fra_serie.SelectedDate.Value;
        _serie.Tilgaengelig_Til = date_til_serie.SelectedDate.Value;

        foreach (Genre g_listbox in listboxGenreTabSeries.SelectedItems)
        {

            foreach (Genre g_db in db.GetallGenre())
            {

                if (g_listbox.Name == g_db.Name)
                {
                    //g_db.Series.Add(_serie);
                    //_serie.Genres.Add(g_db);

                }




            }

        }

        db.Movies.Add(_serie);
        db.SaveChanges();
        MessageBox.Show(_serie.Titel + "er tilføjet");
        service.fill_ListviewSerie(listviewSerie);


    }
    public void onSerieSelectedChange(object sender, RoutedEventArgs e)
    {
        ListView listView = sender as ListView;
        //comboboxSeries.SelectedValuePath = "ID";

        stpSeasons.DataContext = db.Series.Find(((Serie)listView.SelectedItem).ID);
        _season.SerieId = ((Serie)listView.SelectedItem).ID;





    }
    public void onCreateSeasonClicked(object sender, RoutedEventArgs e)
    {
        try
        {
            _season.Name = stpSeasonSeasonName.Text;
            _season.Serie = db.Series.Find(_season.SerieId);



            // db.Seasons.Add(_season);
            db.SaveChanges();
            MessageBox.Show(_season.Name + "er tilføjet");
            // listviewSerieSeasonslist.ItemsSource = db.GetallSeasons();
        }
        catch (Exception exception)
        {
            MessageBox.Show("vælg en Serie eller se " + exception.Message + ":" + exception.Source + ":" + exception.StackTrace);

        }


    }
    public void onSeasoneSelectedChange(object sender, RoutedEventArgs e)
    {
        ListView listView = sender as ListView;
        // stpEposode.DataContext = db.Seasons.Find(((Season)listView.SelectedItem).ID);
        _episode.SeasonID = ((Season)listView.SelectedItem).ID;
    }
    public void onCreateEpisodeClicked(object sender, RoutedEventArgs e)
    {

        try
        {
            _episode.Titel = stpEpisode_EpisodeTitel.Text;
            _episode.EpisodeNummer = stpEpisodeEpisodeNumber.Text;
            //  _episode.Season = db.Seasons.Find(_episode.SeasonID);
            //  db.Seasons.Find(_episode.SeasonID).Episodes.Add(_episode);


            // db.AddEpisode(_episode);
            MessageBox.Show(_episode.Titel + "is tilføjet ");
            db.SaveChanges();
        }
        catch (Exception exception)
        {
            MessageBox.Show("vælg en Sæson eller se " + exception.Message + ":" + exception.Source + ":" + exception.StackTrace);

        }





    }

    private void OnAddServiceCliked(object sender, RoutedEventArgs e)
    {

        using (var db = new StreamingContext())
        {

            db.AddStreamingService(_streamingService);
            db.SaveChanges();
            List<StreamingService> items = new List<StreamingService>();
            foreach (StreamingService el in db.GetAllStreamingServices())
            {
                items.Add(el);
            }
            lvDataBinding.ItemsSource = items;
            MessageBox.Show($"Der er oprettet en ny service med navn: {_streamingService.Name}");
            _streamingService = new StreamingService();
            DataContext = _streamingService;

        }
    }
    public void cmbSelectedChange(object sender, RoutedEventArgs e)
    {


    }




}
}

