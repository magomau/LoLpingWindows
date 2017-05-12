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
            int numPing = 8;
            ComboBox cB = sender as ComboBox;
            string Region = this.cBox.SelectedValue.ToString();
            //this.Title = Region;

            SendPing SP = new SendPing(Region);
            Ping = SP.SenderPing(Region);
            string[] PingsTotal = SP.SendersPings(Region, numPing);
            this.tBlockMS.Text = Ping;
            this.tBlockAvg.Text = PingsTotal[0] + " ms";
            this.tBlockMax.Text = PingsTotal[1] + " ms";
            this.tBlockMin.Text = PingsTotal[2] + " ms";
            int color = SP.ColorType(Ping);
            int colorAvg = SP.ColorType(PingsTotal[0].ToString());
            int colorMax = SP.ColorType(PingsTotal[1].ToString());
            int colorMin = SP.ColorType(PingsTotal[2].ToString());
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
            switch (colorAvg)
            {
                case 1:
                    this.tBlockAvg.Foreground = Brushes.DarkGreen;
                    break;
                case 2:
                    this.tBlockAvg.Foreground = Brushes.Orange;
                    break;
                case 3:
                    this.tBlockAvg.Foreground = Brushes.Red;
                    break;
                default:
                    this.tBlockAvg.Foreground = Brushes.DarkGreen;
                    break;
            }
            switch (colorMax)
            {
                case 1:
                    this.tBlockMax.Foreground = Brushes.DarkGreen;
                    break;
                case 2:
                    this.tBlockMax.Foreground = Brushes.Orange;
                    break;
                case 3:
                    this.tBlockMax.Foreground = Brushes.Red;
                    break;
                default:
                    this.tBlockMax.Foreground = Brushes.DarkGreen;
                    break;
            }
            switch (colorMin)
            {
                case 1:
                    this.tBlockMin.Foreground = Brushes.DarkGreen;
                    break;
                case 2:
                    this.tBlockMin.Foreground = Brushes.Orange;
                    break;
                case 3:
                    this.tBlockMin.Foreground = Brushes.Red;
                    break;
                default:
                    this.tBlockMin.Foreground = Brushes.DarkGreen;
                    break;
            }
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
