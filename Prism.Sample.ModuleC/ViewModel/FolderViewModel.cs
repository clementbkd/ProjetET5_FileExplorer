using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace FileBrowser
{
    public class FolderViewModel : ViewModelBase
    {
        private bool _isSelected;
        private bool _isExpanded;
        private string _folderIcon;

        public BrowserViewModel Root
        {
            get;
            set;
        }

        public string FolderIcon
        {
            get
            {
                return _folderIcon;
            }
            set
            {
                _folderIcon = value;
                OnPropertyChanged("FolderIcon");
            }
        }

        public string FolderName
        {
            get;
            set;
        }

        public string FolderPath
        {
            get;
            set;
        }

        public ObservableCollection<FolderViewModel> Folders
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;

                    OnPropertyChanged("IsSelected");

                    //IsExpanded = true; //Default windows behaviour of expanding the selected folder
                }
            }
        }

        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;

                    OnPropertyChanged("IsExpanded");
                    if (this.FolderName.Contains(".pdf"))
                        GlobalRegion.handle.Activate(GlobalRegion.handle.Views.ElementAt(1));
                    //LANCER PDF SI POSSIBLE

                    /*
                    if (!FolderName.Contains(':'))//Folder icon change not applicable for drive(s)
                    {
                        if (_isExpanded)
                            FolderIcon = "/Images\\FolderOpen.ico";
                        else
                            FolderIcon = "/Images\\FolderClosed.ico";
                    }
                    */
                    LoadFolders();
                }

            }
        }

        private void LoadFolders()
        {
            try
            {
                if (Folders.Count > 0)
                    return;

                string[] files = null;
                //FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //FolderName = Environment.SpecialFolder.Desktop.ToString();

                string fullPath = Path.Combine(FolderPath, FolderName);

                if (FolderName.Contains(':'))//This is a drive
                    fullPath = string.Concat(FolderName, "\\");
                else
                    fullPath = FolderPath;

                files = Directory.GetFiles(fullPath);

                Folders.Clear();

                foreach (string file in files)
                {
                    string Icon = "/Images\\FolderClosed.ico";
                    if (Path.GetFileName(file).Contains(".pdf"))
                    {
                        Icon = "/Images\\Adobe.ico";
                        Folders.Add(new FolderViewModel { Root = this.Root, FolderName = Path.GetFileName(file), FolderPath = Path.GetFullPath(file), FolderIcon = Icon });

                    }
                    if (Path.GetFileName(file).Contains(".doc") || Path.GetFileName(file).Contains(".docx") || Path.GetFileName(file).Contains(".xlsx") || Path.GetFileName(file).Contains(".odt"))
                    {
                        Icon = "/Images\\Documents.ico";
                        Folders.Add(new FolderViewModel { Root = this.Root, FolderName = Path.GetFileName(file), FolderPath = Path.GetFullPath(file), FolderIcon = Icon });

                    }
                    if (Path.GetFileName(file).Contains(".jpeg") || Path.GetFileName(file).Contains(".png") || Path.GetFileName(file).Contains(".jpeg"))
                    {

                        Icon = "/Images\\Photos.ico";
                        Folders.Add(new FolderViewModel { Root = this.Root, FolderName = Path.GetFileName(file), FolderPath = Path.GetFullPath(file), FolderIcon = Icon });

                    }
                    if (Path.GetFileName(file).Contains(".mp4") || Path.GetFileName(file).Contains(".webm"))
                    {
                        Icon = "/Images\\Videos.ico";
                        Folders.Add(new FolderViewModel { Root = this.Root, FolderName = Path.GetFileName(file), FolderPath = Path.GetFullPath(file), FolderIcon = Icon });
                    }
                }

                if (FolderName.Contains(":"))
                    FolderIcon = "/Images\\HardDisk.ico";


                Root.SelectedFolder = FolderPath;
            }
            catch (UnauthorizedAccessException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (IOException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

        public FolderViewModel()
        {
            Folders = new ObservableCollection<FolderViewModel>();
            //Folders.Add(new FolderViewModel { Root = this, FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),  FolderName = Environment.SpecialFolder.Desktop.ToString(), FolderIcon = "/Images\\HardDisk.ico" });

        }
    }
}
