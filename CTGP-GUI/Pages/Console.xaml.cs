using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CTGP_GUI.Classes;

namespace CTGP_GUI.Pages
{
    /// <summary>
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class Console : Page
    {
        private readonly Questionnaire _questionnaire;
        public Console(Questionnaire q)
        {
            InitializeComponent();
            _questionnaire = q;
            _questionnaire.Console = NintendoConsole.NoSelection;
        }

        private void ConsoleRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            _questionnaire.Console = ((RadioButton) sender).Equals(RadWii) ? NintendoConsole.Wii : NintendoConsole.WiiU;
        }
    }
}
