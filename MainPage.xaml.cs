namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        double currentValue = 0;
        double previousValue = 0;
        char currentOperation;
        bool isNewEntry = false;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (isNewEntry)
            {
                display.Text += button.Text;
            }
            else
            {
                display.Text = button.Text;
                isNewEntry = true;
            }
        }

        void OnDecimal(object sender, EventArgs e)
        {
            if (!display.Text.Contains("."))
            {
                display.Text += ".";
            }
        }

        void OnAdd(object sender, EventArgs e)
        {
            SetOperation('+');
        }

        void OnSubtract(object sender, EventArgs e)
        {
            SetOperation('-');
        }

        void OnMultiply(object sender, EventArgs e)
        {
            SetOperation('×');
        }

        void OnDivide(object sender, EventArgs e)
        {
            SetOperation('÷');
        }

        void SetOperation(char operation)
        {
            if (double.TryParse(display.Text, out previousValue))
            {
                currentOperation = operation;
                display.Text += " " + operation + " ";
                isNewEntry = false;
            }
        }

        void OnCalculate(object sender, EventArgs e)
        {
            string[] parts = display.Text.Split(' ');

            if (parts.Length == 3 && double.TryParse(parts[0], out previousValue) && double.TryParse(parts[2], out currentValue))
            {
                PerformOperation();
                currentOperation = '\0';
            }
        }

        void PerformOperation()
        {
            switch (currentOperation)
            {
                case '+':
                    previousValue += currentValue;
                    break;
                case '-':
                    previousValue -= currentValue;
                    break;
                case '×':
                    previousValue *= currentValue;
                    break;
                case '÷':
                    if (currentValue != 0)
                        previousValue /= currentValue;
                    else
                        display.Text = "Error";
                    break;
            }

            display.Text = previousValue.ToString();
            isNewEntry = false;
        }

        void OnClear(object sender, EventArgs e)
        {
            previousValue = 0;
            currentValue = 0;
            display.Text = "0.00";
            currentOperation = '\0';
            isNewEntry = false;
        }

        void OnClearEntry(object sender, EventArgs e)
        {
            display.Text = "0.00";
            isNewEntry = false;
        }

        void OnPercent(object sender, EventArgs e)
        {
            if (double.TryParse(display.Text, out currentValue))
            {
                currentValue = currentValue / 100;
                display.Text = currentValue.ToString();
            }
        }
    }
}
