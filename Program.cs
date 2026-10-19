using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace PasswordSecurityTool;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("=== Password Security Tool ===");
            Console.WriteLine();

            Console.WriteLine("1. Check password");
            Console.WriteLine("2. Generate password");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

            Console.Write("Choose option: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            if (choice == "1")
            {
                Console.Write("Enter password: ");
                string password = ReadPassword();

                Console.WriteLine();

                PasswordStrength(password);
            }
            else if (choice == "2")
            {
                GeneratePassword();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.Clear();
        }
    }


    static string ReadPassword()
    {
        string password = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }
            if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);

                    Console.Write("\b \b");
                }
            }
            else
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        }

        return password;
    }


    static void PasswordStrength(string password)
    {
        int score = 0;

        bool uppercase = Regex.IsMatch(password, @"[A-Z]");
        bool lowercase = Regex.IsMatch(password, @"[a-z]");
        bool numbers = Regex.IsMatch(password, @"\d");
        bool specialChars = Regex.IsMatch(password, @"[^\w\s]");


        if (password.Length >= 16)
        {
            score++;
        }
        if (uppercase)
        {
            score++;
        }
        if (lowercase)
        {
            score++;
        }
        if (numbers)
        {
            score++;
        }
        if (specialChars)
        {
            score++;
        }

        string[] commonPasswords =
        {
            "password",
            "password123",
            "123456",
            "12345678",
            "123456789",
            "qwerty",
            "abc123",
            "admin",
            "letmein"
        };

        bool commonPassword = commonPasswords.Contains(password.ToLower());

        int poolSize = 0;

        if (lowercase)
        {
            poolSize += 26;
        }
        if (uppercase)
        {
            poolSize += 26;
        }
        if (numbers)
        {
            poolSize += 10;
        }
        if (specialChars)
        {
            poolSize += 32;
        }

        double entropy = 0;

        if (poolSize > 0)
        {
            entropy = password.Length * Math.Log2(poolSize);
        }

        Console.WriteLine($"Length:             {password.Length}");
        Console.WriteLine($"Uppercase:          {(uppercase ? "Yes" : "No")}");
        Console.WriteLine($"Lowercase:          {(lowercase ? "Yes" : "No")}");
        Console.WriteLine($"Numbers:            {(numbers ? "Yes" : "No")}");
        Console.WriteLine($"Special chars:      {(specialChars ? "Yes" : "No")}");
        Console.WriteLine($"Common password:    {(commonPassword ? "Yes" : "No")}");
        Console.WriteLine($"Estimated entropy:  {Math.Round(entropy)} bits");

        Console.WriteLine();

        Console.WriteLine($"Score: {score}/5");

        if (commonPassword)
        {
            Console.WriteLine("Result: WEAK");
        }
        else if (score <= 2)
        {
            Console.WriteLine("Result: WEAK");
        }
        else if (score <= 4)
        {
            Console.WriteLine("Result: MEDIUM");
        }
        else
        {
            Console.WriteLine("Result: STRONG");
        }
    }


    static void GeneratePassword()
    {
        Console.WriteLine("=== Secure Password Generator ===");
        Console.WriteLine();

        Console.Write("Password length: ");

        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine("Invalid password length.");
            return;
        }

        Console.Write("Include uppercase? (y/n): ");
        bool uppercase = Console.ReadLine()?.ToLower() == "y";

        Console.Write("Include lowercase? (y/n): ");
        bool lowercase = Console.ReadLine()?.ToLower() == "y";

        Console.Write("Include numbers? (y/n): ");
        bool numbers = Console.ReadLine()?.ToLower() == "y";

        Console.Write("Include special chars? (y/n): ");
        bool specialChars = Console.ReadLine()?.ToLower() == "y";


        string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";

        string numberChars = "0123456789";

        string specialCharacters = "!@#$%^&*()-_=+[]{}<>?";


        string characterPool = "";

        if (uppercase)
        {
            characterPool += uppercaseChars;
        }
        if (lowercase)
        {
            characterPool += lowercaseChars;
        }
        if (numbers)
        {
            characterPool += numberChars;
        }
        if (specialChars)
        {
            characterPool += specialCharacters;
        }

        if (characterPool.Length == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Error: Select at least one character type.");
            return;
        }

        string password = "";

        for (int i = 0; i < length; i++)
        {
            int randomIndex = RandomNumberGenerator.GetInt32(characterPool.Length);

            password += characterPool[randomIndex];
        }

        Console.WriteLine();
        Console.WriteLine($"Generated password: {password}");
    }
}