using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Movies
{
    public partial class MoviesDetails : ContentPage
    {
        static String IMAGE_URL_BASE = "https://image.tmdb.org/t/p/w300";

        public MoviesDetails(String data, int counter)
        {
            InitializeComponent();
            var result = JObject.Parse(data);

            String url = IMAGE_URL_BASE + result["results"][counter]["poster_path"];

            try
            {
                title_label.Text = result["results"][counter]["name"].ToString();

            }
            catch (Exception e)
            {
                title_label.Text = "No title provided";

            }

            try
            {
                vote_label.Text = result["results"][counter]["vote_average"].ToString();

            }
            catch (Exception e)
            {
                title_label.Text = "No votes";

            }

            try
            {
                year_label.Text = result["results"][counter]["first_air_date"].ToString();

            }
            catch (Exception e)
            {
                title_label.Text = "Not set";

            }

            try
            {
                details_label.Text = result["results"][counter]["overview"].ToString();

            }
            catch (Exception e)
            {
                title_label.Text = "Not set";

            }

            MovieImage.Source = new UriImageSource()
            {
                Uri = new Uri(url)
            };

        }
    }
}
