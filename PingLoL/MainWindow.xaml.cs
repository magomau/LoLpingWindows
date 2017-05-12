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

namespace PingLoL
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> data = new List<string>();
            data.Add("LAS");
            data.Add("LAN");
            data.Add("NA");
            data.Add("EUW");
            data.Add("BR");
            data.Add("OCE");

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;
            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.Title = "Región Seleccionada: " + value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Ping;

            ComboBox cB = sender as ComboBox;
            string Region = this.cBox.SelectedValue.ToString();
            //this.Title = Region;

            SendPing SP = new SendPing(Region);
            Ping = SP.SenderPing(Region);
            int color = SP.ColorType(Ping);
            switch (color)
            {
                case 1:
                    this.tBlockMS.Foreground = Brushes.DarkGreen;
                    break;
                case 2:
                    this.tBlockMS.Foreground = Brushes.Orange;
                    break;
                case 3:
                    this.tBlockMS.Foreground = Brushes.Red;
                    break;
                default:
                    this.tBlockMS.Foreground = Brushes.DarkGreen;
                    break;
            }
            this.tBlockMS.Text = Ping;
            

        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            string MS = "0 ms";
            // Get TextBlock reference.
            var block = sender as TextBlock;
            block.Text = MS ;
        }
    }  
}
