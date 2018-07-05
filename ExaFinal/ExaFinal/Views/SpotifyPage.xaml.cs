using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaFinal.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExaFinal.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpotifyPage : ContentPage
	{
		public SpotifyPage ()
		{
			InitializeComponent ();
		}

        private void artista_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ArtistaPage());
        }
        private void play_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new PlaylistPage());
        }
        private void albun_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new AlbunPage());
        }
        private void track_Click(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Track());
        }


    }
}