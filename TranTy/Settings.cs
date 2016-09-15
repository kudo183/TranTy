using System.ComponentModel;
using System.Linq;
using TranTy.Dto;

namespace TranTy
{
    public sealed class Settings : INotifyPropertyChanged
    {
        private static readonly Settings _instance = new Settings();

        public static Settings Instance
        {
            get { return _instance; }
        }

        public void LoadSettings()
        {
            var version = Utils.ContextHelper.CreateContext().Versions.FirstOrDefault(
                p => p.Ma == Properties.Settings.Default.MaVersion);

            if (version != null)
            {
                _currentVersion = new VersionDto();
                _currentVersion.FromEntity(version);
            }

            _pageSize = Properties.Settings.Default.PageSize;
            _fontSize = Properties.Settings.Default.FontSize;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.PageSize = _pageSize;
            Properties.Settings.Default.FontSize = _fontSize;

            Properties.Settings.Default.MaVersion = Settings.Instance.CurrentVersion.Ma;
            Properties.Settings.Default.Save();
        }

        private VersionDto _currentVersion;
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
