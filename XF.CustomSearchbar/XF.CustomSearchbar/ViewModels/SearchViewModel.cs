using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace XF.CustomSearchbar.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        #region Properties

        private IEnumerable<Models.Item> ListOriginal;

        private IEnumerable<Models.Item> _list;
        public IEnumerable<Models.Item> List
        {
            get
            {
                return _list;
            }

            set
            {
                _list = value;
                OnPropertyChanged();
            }
        }

        private string _textSearch;
        public string TextSearch
        {
            get
            {
                return _textSearch;
            }

            set
            {
                _textSearch = value;
                OnPropertyChanged();

                Filter();
            }
        }

        #endregion

        public SearchViewModel()
        {
            _list = new ObservableCollection<Models.Item>()
            {
                new Models.Item { Text = "Mesa", Detail = "2m x 1.4m" },
                new Models.Item { Text = "Cadeira", Detail = "Madeira maciça" },
                new Models.Item { Text = "Geladeira", Detail = "Frost Free" },
                new Models.Item { Text = "Pia de Marmore", Detail = "-" },
                new Models.Item { Text = "Pia de Inox", Detail = "-" }
            };

            ListOriginal = _list;
        }

        public ICommand SearchCommand { get; private set; }

        private void Filter()
        {
            var newList = ListOriginal;
            List = (!string.IsNullOrWhiteSpace(_textSearch))
                        ? newList.Where(l => l.Text.ToLower().Contains(_textSearch.ToLower())).ToList<Models.Item>()
                        : List = ListOriginal;
        }
    }
}
