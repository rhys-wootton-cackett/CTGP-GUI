using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

using CTGP_GUI.Classes;

namespace CTGP_GUI.Pages
{
    /// <summary>
    /// Interaction logic for LicenseAgreement.xaml
    /// </summary>
    public partial class LicenseAgreement : Page
    {
        private const string LicenseUrl = "https://raw.githubusercontent.com/rhys-wootton/CTGP-GUI/master/LICENSE";
        private readonly Questionnaire _questionnaire;

        public LicenseAgreement(Questionnaire q)
        {
            InitializeComponent();
            _questionnaire = q;
            q.LicenseAccepted = false;
            CbxAcceptLicense.IsChecked = false;
            CbxAcceptLicense.IsEnabled = false;
        }

        /// <summary>
        /// Retrieves the license from the GitHub repo using the GitHub
        /// REST API, and if that fails, uses a locally stored one.
        /// </summary>
        private async void AddLicenseToTextBlock(object sender, RoutedEventArgs e)
        {
            var wc = new WebClient();

            try
            {
                // Try to grab the latest license from the repo (it may change)
                TbxLicense.Text = await wc.DownloadStringTaskAsync(LicenseUrl);
            }
            catch (Exception)
            {
                // Load the one in resources, it may be old but still applicable
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames()
                    .Single(str => str.EndsWith("LICENSE.txt"));

                await using var stream = assembly.GetManifestResourceStream(resourceName);
                using var reader = new StreamReader(stream);
                TbxLicense.Text = await reader.ReadToEndAsync();
            }

            CbxAcceptLicense.IsEnabled = true;
        }

        private void CbxAcceptLicense_Click(object sender, RoutedEventArgs e)
        {
            _questionnaire.LicenseAccepted = (bool)CbxAcceptLicense.IsChecked;
        }
    }
}
