using System.Windows;

namespace TranTy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Settings.Instance.LoadSettings();

            InitializeComponent();
            
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Instance.SaveSettings();
        }
    }
}
