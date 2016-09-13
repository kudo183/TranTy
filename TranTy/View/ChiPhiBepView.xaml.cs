using System;
using System.Windows;
using System.Windows.Controls;
using TranTy.Dto;
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

            VersionChooserWindow v;
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
                case "btnAddVersion":
                    Console.WriteLine("Add Version");
                    var q = new QuickAddVersionWindow();
                    q.ShowDialog();
                    if (q.IsAdded == true)
                    {
                        var maVersion = Settings.Instance.CurrentVersion.Ma;
                        Settings.Instance.CurrentVersion = q.AddedVersion;
                        ViewModel.ImportFromVersion(maVersion);
                    }
                    break;
                case "btnSetVersion":
                    Console.WriteLine("Set Version");
                    v = new VersionChooserWindow();
                    v.ShowDialog();
                    if (v.IsSelected)
                    {
                        Settings.Instance.CurrentVersion = v.SelectedVersion as VersionDto;
                        ViewModel.Load();
                    }
                    break;
                case "btnImportFromExcel":
                    Console.WriteLine("btnImportFromExcel");
                    var ofd = new Microsoft.Win32.OpenFileDialog();
                    ofd.Filter = "Excel File (*.xlsx)|*.xlsx";
                    if (ofd.ShowDialog() == true)
                    {
                        var msg = string.Format(TextManager.Text_ChiPhiBepView_Msg_Import_FromExcel_Confirm, ofd.FileName);
                        if (MessageBox.Show(msg, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            var data = ExcelReadWrite.ExcelReader.Read(ofd.FileName);

                            ViewModel.Import(data);
                        }
                    }
                    break;
                case "btnImportFromVersion":
                    Console.WriteLine("btnImportFromVersion");
                    v = new VersionChooserWindow();
                    v.ShowDialog();
                    if (v.IsSelected)
                    {
                        var msg = string.Format(
                            TextManager.Text_ChiPhiBepView_Msg_Import_FromVersion_Confirm, v.SelectedVersion.ToShortString());
                        if (MessageBox.Show(msg, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            ViewModel.ImportFromVersion(v.SelectedVersion.Ma);
                        }
                    }
                    break;
            }
        }
    }
}
