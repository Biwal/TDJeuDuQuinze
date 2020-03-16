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

namespace TDJeuDuQuinze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Label PlayerCounter { get; set; }
        public Label PlayerLabel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.PlayerCounter = playerOneCounter;
            this.PlayerLabel = playerOneName;
            playerOneName.Style = (Style)FindResource("JoueurActif");
            playerTwoName.Style = (Style)FindResource("JoueurPassif");
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = sender as Button;

            this.updatePlayerCounter(bouton);

            this.checkVictory();

            this.disableButton(bouton);

            this.updatePlayerIdentity();

        }

        private void disableButton(Button bouton)
        {
            bouton.IsEnabled = false;
            bouton.Style = (Style)FindResource("BoutonRouge");
        }

        private void updatePlayerCounter(Button bouton)
        {
            int buttonValue = Int32.Parse(bouton.Content.ToString());
            int joueurValue = Int32.Parse(PlayerCounter.Content.ToString());
            int newValue = joueurValue + buttonValue;
            PlayerCounter.Content = newValue.ToString();
        }
    
        private void updatePlayerIdentity()
        {
            if (Int32.Parse(playerOneCounter.Content.ToString()) > 15 && Int32.Parse(playerTwoCounter.Content.ToString()) > 15) return;
            PlayerCounter = PlayerCounter == playerOneCounter ? playerTwoCounter : playerOneCounter;
            PlayerLabel = PlayerLabel == playerOneName ? updatePlayerLabel(playerTwoName,playerOneName) : updatePlayerLabel(playerOneName,playerTwoName);
            if (Int32.Parse(PlayerCounter.Content.ToString()) > 15) this.updatePlayerIdentity();
        }

        private void checkVictory()
        {
            if (Int32.Parse(PlayerCounter.Content.ToString()) == 15) {
                MessageBox.Show("Le joueur a gagné");
            } else if (Int32.Parse(playerOneCounter.Content.ToString())>15 && Int32.Parse(playerTwoCounter.Content.ToString()) >15)
            {
                MessageBox.Show("Match Nul");
                this.Close();
            } 
        }

        private Label updatePlayerLabel(Label player, Label waiter)
        {
            
            player.Style = (Style)FindResource("JoueurActif");
            waiter.Style = (Style)FindResource("JoueurPassif");
            /*
                        waiter.Background = (Style)FindResource("x:Static SystemColors.HotTrackBrushKey");*/
            /*  Background = "{DynamicResource {x:Static SystemColors.HotTrackBrushKey}}"*/
            return player;
        }
    }
}
