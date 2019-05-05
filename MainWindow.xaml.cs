using System.IO;
using System.Windows;

namespace _3T
{
    /// <summary>
    /// Logic of interaction of MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declaration of variables

        //Name of file which is used for saves number of wins
        private const string path = "wins.txt";

        //Counter is used to tell us about whose turn is it
        private int counter;

        //Variable used for random player
        private readonly System.Random rnd = new System.Random();

        //Variable which will count wins of each player wins[0] is X; wins[1] is O
        private readonly int[] wins = new int[2] { 0, 0 };

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(path))
            {
                if (MessageBox.Show(("Would you like to load data from file " + path), "Meassage", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                    StreamReader streamReader = new StreamReader(fs);
                    wins[0] = int.Parse(streamReader.ReadLine());
                    wins[1] = int.Parse(streamReader.ReadLine());
                    streamReader.Close();
                }
            }
            Restart();
        }

        /// <summary>
        /// Describe behaviour of every button. Each button on click called method Click() to minimalize needs to call out everything from each click event.
        /// </summary>
        /// <param name="sender">name of object provided with event</param>
        /// <param name="e">name of RoutedEventsArgs</param>
        #region Buttons

        #region First row of buttons

        private void ButtonC0R0_Click(object sender, RoutedEventArgs e) => Click(sender, e);

        private void ButtonC1R0_Click(object sender, RoutedEventArgs e) => Click(sender, e);

        private void ButtonC2R0_Click(object sender, RoutedEventArgs e) => Click(sender, e);
        #endregion

        #region Second row of buttons

        private void ButtonC0R1_Click(object sender, RoutedEventArgs e) => Click(sender, e);

        private void ButtonC1R1_Click(object sender, RoutedEventArgs e) => Click(sender, e);

        private void ButtonC2R1_Click(object sender, RoutedEventArgs e) => Click(sender, e);

        #endregion

        #region Third row of buttons

        private void ButtonC0R2_Click(object sender, RoutedEventArgs e) => Click(sender, e);

        private void ButtonC1R2_Click(object sender, RoutedEventArgs e) => Click(sender, e);

        private void ButtonC2R2_Click(object sender, RoutedEventArgs e) => Click(sender, e);

        #endregion

        #endregion

        /// <summary>
        /// Activate on button click call other methods such as Check() and if check return true whoch is equal to end of the game, call method Restart()
        /// </summary>
        /// <param name="localSender">get object in this situation as button</param>
        /// <param name="localE">get RoutedEventArgs from button click</param>
        private void Click(object localSender, RoutedEventArgs localE)
        {
            System.Windows.Controls.Button sender = (System.Windows.Controls.Button)localSender;

            switch (counter)
            {
                case 0:
                    counter++;
                    sender.Content = "X";
                    sender.IsEnabled = false;
                    break;
                case 1:
                    counter--;
                    sender.Content = "O";
                    sender.IsEnabled = false;
                    break;
            }

            if (Check())
                Restart();
        }

        /// <summary>
        /// Methods that checks if and who won. Before return show message box with name of player which won and add points.
        /// </summary>
        /// <returns>true if someone won</returns>
        private bool Check()
        {
            if ((buttonC0R0.Content.ToString() == "X" && buttonC0R1.Content.ToString() == "X" && buttonC0R2.Content.ToString() == "X") || (buttonC1R0.Content.ToString() == "X" && buttonC1R1.Content.ToString() == "X" && buttonC1R2.Content.ToString() == "X") || (buttonC2R0.Content.ToString() == "X" && buttonC2R1.Content.ToString() == "X" && buttonC2R2.Content.ToString() == "X") || (buttonC0R0.Content.ToString() == "X" && buttonC1R0.Content.ToString() == "X" && buttonC2R1.Content.ToString() == "X") || (buttonC0R1.Content.ToString() == "X" && buttonC1R1.Content.ToString() == "X" && buttonC2R1.Content.ToString() == "X") || (buttonC0R2.Content.ToString() == "X" && buttonC1R2.Content.ToString() == "X" && buttonC2R2.Content.ToString() == "X") || (buttonC2R0.Content.ToString() == "X" && buttonC1R1.Content.ToString() == "X" && buttonC0R2.Content.ToString() == "X") || (buttonC0R0.Content.ToString() == "X" && buttonC1R1.Content.ToString() == "X" && buttonC2R2.Content.ToString() == "X"))
            {
                MessageBox.Show("Cross won! Congrats");
                wins[0]++;
                return true;
            }

            if ((buttonC0R0.Content.ToString() == "O" && buttonC0R1.Content.ToString() == "O" && buttonC0R2.Content.ToString() == "O") || (buttonC1R0.Content.ToString() == "O" && buttonC1R1.Content.ToString() == "O" && buttonC1R2.Content.ToString() == "O") || (buttonC2R0.Content.ToString() == "O" && buttonC2R1.Content.ToString() == "O" && buttonC2R2.Content.ToString() == "O") || (buttonC0R0.Content.ToString() == "O" && buttonC1R0.Content.ToString() == "O" && buttonC2R0.Content.ToString() == "O") || (buttonC0R1.Content.ToString() == "O" && buttonC1R1.Content.ToString() == "O" && buttonC2R1.Content.ToString() == "O") || (buttonC0R2.Content.ToString() == "O" && buttonC1R2.Content.ToString() == "O" && buttonC2R2.Content.ToString() == "O") || (buttonC2R0.Content.ToString() == "O" && buttonC1R1.Content.ToString() == "O" && buttonC0R2.Content.ToString() == "O") || (buttonC0R0.Content.ToString() == "O" && buttonC1R1.Content.ToString() == "O" && buttonC2R2.Content.ToString() == "O"))
            {
                MessageBox.Show("Circle won! Congrats");
                wins[1]++;
                return true;
            }

            return false;

        }

        /// <summary>
        /// Methods called on start of the game and on every restart. Turns buttons, clear content, random new player, update counter and shows message box with name of player
        /// </summary>
        private void Restart()
        {
            labelPoints.Content = ("X: " + wins[0] + "   O: " + wins[1]).ToString();
            counter = rnd.Next(0, 2);

            buttonC0R0.IsEnabled = buttonC0R1.IsEnabled = buttonC0R2.IsEnabled = buttonC1R0.IsEnabled = buttonC1R1.IsEnabled = buttonC1R2.IsEnabled = buttonC2R0.IsEnabled = buttonC2R1.IsEnabled = buttonC2R2.IsEnabled = true;
            buttonC0R0.Content = buttonC0R1.Content = buttonC0R2.Content = buttonC1R0.Content = buttonC1R1.Content = buttonC1R2.Content = buttonC2R0.Content = buttonC2R1.Content = buttonC2R2.Content = "";

            MessageBox.Show("Zaczyna gracz " + (counter == 0 ? "krzyżyk" : "kółko"));
        }

        /// <summary>
        /// Method called on closing window. Method saves number of wins of each player. It's data whoch is used for next play.
        /// </summary>
        /// <param name="e">added automaticly</param>
        /// <param name="sender">added automaticly</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (File.Exists(path))
                File.Delete(path);

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fs);
            streamWriter.WriteLine(wins[0]);
            streamWriter.WriteLine(wins[1]);
            streamWriter.Close();
        }
    }
}
