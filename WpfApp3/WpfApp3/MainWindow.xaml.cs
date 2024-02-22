using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Versenyzok> versenyzok = Versenyzok.Beolvasas("Selejtezo2012.txt");
        public MainWindow()
        {
            InitializeComponent();
            versenyzokComboBox.ItemsSource = versenyzok.Select(x => x.Nev);
            versenyzokComboBox.SelectedItem = "Pars Krisztián";

        }
        private void versenyzokComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var defaultAlap = versenyzok[versenyzokComboBox.SelectedIndex];
            CsoportLabel.Content = defaultAlap.Csoport;
            NemzetLabel.Content = defaultAlap.Nemzet2;
            NemzetKodLabel.Content = defaultAlap.Kód;
            SorozatLabel.Content = $"{defaultAlap.D1};{defaultAlap.D2};{defaultAlap.D3}";
            EredmenyLabel.Content = defaultAlap.Eredmény();

            Uri uri = new Uri("Images/" + defaultAlap.Kód + ".png", UriKind.Relative);
            flagImage.Source = new BitmapImage(uri);
        }
    }
}
