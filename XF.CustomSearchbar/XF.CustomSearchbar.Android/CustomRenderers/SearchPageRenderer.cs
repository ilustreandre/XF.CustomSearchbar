using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Views.InputMethods;

using XF.CustomSearchbar.CustomRenderers;
using XF.CustomSearchbar.Droid.CustomRenderers;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using SearchView = Android.Support.V7.Widget.SearchView;

[assembly: ExportRenderer(typeof(SearchPage), typeof(SearchPageRenderer))]
namespace XF.CustomSearchbar.Droid.CustomRenderers
{
    public class SearchPageRenderer : PageRenderer
    {
        private SearchView _searchView;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
                return;

            if (e?.OldElement == null)
            {
                var contentPage = Element as ContentPage;
                contentPage.Appearing += (s, a) => HandlePageAppearing();
                contentPage.Disappearing += (s, a) => HandlePageDisappearing();
            }
        }

        private void HandlePageDisappearing()
        {
            if (_searchView != null)
            {
                _searchView.QueryTextChange += searchView_QueryTextChange;
                _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            }

            MainActivity.ToolBar?.Menu?.RemoveItem(Resource.Menu.searchmenu);
        }

        private void HandlePageAppearing()
        {
            if (MainActivity.ToolBar == null || Element == null)
                return;

            MainActivity.ToolBar.Title = Element.Title;
            MainActivity.ToolBar.InflateMenu(Resource.Menu.searchmenu);

            _searchView = MainActivity.ToolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();

            if (_searchView == null)
                return;

            _searchView.QueryTextChange += searchView_QueryTextChange;
            _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            _searchView.QueryHint = (Element as SearchPage)?.SearchPlaceHolderText;
            _searchView.ImeOptions = (int)ImeAction.Search;
            _searchView.InputType = (int)InputTypes.TextVariationFilter;
            _searchView.MaxWidth = int.MaxValue; // Hack to go full width - http://stackoverflow.com/questions/31456102/searchview-doesnt-expand-full-width
        }

        private void searchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            if (e == null)
                return;

            var searchPage = Element as SearchPage;
            if (searchPage == null)
                return;

            searchPage.SearchText = e.Query;
            e.Handled = true;
        }

        private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchPage = Element as SearchPage;
            if (searchPage == null)
                return;

            searchPage.SearchText = e?.NewText;
        }

        public SearchPageRenderer(Context context)
                : base(context)
        {
        }
    }
}