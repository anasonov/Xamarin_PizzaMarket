using System;

using Xamarin.Forms;

namespace Pizza1
{
	public class App : Application
	{
		public App ()
		{
			//MainPage = new MainPageTP ();
			MainPage = new NavigationPage ( new MainPageTP() );
		}//TabbedPage

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

