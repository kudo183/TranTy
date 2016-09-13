using System;
using System.Windows;
using System.Windows.Controls;
using TranTy.Dto;
using TranTy.ViewModel;

namespace TranTy.View
{
    /// <summary>
    /// Interaction logic for VersionChooserView.xaml
    /// </summary>
    public partial class VersionChooserWindow : Window
    {
        public VersionViewModel ViewModel { get; set; }
        public VersionDto SelectedVersion { get { return gridView.SelectedItem as VersionDto; } }

        public bool IsSelected { get; set; }

        public VersionChooserWindow()
        {
            InitializeComponent();

            var designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime == true)
            {
                return;
            }

            Loaded += VersionChooserWindow_Loaded;
            Unloaded += VersionChooserWindow_Unloaded;

            ViewModel = new VersionViewModel();
        }

        private void VersionChooserWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("VersionChooserWindow Unloaded");
            ViewModel.Unload();
        }

        private void VersionChooserWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("VersionChooserWindow Loaded");

            ViewModel.Load();

            DataContext = ViewModel;
        }

        private void gridView_Click(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;
            if (button == null)
                return;

            if (button.Tag == null)
                return;

            var buttonName = button.Tag.ToString();
            switch (buttonName)
            {
                case "btnOk":
                    Console.WriteLine("Ok");
                    if (SelectedVersion.Ma == Settings.Instance.CurrentVersion.Ma)
                    {
                        MessageBox.Show(TextManager.Text_ChiPhiBepView_Msg_Import_FromVersion_SameVersion);
                    }
                    else
                    {
                        IsSelected = true;
                        Close();
                    }
                    break;
                case "btnCancel":
                    Console.WriteLine("Cancel");
                    IsSelected = false;
                    Close();
                    break;
            }
        }
    }
}
