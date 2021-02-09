using System;
using System.Collections.Generic;
using System.Net.Http;

using Xamarin.Forms;

namespace Movies
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetMovies();
        }

        public async void GetMovies()
        {
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/trending/all/day?api_key=a09d5fdc2754ca0b5a63f9976c9c52e2"
))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();

                        Console.WriteLine("the data is " + myContent);

                        Navigation.PushModalAsync(new NavigationPage(new Movies_list(myContent)));

                    }

                }
            }
        }
    }
}
