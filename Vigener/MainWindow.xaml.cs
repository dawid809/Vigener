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
            string key = cipher.Text;
            string stringText = textset.Text;

            Szyfruj(ref stringText, key);
            textget.Text = stringText;
        }

        private void Button_ClickDeszyfruj(object sender, RoutedEventArgs e)
        {
            string key = cipher.Text;
            string stringText = textset.Text;

            Deszyfruj(ref stringText, key);
            textget.Text = stringText;
        }

        private void Button_ClickCzysc(object sender, RoutedEventArgs e)
        {
            textget.Text = textget.Text = "Tekst po szyfrowaniu lub deszyfrowaniu";
            textset.Text = textset.Text = "Podaj tekst do szyfrowania lub deszyfrowania";
            cipher.Text = cipher.Text = "Podaj klucz szyfrujący";
        }

        private void textset_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textset.Clear();
        }

        private void cipher_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            cipher.Clear();
        }

        public string Szyfruj(ref string stringText, string key)
        {
            stringText = StringTrim(ref stringText);
            key = StringTrim(ref key);

            char[] textArray = stringText.ToCharArray();
            char[] keyArray = key.ToCharArray();
            char[] alfabetArray = Alfabet();

            int sumIndex;
            int k = 0;

            for (int i = 0; i < textArray.Length; i++)
            {
                char letterText = textArray[i];
                int indexLetter = alfabetArray.FindIndex(letterText);

                char letterKey = keyArray[k];
                int indexKey = alfabetArray.FindIndex(letterKey);

                sumIndex = indexLetter + indexKey;

                if (sumIndex >= alfabetArray.Length)
                {
                    // sum = sum < 0 ? sum : -sum;
                    sumIndex = sumIndex - alfabetArray.Length;
                    letterText = alfabetArray[sumIndex];
                }
                else
                {
                    letterText = alfabetArray[sumIndex];
                }
                k = k + 1 == key.Length ? 0 : k + 1;
                textArray[i] = letterText;
            }
            stringText = new string(textArray);

            return stringText;
        }

        public string Deszyfruj(ref string stringText, string key)
        {
            stringText = StringTrim(ref stringText);
            key = StringTrim(ref key);

            char[] textArray = stringText.ToCharArray();
            char[] keyArray = key.ToCharArray();
            char[] alfabetArray = Alfabet();

            int sumIndex;
            int k = 0;

            for (int i = 0; i < textArray.Length; i++)
            {
                char letterText = textArray[i];
                int indexLetter = alfabetArray.FindIndex(letterText);

                char letterKey = keyArray[k];
                int indexKey = alfabetArray.FindIndex(letterKey);

                sumIndex = indexLetter - indexKey;

                if (indexLetter - indexKey < 0)
                {
                    sumIndex = sumIndex < 0 ? -sumIndex : sumIndex;
                    sumIndex = alfabetArray.Length - sumIndex;
                    letterText = alfabetArray[sumIndex];
                }
                else
                {
                    letterText = alfabetArray[sumIndex];
                }

                k = k + 1 == key.Length ? 0 : k + 1;
                textArray[i] = letterText;
            }
            stringText = new string(textArray);

            return stringText;
        }

        // Jeśli chcemy zmienić znaki alfabetu to należy podmienić już istniejący
        private static char[] Alfabet()
        {
            char[] alfabet = { 'a','ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j','k',
                'l','ł','m','n','ń','o','ó','p','q','r','s','ś','t','u','v','w','x','y','z','ź','ż'};
            return alfabet;
        }

        private static char[] AlfabetWithoutPolishCharacters()
        {
            char[] alfabet = { 'a', 'b', 'c', 'd', 'e','f', 'g', 'h', 'i', 'j','k',
                'l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            return alfabet;
        }

        static char[] RemveFromArray(char[] source, char value)
        {
            if (source == null)
                return null;

            char[] result = new char[source.Length];

            int resultIdx = 0;
            for (int ii = 0; ii < source.Length; ii++)
            {
                if (source[ii] != value)
                    result[resultIdx++] = source[ii];
            }

            return result.Take(resultIdx).ToArray();
        }

        static string StringTrim(ref string text)
        {
            text = text.ToLower();
            char[] array = text.ToCharArray();
            char[] alfabet = Alfabet();

            for (int i = 0; i < array.Length; i++)
            {
                char letter = array[i];

                if (!(alfabet.Contains(letter))) letter = default;

                array[i] = letter;
            }
            char[] cutArray = RemveFromArray(array, '\0');
            text = new string(cutArray);

            return text;
        }
    }

    public static class Extensions
    {
        public static int FindIndex<T>(this T[] array, T item)
        {
            return Array.FindIndex(array, val => val.Equals(item));
        }
    }
}
