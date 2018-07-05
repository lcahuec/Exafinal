using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExaFinal.Views;
using ExaFinal.Models;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ExaFinal
{
    

	public partial class App : Application
	{

        public static MasterDetailPage MasterD { get; set; }


        public App ()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

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

//Metodo que verifica si falla el login de facebook
        public static Action LoginFacebookFail
        {
            get
            {
                return new Action(() => Current.MainPage =
                                  new NavigationPage(new LoginPage()));
            }
        }

        public static void LoginFacebookSuccess(FacebookResponse profile)
        {
            Current.MainPage = new SpotifyPage();
        }
//fin Metodo que verifica si falla el login de facebook

    }
}
