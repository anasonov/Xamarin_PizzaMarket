using System;
using Xamarin.Forms;

namespace Pizza1
{
	public class PizzaMain : ContentPage
	{
		public PizzaMain ()
		{
			Content = new StackLayout {
				Children = {
					new Label {
						Text = "Maxim's Pizza!!!",
						FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center
					},
					/*
					new BoxView {
						Color = Color.Yellow,
						VerticalOptions = LayoutOptions.FillAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
					},*/

					new Image{
						//HorizontalOptions = 
						Source = ImageSource.FromFile ("PizzaMain.jpg"),
						//HeightRequest = 150
					},
					new Label {
						Text = "We make the most tasty pizza!",
						FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center
					}
				},
				//BackgroundColor = Color.White,
			};
			Title = "Main";
			Icon = "PizzaMain.jpg";//не работает
		}
	}
}