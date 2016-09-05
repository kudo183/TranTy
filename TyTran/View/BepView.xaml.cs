using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TranTy.Entity;

namespace TranTy.View
{
    /// <summary>
    /// Interaction logic for BepView.xaml
    /// </summary>
    public partial class BepView : UserControl
    {
        public BepView()
        {
            InitializeComponent();
            Loaded += VersionView_Loaded;
            Unloaded += BepView_Unloaded;
        }

        void BepView_Unloaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("BepView Unloaded");
        }

        void VersionView_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("BepView Loaded");
            var designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime == true)
            {
                return;
            }

            var context = new TranTyContext();
            var sb = new StringBuilder();
            foreach (var bep in context.Beps)
            {
                sb.AppendLine(string.Format("{0} - {1} - {2}", bep.Ma, bep.Ten, bep.NgayTaoUtc));
            }
            txt.Text = sb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new TranTyContext();
            var b = new Bep() { Ten = "bep 1", NgayTaoUtc = DateTime.UtcNow };
            context.Beps.Add(b);
            context.SaveChanges();
            var sb = new StringBuilder();
            foreach (var bep in context.Beps)
            {
                sb.AppendLine(string.Format("{0} - {1} - {2}", bep.Ma, bep.Ten, bep.NgayTaoUtc));
            }
            txt.Text = sb.ToString();
        }
    }
}
