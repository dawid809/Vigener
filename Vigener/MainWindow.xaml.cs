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

namespace Vigener
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

        private void Button_ClickSzyfruj(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickDeszyfruj(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickCzysc(object sender, RoutedEventArgs e)
        {
            textset.Text = default;
            textget.Text = default;
            cipher.Text = default;
        }

        private void textset_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textset.Clear();
        }

        private void cipher_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            cipher.Clear();
        }

        static string ToLower(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                char let = arr[i];
                if (char.IsUpper(let))
                    arr[i] = char.ToLower(let);
            }
            string ciag = new string(arr);
            return ciag;
        }

        private char[] Alfabet()
        {
            char[] alfabet = { 'a','ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j','k',
                'l','ł','m','n','ń','o','ó','p','q','r','s','ś','t','u','v','w','x','y','z','ź','ż'};
            return alfabet;
        }
    }
}
