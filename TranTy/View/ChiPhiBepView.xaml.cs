using System;
using System.Windows;
using System.Windows.Controls;
using TranTy.ViewModel;

namespace TranTy.View
{
    /// <summary>
    /// Interaction logic for ChiPhiBepView.xaml
    /// </summary>
    public partial class ChiPhiBepView : UserControl
    {
        public ChiPhiBepViewModel ViewModel { get; set; }
        public ChiPhiBepView()
        {
            InitializeComponent();

            var designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime == true)
            {
                return;
            }

            Loaded += VersionView_Loaded;
            Unloaded += VersionView_Unloaded;

            ViewModel = new ChiPhiBepViewModel();
        }

        private void VersionView_Unloaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("VersionView Unloaded");
            ViewModel.Unload();
        }

        private void VersionView_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("VersionView Loaded");

            ViewModel.Load();

            DataContext = ViewModel;
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;
            if (button == null)
                return;

            if (button.Tag == null)
                return;

            var buttonName = button.Tag.ToString();
            switch (buttonName)
            {
                case "btnSave":
                    Console.WriteLine("Save");
                    ViewModel.Save();
                    break;
                case "btnCancel":
                    Console.WriteLine("Cancel");
                    ViewModel.Load();
                    break;
                case "btnImport":
                    var ofd = new Microsoft.Win32.OpenFileDialog(); ofd.ShowReadOnly = true;
                    ofd.Filter = "Excel File (*.xlsx)|*.xlsx";
                    if (ofd.ShowDialog() == true)
                    {
                        if (MessageBox.Show(TextManager.Text_ChiPhiBepView_Msg_Import_Confirm, "", MessageBoxButton.YesNo)
                            == MessageBoxResult.Yes)
                        {
                            var data = ExcelReadWrite.ExcelReader.Read(ofd.FileName);
                            
                            ViewModel.Import(data);
                        }
                    }
                    Console.WriteLine("Import");
                    break;
            }
        }
    }
}
