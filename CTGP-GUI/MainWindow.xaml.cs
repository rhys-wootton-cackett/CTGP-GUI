using System;
using System.Collections;
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

namespace CTGP_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the specific page dependent on answers.
            FrmMain.Source = FrmMain.Content.GetType().Name switch
            {
                "Welcome" => new Uri("Pages/LicenseAgreement.xaml", UriKind.Relative),
                _ => FrmMain.Source
            };

            // If the page is the Install page, hide buttons.
            if (!FrmMain.Content.GetType().Name.Equals("Install"))
            {
                BtnBackward.Visibility = Visibility.Visible;
                BtnForward.Content = "Next";
            }
            else
            {
                BtnBackward.Visibility = Visibility.Hidden;
                BtnForward.Visibility = Visibility.Hidden;
            }
        }

        private void BtnBackward_Click(object sender, RoutedEventArgs e)
        {
            // Send them back a page if an entry exists.
            if (FrmMain.CanGoBack) FrmMain.GoBack();

            // If the page is the License page, then change buttons.
            if (!FrmMain.Content.GetType().Name.Equals("LicenseAgreement")) return;
            BtnBackward.Visibility = Visibility.Hidden;
            BtnForward.Content = "Start installation";
        }
    }
}
