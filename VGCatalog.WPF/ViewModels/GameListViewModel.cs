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
        #endregion

        #region COMMANDS
        public DelegateCommand FilterClickCommand { get; } //TODO: This may need to be a different command type later
        public DelegateCommand EnterAddMode { get; }
        #endregion

        public event Action ClearDetailsForm;

        public GameListViewModel()
        {
            EnterAddMode = new DelegateCommand(PrepareToAddGame, CanEnterAddMode);
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

    }
}
