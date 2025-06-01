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

        private string _title;
        public string Title
        {
            get
            {
                //return _title;
                return "Super Mario Bros.";
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _platform;
        public string Platform
        {
            get
            {
                //return _platform;
                return "Nintendo Entertainment System";
            }
            set
            {
                _platform = value;
                OnPropertyChanged(nameof(Platform));
            }
        }

        private string _releaseYear;
        public string ReleaseYear
        {
            get
            {
                //return _releaseYear;
                return 1985.ToString();
            }
            set
            {
                _releaseYear = value;
                OnPropertyChanged(nameof(ReleaseYear));
            }
        }

        private string _genre;
        public string Genre
        {
            get
            {
                //return _genre;
                return "Platformer";
            }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        private string _developer;
        public string Developer
        {
            get
            {
                //return _developer;
                return "Nintendo";
            }
            set
            {
                _developer = value;
                OnPropertyChanged(nameof(Developer));
            }
        }

        private string _publisher;
        public string Publisher
        {
            get
            {
                //return _publisher;
                return "Nintendo";
            }
            set
            {
                _publisher = value;
                OnPropertyChanged(nameof(Publisher));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                //return _description;
                return "Cartridge only, custom case";
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
            private set
            {
                _gameImages = (List<string>)value;
                SelectedImageIndex = 0;
                ImageSource = _gameImages[_selectedImageIndex];
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
                ImageSource = _gameImages[_selectedImageIndex];

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
        #endregion

        public GameDetailsViewModel()
        {
            BackImageCommand = new DelegateCommand(GoBack, CanGoBack);
            ForwardImageCommand = new DelegateCommand(GoForward, CanGoForward);

            GameImages = new List<string> { "/Images/SMB1.jpg", "/Images/SMBAndDH.jpg", "/Images/BerriesAndCream.jpg" };


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
    }
}
