using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace VGCatalog.WPF.ViewModels
{
    public class GameListViewModel : ViewModelBase
    {
        public ICommand FilterClickCommand { get; }

        public bool SearchBoxHasValue => !string.IsNullOrWhiteSpace(_searchString);

        private string _searchString = string.Empty;
        public string SearchString
        {
            get
            {
                return _searchString;
            }
            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }

    }
}
