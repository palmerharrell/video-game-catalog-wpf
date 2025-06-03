using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using VGCatalog.WPF.Commands;

namespace VGCatalog.WPF.ViewModels
{
    public class GameListViewModel : ViewModelBase
    {
        #region PROPERTIES
        public bool SearchBoxHasValue => !string.IsNullOrWhiteSpace(_searchString);

        public bool NotInScanMode => !InScanMode;

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

        private int _selectedGameIndex;
        public int SelectedGameIndex
        {
            get
            {
                return _selectedGameIndex;
            }
            set
            {
                _selectedGameIndex = value;
                OnPropertyChanged(nameof(SelectedGameIndex));
            }
        }

        private bool _inScanMode;
        public bool InScanMode
        {
            get
            {
                return _inScanMode;
            }
            set
            {
                _inScanMode = value;
                OnPropertyChanged(nameof(InScanMode));
                OnPropertyChanged(nameof(NotInScanMode));
            }
        }

        private bool _inFilterMode;
        public bool InFilterMode
        {
            get
            {
                return _inFilterMode;
            }
            set
            {
                _inFilterMode = value;
                OnPropertyChanged(nameof(InFilterMode));
            }
        }
        #endregion

        #region COMMANDS
        public DelegateCommand FilterClickCommand { get; }
        public DelegateCommand EnterAddMode { get; }
        #endregion

        public event Action ClearDetailsForm;
        public event Action EnterFilterMode;

        public GameListViewModel()
        {
            EnterAddMode = new DelegateCommand(PrepareToAddGame, CanEnterAddMode);
            FilterClickCommand = new DelegateCommand(ShowGameFilter, CanShowGameFilter);
        }

        private void PrepareToAddGame()
        {
            SelectedGameIndex = -1;
            ClearDetailsForm?.Invoke();
        }

        private bool CanEnterAddMode()
        {
            return !InScanMode; //TODO: May need to distinguish between "Add Mode" & "Scan Mode",
                                //      since these CanExecute methods control enable/disable too.
        }

        private void ShowGameFilter()
        {
            InFilterMode = true;
            EnterFilterMode?.Invoke();
        }

        private bool CanShowGameFilter()
        {
            return true; //TODO: Adjust if needed
        }
    }
}
