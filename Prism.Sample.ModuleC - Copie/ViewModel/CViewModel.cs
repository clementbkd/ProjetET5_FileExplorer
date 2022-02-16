using System.ComponentModel;

namespace Prism.Sample.ModuleC.ViewModel
{
    public class CViewModel : INotifyPropertyChanged
    {
        public CViewModel()
        {
            ModuleCContent = "Région principale C MainRegion : contiendra l'explorateur de fichier & visionnage PDF";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _moduleCContent;
        public string ModuleCContent
        {
            get => _moduleCContent;
            set
            {
                _moduleCContent = value;
                OnPropertyChanged(nameof(ModuleCContent));
            }
        }
    }
}

