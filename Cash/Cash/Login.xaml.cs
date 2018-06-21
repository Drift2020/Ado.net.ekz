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
using System.Windows.Shapes;

namespace Cash
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
           // DefaultStyle();
        }
        public void DefaultStyle()
        {
            this.Background = new SolidColorBrush(Colors.DarkGray);
            var core = new Uri("Resurse\\Core.xaml", UriKind.Relative);
            var brush = new Uri("Resurse\\Brushes.xaml", UriKind.Relative);
            var ico = new Uri("Resurse\\Icons.xaml", UriKind.Relative);

            ResourceDictionary resourceDictionary = Application.LoadComponent(core) as ResourceDictionary;
            ResourceDictionary bru = Application.LoadComponent(brush) as ResourceDictionary;
            ResourceDictionary ic = Application.LoadComponent(ico) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(bru);
            Application.Current.Resources.MergedDictionaries.Add(ic);

        }

        public void None_user()
        {
            MessageBox.Show("No user, register a new user.");
           
        }

        public void Ok()
        {
            MessageBox.Show("Signed in.");
        
        }

        public void Visibility_off()
        {
            Visibility = Visibility.Hidden;
        }
        public void Visibility_on()
        {
            Visibility = Visibility.Visible;
        }

        public void No()
        {
            //Close();
        }
    }
}
