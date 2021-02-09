using System;
using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Movies
{

    public partial class Movies_list : ContentPage
    {
        static String IMAGE_URL_BASE = "https://image.tmdb.org/t/p/w300";
        int counter=0;
        String dataString;

        public ICommand backCommand => new Command(backClicked);
        public ICommand nextCommand => new Command(nextClicked);
        public ICommand selectedCommand => new Command(selectedClicked);
        
        public Movies_list(String data)
        {

            BindingContext = this;
            InitializeComponent();
            dataString = data;

           var result = JObject.Parse(data)["results"];


            String url = IMAGE_URL_BASE + result[counter]["poster_path"];
            myImage.Source = new UriImageSource() {

                Uri = new Uri(url)
            };

        }

        private void backClicked()
        {

            try
            {
                var result = JObject.Parse(dataString)["results"];

                String url = IMAGE_URL_BASE + result[counter-1]["poster_path"];
                myImage.Source = new UriImageSource()
                {

                    Uri = new Uri(url)
                };
                counter--;

            }
            catch (Exception e) { }

        }


    
        private void nextClicked()
        {

            try
            {
                var result = JObject.Parse(dataString)["results"];

                String url = IMAGE_URL_BASE + result[counter+1]["poster_path"];
                myImage.Source = new UriImageSource()
                {

                    Uri = new Uri(url)
                };
                counter++;
            }catch(Exception e) { }

        }

        private void selectedClicked()
        {

            Navigation.PushAsync(new MoviesDetails(dataString,counter));
        }



    }


}

