using System;
using Xamarin.Forms;

namespace Pizza1
{
	public class MainPageTP : TabbedPage
	{
		public MainPageTP ()
		{
			Title = "Maxim's pizza";
			Children.Add (new PizzaMain());//PizzaHomePage
			//Children.Add (new ListViewDemoPage ());//PizzaListView работает!
			Children.Add (new PizzaListImage());
			//Children.Add (new NavigationPage ( new ListViewDemoPage ()));//начало навигации
		}
	}
}

