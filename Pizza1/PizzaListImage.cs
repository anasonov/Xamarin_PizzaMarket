using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Pizza1
{
	class PizzaListImage : ContentPage
	{
		//some text for fill Labels
		string someText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\ntempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\nquis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\nconsequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\ncillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\nproident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

		class PizzaIm
		{
			public PizzaIm()
			{
				this.Name = "Name";
				this.Description = "description";
				//this.FavoriteColor = Color.Accent;
				this.PizzaImageResource = "";
			}

			public PizzaIm(string name, string description, string pizzaImageResource)
			{
				this.Name = name;
				this.Description = description;
				this.PizzaImageResource = pizzaImageResource;
			}

			public string Name { private set; get; }

			public string Description { private set; get; }

			public Color FavoriteColor { private set; get; }

			public Image PizzaImage { private set; get; }

			public string PizzaImageResource { private set; get; }
		};

		public PizzaListImage()
		{
			Title = "Pizza List";
			Label header = new Label
			{
				Text = "Pizza List",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			// Define some data.
			List<PizzaIm> people = new List<PizzaIm>
			{
				new PizzaIm("Margarita0", someText, "Pizza01"),
				new PizzaIm("Margarita1", someText, "Pizza02"),
				// ...etc.,...
				new PizzaIm("Margarita2", someText, "Pizza03"),
				new PizzaIm("Margarita3", someText, "Pizza04"),
				new PizzaIm("Margarita4", someText, "Pizza03"),
				new PizzaIm("Margarita5", someText, "Pizza01"),
				// ...etc.,...
				new PizzaIm("Margarita6", someText, "Pizza02"),
				new PizzaIm("Margarita7", someText, "Pizza04"),
				new PizzaIm("Margarita8", someText, "Pizza03"),
				new PizzaIm("Margarita9", someText, "Pizza04")
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

						Image pizzaImage = new Image{WidthRequest = 60, HeightRequest = 60};//ничего не поменялось
						pizzaImage.SetBinding(Image.SourceProperty, "PizzaImageResource");

						// Return an assembled ViewCell.
						var viewCell = new ViewCell
						{
							View = new StackLayout
							{
								Padding = new Thickness(0, 5),
								Orientation = StackOrientation.Horizontal,
								Children = 
								{
									pizzaImage,
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
			PizzaIm pizza = new PizzaIm ();
			pizza = (PizzaIm)list.SelectedItem;

			Navigation.PushAsync (new PizzaCurrent (pizza.Name, pizza.PizzaImageResource, pizza.Description), false);
		}

		/*
		async void OnNextPageButtonItemTapped (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new PizzaCurrent (), false);//false - чтобы не было анимации перехода
		}*/
	}
}