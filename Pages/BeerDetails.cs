using System;

using Xamarin.Forms;

namespace FormsBeerSample.Pages
{
    public class BeerDetails : ContentPage
    {
        Label name;
        Label description;
        Image image;

        public BeerDetails(BreweryDB.Models.Beer beer)
        {
            Title = beer.Name;

            name = new Label
            {
                Text = beer.Name,
                FontSize = 20,
            };

            description = new Label
            {
                Text = beer.Description,
                FontSize = 10
            };

            image = new Image
            {
                Source = beer.Labels.Medium
            };

            Content = new ScrollView
            {
                    Content = new StackLayout
                    {
                        Padding = 10,
                        Children = {image, name, description}
                    }
            };
        }
    }
}

