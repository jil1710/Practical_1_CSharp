class Calc
{
    public static void Main(string[] args)
    {
        char restart;

        do
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n ***************** Calculator *******************\n");
            Console.ResetColor();
            Console.Write(" Enter first number : ");
            double num1 = SetAndValidateNumber();
            Console.Write("\n Enter second number : ");
            double num2 = SetAndValidateNumber();

            // Print Result 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n ************* Result **************\n");
            Console.WriteLine($" {num1} + {num2} = {Math.Round((num1 + num2), 6)}");
            Console.WriteLine($" {num1} * {num2} = {Math.Round((num1 * num2), 6)}");
            Console.WriteLine($" {num1} - {num2} = {Math.Round((num1 - num2), 6)}");

            // Exception handling for division operation
            try
            {
                if (num2 == 0)
                {
                    throw new Exception("Cannot divide by 0");
                }
                Console.WriteLine($" {num1} / {num2} = {Math.Round((num1 / num2), 6)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" {num1} / {num2} = {ex.Message}");
            }
            Console.WriteLine("\n ***********************************\n");

            Console.ResetColor();

            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.Write(" Do you want to continue [ y/n ] : ");
            restart = Console.ReadKey(true).KeyChar;
        } while (restart == 'y');

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n\n Thank you! Have a nice day.");
        Console.ResetColor();


    }
    
    

    public static double SetAndValidateNumber()
    {
        ConsoleKeyInfo keyInfo;
        double number;
        string value = String.Empty;
        do
        {
            // Take input from user
            keyInfo = Console.ReadKey(true);
            if (char.IsDigit(keyInfo.KeyChar))
            {
                if(keyInfo.KeyChar == '0')
                {
                    if(!value.StartsWith("0") || value.Contains('.'))
                    {
                        value += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                else
                {
                    value += keyInfo.KeyChar;
                    Console.Write(keyInfo.KeyChar);
                }
            }

            // logic for delete when user press backspace key
            if (keyInfo.Key == ConsoleKey.Backspace && value.Length > 0)
            {
                value = value.Substring(0, value.Length - 1);
                Console.Write("\b \b");
            }
            
            // logic for dot validation
            if (keyInfo.KeyChar == '.' && !value.Contains('.') && value.Length == 0)
            {
                value += "0.";
                Console.Write("0.");
            }
            else if(keyInfo.KeyChar == '.' && !value.Contains('.'))
            {
                value += keyInfo.KeyChar;
                Console.Write(keyInfo.KeyChar);
            }
            

            if (keyInfo.KeyChar == '-' && value.Length == 0)
            {
                value += keyInfo.KeyChar;
                Console.Write(keyInfo.KeyChar);
            }

        } while (keyInfo.Key != ConsoleKey.Enter);

        // parse string to double
        if(double.TryParse(value, out number))
        {
            return number;
        }
        return number;
    }

    
}
