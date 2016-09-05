using System;
using System.Windows;
using System.Windows.Controls;
using TranTy.Dto;
using TranTy.ViewModel;

namespace TranTy.View
{
    /// <summary>
    /// Interaction logic for VersionView.xaml
    /// </summary>
    public partial class VersionView : UserControl
    {
        public VersionViewModel ViewModel { get; set; }
        public VersionView()
        {
            InitializeComponent();
            Loaded += VersionView_Loaded;
            Unloaded += VersionView_Unloaded;

            ViewModel = new VersionViewModel();
        }

        private void VersionView_Unloaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("VersionView Unloaded");
            ViewModel.Unload();
        }

        private void VersionView_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("VersionView Loaded");
            var designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime == true)
            {
                return;
            }

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
                    break;
                case "btnSet":
                    Console.WriteLine("Set");
                    Settings.Instance.CurrentVersion = gridView.SelectedItem as VersionDto;
                    break;
            }
        }
    }
}
