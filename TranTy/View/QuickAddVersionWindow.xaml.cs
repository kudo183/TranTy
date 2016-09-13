using System;
using System.Windows;
using System.Windows.Controls;

namespace TranTy.View
{
    /// <summary>
    /// Interaction logic for QuickAddVersionWindow.xaml
    /// </summary>
    public partial class QuickAddVersionWindow : Window
    {
        public bool IsAdded { get; set; }
        public Dto.VersionDto AddedVersion { get; set; }

        public QuickAddVersionWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
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
                    using (var context = Utils.ContextHelper.CreateContext())
                    {
                        var version = context.Versions.Add(new Entity.Version()
                        {
                            Ten = txtTen.Text,
                            GhiChu = txtGhiChu.Text,
                            NgayTaoUtc = DateTime.UtcNow
                        });
                        context.SaveChanges();
                        var dto = new Dto.VersionDto();
                        dto.FromEntity(version);
                        AddedVersion = dto;
                    }
                    IsAdded = true;
                    Close();
                    break;
                case "btnCancel":
                    Console.WriteLine("Cancel");
                    Close();
                    break;
            }
        }
    }
}
