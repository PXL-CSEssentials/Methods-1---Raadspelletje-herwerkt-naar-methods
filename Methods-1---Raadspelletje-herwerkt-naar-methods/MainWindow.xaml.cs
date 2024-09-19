using Microsoft.VisualBasic;
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

namespace Methods_1___Raadspelletje_herwerkt_naar_methods
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Counter;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            Counter = 0;
            // Declaratie van variabelen.
            int randomNumber;
            Random random = new Random();

            //Willekeurig getal genereren
            randomNumber = random.Next(1, 101);

            StartCheck(randomNumber);
        }

        private void StartCheck(int searchedInteger)
        {
            int answerInteger;
            do
            {
                Counter++;
                //Vraag antwoord via inputbox
                answerInteger = GiveAnswer();

                //Controleer antwoord
                CheckAnswer(answerInteger, searchedInteger);
            } while (answerInteger != searchedInteger);
        }

        private int GiveAnswer()
        {
            string answer;
            int retVal;
            bool okResult;
            do
            {
                //MessageBox.Show("Geef een getal in", "Raadspel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                answer = Interaction.InputBox("Geef een getal tussen 1 en 100", "Raadspel");
                okResult = int.TryParse(answer, out retVal);
            } while (okResult == false);
            return retVal;
        }

        private void CheckAnswer(int answer, int solution)
        {
            if (answer == solution)
            {
                MessageBox.Show($"U heeft het getal geraden in {Counter} beurten", "Proficiat!"
                , MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (answer < solution)
            {
                MessageBox.Show(" Raad hoger ", "Raadspel");
            }
            else if (answer > solution)
            {
                MessageBox.Show(" Raad lager ", "Raadspel");
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}