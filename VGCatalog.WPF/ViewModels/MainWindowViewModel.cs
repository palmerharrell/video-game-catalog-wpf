
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGCatalog.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region PROPERTIES
        private GameListViewModel _gameListViewModel;
        public GameListViewModel GameListViewModel
        {
            get
            {
                return _gameListViewModel;
            }
            set
            {
                _gameListViewModel = value;
                OnPropertyChanged(nameof(GameListViewModel));
            }
        }

        private GameDetailsViewModel _gameDetailsViewModel;
        public GameDetailsViewModel GameDetailsViewModel
        {
            get
            {
                return _gameDetailsViewModel;
            }
            set
            {
                _gameDetailsViewModel = value;
                OnPropertyChanged(nameof(GameDetailsViewModel));
            }
        }

        private bool _isSearching;
        public bool IsSearching
        {
            get
            {
                return GameDetailsViewModel.IsSearching;
            }
        }
        #endregion

        public MainWindowViewModel(GameListViewModel gameListViewModel, GameDetailsViewModel gameDetailsViewModel)
        {
            GameListViewModel = gameListViewModel;
            GameDetailsViewModel = gameDetailsViewModel;

            GameListViewModel.ClearDetailsForm += GameListViewModel_ClearDetailsForm;
            GameDetailsViewModel.IsSearchingChanged += GameDetailsViewModel_IsSearchingChanged;
        }

        private void GameListViewModel_ClearDetailsForm()
        {
            //TODO: Probably not this
            GameDetailsViewModel.Title = string.Empty;
            GameDetailsViewModel.Platform = string.Empty;
            GameDetailsViewModel.ReleaseYear = string.Empty;
            GameDetailsViewModel.Genre = string.Empty;
            GameDetailsViewModel.Developer = string.Empty;
            GameDetailsViewModel.Publisher = string.Empty;
            GameDetailsViewModel.Description = string.Empty;

            GameDetailsViewModel.GameImages = new List<string>();
            GameDetailsViewModel.SelectedImageIndex = 0;
            GameDetailsViewModel.ImageSource = string.Empty;
        }

        private void GameDetailsViewModel_IsSearchingChanged()
        {
            OnPropertyChanged(nameof(IsSearching));
        }
    }
}
