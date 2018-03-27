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
	}
}