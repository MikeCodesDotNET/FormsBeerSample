using System;

using Xamarin.Forms;
using BreweryDB.Models;

namespace FormsBeerSample.Pages
{
    public class SearchBeersPage : ContentPage
    {
        SearchBar searchBar;
        ListView listView;

        public SearchBeersPage()
        {

            Title = "Search";

            //TODO Add your BreweryDB Key 
            BreweryDB.BreweryDBClient.Initialize("", "SampleApp", 1);

            listView = new ListView();

            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, "Description");

            listView.ItemTemplate = cell;

            listView.ItemSelected += delegate
            {
                var beer = listView.SelectedItem as Beer;
                if(beer == null)
                    return;
                Navigation.PushAsync(new BeerDetails(beer));
                listView.SelectedItem = null;
            };

            searchBar = new SearchBar
            {
                Placeholder = "Search for beer"
            };

            searchBar.SearchButtonPressed += async delegate
            {
               var results =  await new BreweryDB.BreweryDBSearch<Beer>(searchBar.Text).Search();
               listView.ItemsSource = results;
            };

            Content = new StackLayout
            {
                Children = {searchBar, listView}
            };
        }
    }
}

