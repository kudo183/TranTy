using System.ComponentModel;
using TranTy.Dto;

namespace TranTy
{
    public sealed class Settings : INotifyPropertyChanged
    {
        private static readonly Settings _instance = new Settings();

        private Settings() { }

        public static Settings Instance
        {
            get { return _instance; }
        }

        private VersionDto _currentVersion = new VersionDto() { Ma = 1, Ten = "version 1", GhiChu = "test" };
        public VersionDto CurrentVersion
        {
            get { return _currentVersion; }
            set
            {
                if (_currentVersion == value)
                    return;

                _currentVersion = value;
                OnPropertyChanged("CurrentVersion");
                OnPropertyChanged("MainWindowTitle");
                OnPropertyChanged("IsSelectedVersion");
            }
        }

        public string MainWindowTitle
        {
            get
            {
                if (_currentVersion != null)
                    return string.Format("{0} ({1})", _currentVersion.Ten, _currentVersion.GhiChu);

                return TextManager.Text_MainWindow_Title;
            }
        }

        public bool IsSelectedVersion
        {
            get { return _currentVersion != null; }
        }

        private int _pageSize = 20;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (_pageSize == value)
                    return;

                _pageSize = value;
                OnPropertyChanged("PageSize");
            }
        }

        private double _fontSize = 16;
        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                if (_fontSize == value)
                    return;

                _fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
