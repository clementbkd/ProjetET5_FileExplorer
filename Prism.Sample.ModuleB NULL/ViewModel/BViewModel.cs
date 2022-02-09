using System.ComponentModel;

namespace Prism.Sample.ModuleB.ViewModel
{
    public class BViewModel : INotifyPropertyChanged
    {
        public BViewModel()
        {
            ModuleBContent = "Région B LeftRegion à gauche : contiendra l'explorateur de dossiers";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _moduleBContent;
        public string ModuleBContent
        {
            get => _moduleBContent;
            set
            {
                _moduleBContent = value;
                OnPropertyChanged(nameof(ModuleBContent));
            }
        }
    }
}
