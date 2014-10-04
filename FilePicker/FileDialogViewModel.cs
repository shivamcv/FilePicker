using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FilePicker
{
  public  class FileDialogViewModel:INotifyPropertyChanged
    {
        private static readonly FileDialogViewModel instance = new FileDialogViewModel();

        private FileDialogViewModel() 
        {
            Drives = new ObservableCollection<DriveInfo>();
            Directories = new ObservableCollection<DirectoryInfo>();
            Files = new ObservableCollection<cvFileInfo>();
            Reset();

            
        }

        public static FileDialogViewModel Instance
           {
              get 
              {
                 return instance; 
              }
           }

        public ObservableCollection<DriveInfo> Drives { get; set; }

        public ObservableCollection<DirectoryInfo> Directories { get; set; }

        public ObservableCollection<cvFileInfo> Files { get; set; }


        private DriveInfo currentDrive;
        public DriveInfo CurrentDrive
        {
            get { return currentDrive; }
            set { currentDrive = value;
                  
                if(currentDrive != null)
                {
                    Directories.Clear();
                    LoadDirectoryList(CurrentDrive.RootDirectory);
                }
                  RaisePropertyChanged("CurrentDrive");
            }
        }

        private DirectoryInfo currentDirectory;
        public DirectoryInfo CurrentDirectory
        {
            get { return currentDirectory; }
            set
            {
                currentDirectory = value;
                RaisePropertyChanged("CurrentDirectory");
            }
        }
       

        private void LoadDirectoryList(DirectoryInfo directoryInfo)
        {

            var directoryList = directoryInfo.GetDirectories();
            fillCollection(Directories, directoryList, true);

            LoadFileList(directoryInfo);
        }

        private void LoadFileList(DirectoryInfo directoryInfo)
        {
            var fileList = directoryInfo.GetFiles().Select(p=> new cvFileInfo(){fileInfo = p});
            fillCollection(Files, fileList, true);
        }


        private void LoadDriveList()
        {
            var driveList = DriveInfo.GetDrives().Where(drive => drive.IsReady).ToList();
            fillCollection(Drives, driveList,true);
            CurrentDrive = Drives.FirstOrDefault();
        }

         
        public void Reset()
        {
            LoadDriveList();
        }


        private void fillCollection<T>(ObservableCollection<T> Drives, IEnumerable<T> driveList, bool shouldClear = false)
        {
            if (shouldClear)
                Drives.Clear();

            foreach (var item in driveList)
            {
                Drives.Add(item);
            }
        }
        

        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class cvFileInfo :INotifyPropertyChanged
    {
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;
             RaisePropertyChanged("IsSelected");
            }
        }

        public FileInfo fileInfo { get; set; }

        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
  public class RelayCommand : ICommand
  {
      #region Fields

      readonly Action<object> _execute;
      readonly Predicate<object> _canExecute;
      private RelayCommand selectAll;

      #endregion // Fields

      #region Constructors

      public RelayCommand(Action<object> execute)
          : this(execute, null)
      {
      }

      public RelayCommand(Action<object> execute, Predicate<object> canExecute)
      {
          if (execute == null)
              throw new ArgumentNullException("execute");

          _execute = execute;
          _canExecute = canExecute;
      }

      public RelayCommand(RelayCommand selectAll)
      {
          // TODO: Complete member initialization
          this.selectAll = selectAll;
      }
      #endregion // Constructors

      #region ICommand Members

      public bool CanExecute(object parameter)
      {
          return _canExecute == null ? true : _canExecute(parameter);
      }

      public event EventHandler CanExecuteChanged
      {
          add { CommandManager.RequerySuggested += value; }
          remove { CommandManager.RequerySuggested -= value; }
      }

      public void Execute(object parameter)
      {
          _execute(parameter);
      }

      #endregion // ICommand Members
  }
}
