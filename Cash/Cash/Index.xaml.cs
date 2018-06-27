using Cash.ViweModel;
using MahApps.Metro.Controls;
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

namespace Cash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Index : MetroWindow
    {
        public Index()
        {
            InitializeComponent();
            //DefaultStyle();
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
    
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messege messege = new Messege();
            View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);

            if (messege_view_Model._OK == null)
                messege_view_Model._OK = new Action(messege.Close);
            if (messege_view_Model._NO == null)
                messege_view_Model._NO = new Action(messege.Close);


            messege.DataContext = messege_view_Model;
            messege_view_Model.Messege = "Are you sure you want to exit the program?";
            messege_view_Model.Messeg_Titel = "Exit";
            messege.ShowDialog();

            if (messege_view_Model.is_no)
            {
                e.Cancel = true;
            }

        }
        
    }
}
