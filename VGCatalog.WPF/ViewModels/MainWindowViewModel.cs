
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGCatalog.WPF.Commands;

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

        public bool IsSearching
        {
            get
            {
                return GameDetailsViewModel.IsSearching;
            }
        }

        public bool InFilterMode
        {
            get
            {
                return GameListViewModel.InFilterMode;
            }
        }

        //TODO: This is for testing. Will probably be derived from a collection of Games eventually.
        //      And maybe on a FilterViewModel, instead of here
        public List<string> FilterPlatforms => ["All", "Game Boy", "Game Boy Advance", "NES", "Nintendo 3DS", 
                                                "Nintendo 64", "Nintendo DS", "Nintendo Entertainment System", 
                                                "Nintendo GameCube", "Nintendo Switch", "PlayStation", "PlayStation 2", 
                                                "PlayStation 3", "Playstation 4", "Playstation 5", "PlayStation Portable", "SNES", 
                                                "Super Nintendo Entertainment System", "Wii", "Wii U", "Xbox", "Xbox 360", "Xbox One"];
        public List<string> FilterGenres => ["All", "Action & Adventure", "Adventure", "Compilation",
                                             "Platform", "Platformer", "Platformer / Shooter", "Puzzle", 
                                             "Racing", "Role-Playing (RPG)", "Role-Playing (RPG) / Strategy", 
                                             "RPG", "Shooter", "Shooter / Puzzle", "Simulator", "Sport", "Sports", "Strategy"];
        public List<string> FilterDevelopers => ["All", "BioWare", "Bluepoint Games", "Bungie", "Game Freak",
                                                 "Good-Feel", "Kojima Productions", "Level-5", "Media Molecule",
                                                 "Naughty Dog", "Nintendo", "none", "Playground Games",
                                                 "Polyphony Digital", "Rare", "Rockstar North", "SCE Japan Studio",
                                                 "Sega", "Sony", "Square", "Square Enix", "Ubisoft", "Valve", "Vanillaware"];
        public List<string> FilterPublishers => ["All", "Atlus", "Electronic Arts", "Konami", "Microsoft",
                                                 "Microsoft Game Studios", "Microsoft Studios", "Nintendo",
                                                 "Rockstar Games", "SCEA", "Sega", "Sony", "Sony Computer Entertainment",
                                                 "Sony Interactive Entertainment", "Square", "Square Enix", "Ubisoft", "Valve"];
        //TODO: End of test properties
        #endregion

        #region COMMANDS
        public DelegateCommand CloseFilter { get; }
        #endregion

        public MainWindowViewModel(GameListViewModel gameListViewModel, GameDetailsViewModel gameDetailsViewModel)
        {
            GameListViewModel = gameListViewModel;
            GameDetailsViewModel = gameDetailsViewModel;

            GameListViewModel.EnterFilterMode += GameListViewModel_EnterFilterMode;
            GameListViewModel.ClearDetailsForm += GameListViewModel_ClearDetailsForm;
            GameDetailsViewModel.IsSearchingChanged += GameDetailsViewModel_IsSearchingChanged;

            CloseFilter = new DelegateCommand(CloseGameFilter, CanCloseGameFilter);
        }

        private void CloseGameFilter()
        {
            GameListViewModel.InFilterMode = false;
            OnPropertyChanged(nameof(InFilterMode));
        }

        private bool CanCloseGameFilter()
        {
            return true; //TODO: Adjust as needed 
        }

        private void GameListViewModel_EnterFilterMode()
        {
            OnPropertyChanged(nameof(InFilterMode));
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

            //TODO: Also, one of these causes binding errors
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
