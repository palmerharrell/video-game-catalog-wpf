
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

            GameDetailsViewModel.IsSearchingChanged += GameDetailsViewModel_IsSearchingChanged;
        }

        private void GameDetailsViewModel_IsSearchingChanged()
        {
            OnPropertyChanged(nameof(IsSearching));
        }
    }
}
