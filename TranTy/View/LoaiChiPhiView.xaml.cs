using System;
using System.Windows;
using System.Windows.Controls;
using TranTy.ViewModel;

namespace TranTy.View
{
    /// <summary>
    /// Interaction logic for LoaiChiPhiView.xaml
    /// </summary>
    public partial class LoaiChiPhiView : UserControl
    {
        public LoaiChiPhiViewModel ViewModel { get; set; }
        public LoaiChiPhiView()
        {
            InitializeComponent();

            var designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime == true)
            {
                return;
            }

            Loaded += VersionView_Loaded;
            Unloaded += VersionView_Unloaded;

            ViewModel = new LoaiChiPhiViewModel();
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
            }
        }
    }
}
