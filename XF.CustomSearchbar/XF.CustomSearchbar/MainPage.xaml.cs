using System;

using Xamarin.Forms;

namespace XF.CustomSearchbar
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Search_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Search());
        }
    }
}
