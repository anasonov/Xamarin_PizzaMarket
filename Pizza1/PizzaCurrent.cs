using System;

using Xamarin.Forms;

namespace Pizza1
{
	public class PizzaCurrent : ContentPage
	{

		public PizzaCurrent ()//конструктор по-умолчанию
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "PizzaName" },
					new BoxView { Color = Color.Accent,
						WidthRequest = 150,
						HeightRequest = 150, },
					new ScrollView {
						Content = new Label { 
							Text = "Pizza Discription\n here..."
						}
					}
				}
			};
			//Title = "PizzaName";
		}


		//нормальный конструктор
		public PizzaCurrent (string name, string imResource, string discription)
		{
			var label = new Label { FontSize = 20 };
			var s = new FormattedString ();
			s.Spans.Add (new Span{ Text = "Discription", FontAttributes = FontAttributes.Bold, FontSize = 22, ForegroundColor = Color.Gray});
			s.Spans.Add (new Span{ Text = "\n"+discription });
			label.FormattedText = s;


			Content = new ScrollView {
				Content = new StackLayout {
					Orientation = StackOrientation.Vertical,
					Children = {
						new Image {
							Source = ImageSource.FromFile(imResource),
							Aspect = Aspect.AspectFill
							//HorizontalOptions = LayoutOptions.CenterAndExpand,
							//VerticalOptions = LayoutOptions.CenterAndExpand
						},
						label
					}
				}
			};
			Title = name;
		}//for creat new PizzaCurrentPage
	}
}


