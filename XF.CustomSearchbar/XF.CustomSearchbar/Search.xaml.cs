using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF.CustomSearchbar.CustomRenderers;

namespace XF.CustomSearchbar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : SearchPage
    {
		public Search ()
		{
			InitializeComponent ();

            BindingContext = new ViewModels.SearchViewModel();
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            var item = (Models.Item)((ListView)sender).SelectedItem;

            Navigation.PushAsync(new Detail(item));

            ((ListView)sender).SelectedItem = null;
        }
    }
}