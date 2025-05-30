using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGCatalog.WPF.ViewModels
{
    public class GameDetailsViewModel : ViewModelBase
    {
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
    }
}
