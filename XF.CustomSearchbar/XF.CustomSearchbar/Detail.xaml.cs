using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.CustomSearchbar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{
		public Detail (Models.Item item)
		{
			InitializeComponent ();

            MainStack.Children.Add(new Label()
            {
                Text = $"Text: {item.Text} - Detail: {item.Detail}" 
            });
        }
	}
}