using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Pizza1
{
	class ListViewDemoPage : ContentPage
	{
		string someText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\ntempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\nquis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\nconsequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\ncillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\nproident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

		class Pizza 
		{
			public Pizza()
			{
				this.Name = "Name";
				this.Description = "description";
				this.FavoriteColor = Color.Accent;
			}

			public Pizza(string name, string description, Color favoriteColor)
			{
				this.Name = name;
				this.Description = description;
				this.FavoriteColor = favoriteColor;
			}

			public string Name { private set; get; }

			public string Description { private set; get; }

			public Color FavoriteColor { private set; get; }
		};

		public ListViewDemoPage()
		{
			Title = "Pizza List";
			Label header = new Label
			{
				Text = "Pizza List",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			// Define some data.
			List<Pizza> people = new List<Pizza>
			{
				new Pizza("Margarita0", someText, Color.Aqua),
				new Pizza("Margarita1", someText, Color.Silver),
				// ...etc.,...
				new Pizza("Margarita2", someText, Color.Purple),
				new Pizza("Margarita3", someText, Color.Red),
				new Pizza("Margarita4", someText, Color.Fuchsia),
				new Pizza("Margarita5", someText, Color.Navy),
				// ...etc.,...
				new Pizza("Margarita6", someText, Color.Teal),
				new Pizza("Margarita7", someText, Color.Yellow)
			};

			// Create the ListView.
			ListView listView = new ListView
			{
				// Source of data items.
				ItemsSource = people,

				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for 
				//      each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate(() =>
					{
						// Create views with bindings for displaying each property.
						Label nameLabel = new Label();
						nameLabel.SetBinding(Label.TextProperty, "Name");
						//nameLabel.FontSize = 20; //не влезает

						Label descriptionLabel = new Label();
						descriptionLabel.SetBinding(Label.TextProperty, "Description");

						BoxView boxView = new BoxView();
						boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

						// Return an assembled ViewCell.
						var viewCell = new ViewCell
						{
							View = new StackLayout
							{
								Padding = new Thickness(0, 5),
								Orientation = StackOrientation.Horizontal,
								Children = 
								{
									boxView,
									new StackLayout
									{
										VerticalOptions = LayoutOptions.Center,
										Spacing = 0,
										Children = 
										{
											nameLabel,
											descriptionLabel
										}
										}
								}
								}
						};
						return viewCell;
					})
			};
			listView.ItemTapped += ListView_ItemTapped;



			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children = 
				{
					header,
					listView
				}
				};
		}

		void ListView_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			var list = new ListView ();
			list = (ListView)sender;
			//Object lMatr = new Object();
			//lMatr = list.SelectedItem;
			Pizza pizza = new Pizza ();
			pizza = (Pizza)list.SelectedItem;

			//Navigation.PushAsync (new PizzaCurrent (pizza.Name, pizza.FavoriteColor, pizza.Description), false);
		}

		/*
		async void OnNextPageButtonItemTapped (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new PizzaCurrent (), false);//false - чтобы не было анимации перехода
		}*/
	}
}