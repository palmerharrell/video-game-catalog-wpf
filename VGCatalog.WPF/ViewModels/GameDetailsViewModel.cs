using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VGCatalog.WPF.Commands;

namespace VGCatalog.WPF.ViewModels
{
    public class GameDetailsViewModel : ViewModelBase
    {
        #region GAME PROPERTIES

        //TODO: Testing. This doesn't belong here 
        private bool _isSearching;
        public bool IsSearching
        {
            get
            {
                return _isSearching;
            }
            set
            {
                _isSearching = value;
                OnPropertyChanged(nameof(IsSearching));
                IsSearchingChanged?.Invoke();
            }
        }

        private string _title = "Super Mario Bros.";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _platform = "Nintendo Entertainment System";
        public string Platform
        {
            get
            {
                return _platform;
            }
            set
            {
                _platform = value;
                OnPropertyChanged(nameof(Platform));
            }
        }

        private string _releaseYear = 1985.ToString();
        public string ReleaseYear
        {
            get
            {
                return _releaseYear;
            }
            set
            {
                _releaseYear = value;
                OnPropertyChanged(nameof(ReleaseYear));
            }
        }

        private string _genre = "Platformer";
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        private string _developer = "Nintendo";
        public string Developer
        {
            get
            {
                return _developer;
            }
            set
            {
                _developer = value;
                OnPropertyChanged(nameof(Developer));
            }
        }

        private string _publisher = "Nintendo";
        public string Publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                _publisher = value;
                OnPropertyChanged(nameof(Publisher));
            }
        }

        private string _description = "Cartridge only, custom case";
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        #endregion

        #region IMAGE PROPERTIES
        private List<string> _gameImages;
        public IEnumerable<string> GameImages
        {
            get
            {
                return _gameImages;
            }
            set
            {
                _gameImages = (List<string>)value;
                SelectedImageIndex = 0;

                if (_gameImages.Count > 0)
                {
                    ImageSource = _gameImages[_selectedImageIndex];
                }
                OnPropertyChanged(nameof(GameImages));
            }
        }

        private int _selectedImageIndex = 0;
        public int SelectedImageIndex
        {
            get
            {
                return _selectedImageIndex;
            }
            set
            {
                _selectedImageIndex = value;

                OnPropertyChanged(nameof(SelectedImageIndex));

                if (_gameImages.Count > 0)
                {
                    ImageSource = _gameImages[_selectedImageIndex];
                }

                BackImageCommand.RaiseCanExecuteChanged();
                ForwardImageCommand.RaiseCanExecuteChanged();
            }
        }

        private string _imageSource;
        public string ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }
        #endregion

        #region COMMANDS
        public DelegateCommand BackImageCommand { get; }
        public DelegateCommand ForwardImageCommand { get; }
        public DelegateCommand TestSearchingOverlay { get; }
        #endregion

        public GameDetailsViewModel()
        {
            BackImageCommand = new DelegateCommand(GoBack, CanGoBack);
            ForwardImageCommand = new DelegateCommand(GoForward, CanGoForward);
            TestSearchingOverlay = new DelegateCommand(TestingOverlay, CanTestOverlay);

            GameImages = new List<string> { "/Images/SMB1.jpg", "/Images/SMBAndDH.jpg" };


        }

        private void GoBack()
        {
            if (SelectedImageIndex > 0)
            {
                SelectedImageIndex--;
            }
            else
            {
                SelectedImageIndex = 0;
            }
        }

        private bool CanGoBack()
        {
            return SelectedImageIndex > 0;
        }

        private void GoForward()
        {
            if (SelectedImageIndex < GameImages.Count() - 1)
            {
                SelectedImageIndex++;
            }
            else
            {
                SelectedImageIndex = GameImages.Count() - 1;
            }
        }

        private bool CanGoForward()
        {
            return SelectedImageIndex < GameImages.Count() - 1;
        }

        //TODO: Just testing. This may be useful when scanning to show the overlay. Not here though.
        public event Action IsSearchingChanged;
        private async void TestingOverlay()
        {
            IsSearching = true;
            OnPropertyChanged(nameof(IsSearching));

            await Task.Delay(5000);

            IsSearching = false;
            OnPropertyChanged(nameof(IsSearching));
        }

        private bool CanTestOverlay() //TODO: testing 
        {
            return true;
        }
    }
}
