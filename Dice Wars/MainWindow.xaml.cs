//Dice Wars Assignment 5 By: Mrinal Bedi, Varalakshmi Gottiparthi, Alaa Kabbani and Vamshi Mani Rasukachula//
using System.Windows;

namespace Dice_Wars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }
        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            vm.Calc();
           
        }
        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            vm.Reset();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            vm.ExecuteSaveFileDialog();
        }
    }
}
