using System.ComponentModel;

namespace Prism.Sample.ModuleA.ViewModel
{
    public class AViewModel : INotifyPropertyChanged
    {
        public AViewModel()
        {
            ModuleAContent = "région A Ribbon Region : contiendra le nom du document/du dossier";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _moduleAContent;
        public string ModuleAContent
        {
            get => _moduleAContent;
            set
            {
                _moduleAContent = value;
                OnPropertyChanged(nameof(ModuleAContent));
            }
        }
    }
}
