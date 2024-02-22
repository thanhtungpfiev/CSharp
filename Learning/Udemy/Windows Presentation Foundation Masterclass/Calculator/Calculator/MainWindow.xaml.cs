using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///


    public partial class MainWindow : Window
    {
        private double lastNumber;
        private double result;
        private SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            selectedOperator = SelectedOperator.None;
            buttonAC.Click += ButtonAC_Click;
            buttonNegative.Click += ButtonNegative_Click;
            buttonPercentage.Click += ButtonPercentage_Click;
            buttonEquatation.Click += ButtonEquatation_Click;
        }

        private void ButtonEquatation_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(labelResult.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Sub(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Mul(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Div(lastNumber, newNumber);
                        break;
                    default:
                        break;
                }
                labelResult.Content = result;
                lastNumber = result;
                selectedOperator = SelectedOperator.None;
            }
        }

        private void ButtonPercentage_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(labelResult.Content.ToString(), out newNumber))
            {
                if (selectedOperator != SelectedOperator.None)
                {
                    newNumber /= 100;
                    newNumber *= lastNumber;
                }
                else
                {
                    newNumber /= 100;
                }
            }
            labelResult.Content = newNumber.ToString();
        }

        private void ButtonNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResult.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                labelResult.Content = lastNumber.ToString();
            }
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            labelResult.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button clickedButton = (Button)sender;
                object buttonContent = clickedButton.Content;
                if (buttonContent is string)
                {
                    string buttonText = (string)buttonContent;
                    if (labelResult.Content.ToString() == "0")
                    {
                        labelResult.Content = buttonText;
                    }
                    else
                    {
                        labelResult.Content += buttonText;
                    }
                }
            }
        }

        private void ButtonOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResult.Content.ToString(), out lastNumber))
            {
                labelResult.Content = "0";
            }
            if (sender == buttonAddition)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            else if (sender == buttonSubtraction)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            else if (sender == buttonMultiplication)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            else if (sender == buttonDivision)
            {
                selectedOperator = SelectedOperator.Division;
            }
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (!labelResult.Content.ToString().Contains("."))
            {
                labelResult.Content += ".";
            }
        }
    }

    public enum SelectedOperator
    {
        None,
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Mul(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Div(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Not support divide to zero", "Wrong expression", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}