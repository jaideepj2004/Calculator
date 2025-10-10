using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// JawDropper Calculator - A modern, professional calculator application
    /// </summary>
    public partial class MainWindow : Window
    {
        // Private fields to maintain calculator state
        private string currentInput = "0";      // The current number being displayed
        private string operand1 = "";           // First operand for calculations
        private string currentOperator = "";    // Current operator (+, -, *, /, %)
        private bool isNewInput = true;         // Flag to track if we're starting a new number

        /// <summary>
        /// Constructor - Initializes the calculator window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles number button clicks (0-9)
        /// Appends the clicked digit to the current input
        /// </summary>
        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string number = button.Content.ToString() ?? "0";
                
                // If starting a new input or current display is "0", replace it
                if (isNewInput || currentInput == "0")
                {
                    currentInput = number;
                    isNewInput = false;
                }
                else
                {
                    // Otherwise append the digit
                    currentInput += number;
                }
                
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Handles operator button clicks (+, -, ×, ÷, %)
        /// Performs pending calculation if one exists, then sets up for next operation
        /// </summary>
        private void ButtonOperator_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string op = button.Content.ToString() ?? "";
                
                // If we have a pending calculation and user just entered a number, calculate it
                if (!string.IsNullOrEmpty(operand1) && !isNewInput)
                {
                    Calculate();
                }
                
                // Store current value as first operand
                operand1 = currentInput;
                
                // Convert UI symbols to actual operators
                // × becomes *, ÷ becomes /
                if (op == "×")
                    currentOperator = "*";
                else if (op == "÷")
                    currentOperator = "/";
                else
                    currentOperator = op;
                
                isNewInput = true;
            }
        }

        /// <summary>
        /// Handles equals button click
        /// Performs the calculation and displays result
        /// </summary>
        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            operand1 = "";
            currentOperator = "";
            isNewInput = true;
        }

        /// <summary>
        /// Core calculation logic
        /// Performs arithmetic operation based on stored operator
        /// </summary>
        private void Calculate()
        {
            // Don't calculate if we don't have both operands and an operator
            if (string.IsNullOrEmpty(operand1) || string.IsNullOrEmpty(currentOperator))
                return;

            try
            {
                // Parse the operands
                double num1 = double.Parse(operand1);
                double num2 = double.Parse(currentInput);
                double result = 0;

                // Perform the operation
                if (currentOperator == "+")
                {
                    result = num1 + num2;
                }
                else if (currentOperator == "-")
                {
                    result = num1 - num2;
                }
                else if (currentOperator == "*")
                {
                    result = num1 * num2;
                }
                else if (currentOperator == "/")
                {
                    // Check for division by zero
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        currentInput = "Error";
                        UpdateDisplay();
                        return;
                    }
                }
                else if (currentOperator == "%")
                {
                    result = num1 % num2;
                }

                // Update display with result
                currentInput = result.ToString();
                UpdateDisplay();
            }
            catch
            {
                // Handle any parsing or calculation errors
                currentInput = "Error";
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Handles Clear button (C)
        /// Resets calculator to initial state
        /// </summary>
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "0";
            operand1 = "";
            currentOperator = "";
            isNewInput = true;
            UpdateDisplay();
        }

        /// <summary>
        /// Handles Delete/Backspace button (?)
        /// Removes last digit from current input
        /// </summary>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (currentInput.Length > 1)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
            else
            {
                // If only one digit, reset to 0
                currentInput = "0";
            }
            UpdateDisplay();
        }

        /// <summary>
        /// Handles Decimal button (.)
        /// Adds decimal point if one doesn't already exist
        /// </summary>
        private void ButtonDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Handles Negate button (±)
        /// Toggles between positive and negative
        /// </summary>
        private void ButtonNegate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(currentInput, out double value))
            {
                currentInput = (-value).ToString();
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Updates the display TextBox with current input value
        /// </summary>
        private void UpdateDisplay()
        {
            DisplayBox.Text = currentInput;
        }
    }
}
