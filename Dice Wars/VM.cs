//Dice Wars Assignment 5 By: Mrinal Bedi, Varalakshmi Gottiparthi, Alaa Kabbani and Vamshi Mani Rasukachula//
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Dice_Wars
{
    public class VM : INotifyPropertyChanged
    {
        Random DiceRoll = new Random(); 
        private int diceNumberPlayer1;
        private int diceNumberPlayer2;
        private int player1TotalScore = 0;
        private int player2TotalScore = 0;
        string winner;
        string fileContent = string.Empty;
        const int winningscore = 20;
        private string imageSourceDie1;
        private string imageSourceDie2;
        private Visibility imageVisibility = Visibility.Hidden;

        #region properties
        public int Player1TotalScore
        {
            get { return player1TotalScore; }
            set { player1TotalScore = value; changed(); }
        }
        public int Player2TotalScore
        {
            get { return player2TotalScore; }
            set { player2TotalScore = value; changed(); }
        }
        public int DiceNumberPlayer1
        {
            get { return diceNumberPlayer1; }
            set { diceNumberPlayer1 = value; changed(); }
        }
        public int DiceNumberPlayer2
        {
            get { return diceNumberPlayer2; }
            set { diceNumberPlayer2 = value; changed(); }
        }
        public string Winner
        {
            get { return winner; }
            set { winner = value; changed(); }
        }      
        public string ImageSourceDie1
        {
            get { return imageSourceDie1; }
            set { imageSourceDie1 = value; changed(); }
        }
        public string ImageSourceDie2
        {
            get { return imageSourceDie2; }
            set { imageSourceDie2 = value; changed(); }
        }
        public Visibility ImageVisibility
        {
            get { return imageVisibility; }
            set { imageVisibility = value; changed(); }
        }
        #endregion


        public void Calc()
        {
            try
            {
                //When button clicked, check if total scores are less than winningscore, if so generate 2 random numbers//
                if (Player1TotalScore < winningscore && Player2TotalScore < winningscore)
                {
                    diceNumberPlayer1 = DiceRoll.Next(1, 7);
                    diceNumberPlayer2 = DiceRoll.Next(1, 7);

                    fileContent +="\n"+ "Player 1 Roll: " + diceNumberPlayer1 + ", " + "Player 2 Roll: " + diceNumberPlayer2;

                    switch (diceNumberPlayer1)
                    {
                        case 1:
                            ImageSourceDie1 = "images/Die1.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 2:
                            ImageSourceDie1 = "images/Die2.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 3:
                            ImageSourceDie1 = "images/Die3.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 4:
                            ImageSourceDie1 = "images/Die4.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 5:
                            ImageSourceDie1 = "images/Die5.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 6:
                            ImageSourceDie1 = "images/Die6.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                    }

                    switch (diceNumberPlayer2)
                    {
                        case 1:
                            ImageSourceDie2 = "images/Die1.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 2:
                            ImageSourceDie2 = "images/Die2.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 3:
                            ImageSourceDie2 = "images/Die3.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 4:
                            ImageSourceDie2 = "images/Die4.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 5:
                            ImageSourceDie2 = "images/Die5.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                        case 6:
                            ImageSourceDie2 = "images/Die6.bmp";
                            ImageVisibility = Visibility.Visible;
                            break;
                    }
                    //Add the new random numbers to the total score of each player//
                    Player1TotalScore += diceNumberPlayer1;
                    Player2TotalScore += diceNumberPlayer2;

                    //Checks if either player or both reached or went over winningscore and displays who won//
                    if (Player1TotalScore >= winningscore && Player2TotalScore >= winningscore)
                        Winner = "No winner - You both achieved a running score of 20 or more on the same roll!";
                    else if (Player1TotalScore >= winningscore)
                        Winner = "Player 1 Won!";
                    else if (Player2TotalScore >= winningscore)
                        Winner = "Player 2 Won!";
                }
                fileContent += "     Player 1 Score: " + Player1TotalScore + "   " + "Player 2 Score: " + " " + Player2TotalScore + "\n" + Winner + "\t";
            }
           catch
            {
                MessageBox.Show("Some error occured", "Error");
            }
        }
        //resets all scores so players can play again//
        public void Reset()
        {
            Player1TotalScore = 0;
            Player2TotalScore = 0;
            Winner = "";
            ImageVisibility = Visibility.Hidden;
        }
        public void ExecuteSaveFileDialog()
        {
            try
            {
                SaveFileDialog fileDialog = new SaveFileDialog
                {
                    Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
                };

                if (fileDialog.ShowDialog() == true)
                    File.AppendAllText(fileDialog.FileName, fileContent);
            }
            catch
            {
                MessageBox.Show("Some error occurred");
            }           
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void changed([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
