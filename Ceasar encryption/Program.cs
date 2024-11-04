using System;

class Program
{
    static void Main(string[] args)
    {
        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("Do you want to encrypt or decrypt?");
            string operation = Console.ReadLine().ToLower();

            if (operation != "encrypt" && operation != "decrypt")
            {
                Console.WriteLine("Invalid choice, try again.");
                continue;
            }

            Console.WriteLine("Input your text");
            string inputText = Console.ReadLine();

            Console.WriteLine("At what level do you wish to encrypt/decrypt?");
            int key;
            if (!int.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Invalid key, try again.");
                continue;
            }

            string resultText = operation == "encrypt" ? Encrypt(inputText, key) : Decrypt(inputText, key);
            Console.WriteLine($"{(operation == "encrypt" ? "Encrypted" : "Decrypted")} text: {resultText}");

            Console.WriteLine("Do you wish to continue?");
            string response = Console.ReadLine().ToLower();

            if (response != "yes")
            {
                continueRunning = false;
            }
        }

        Console.WriteLine("Press any key to finish.");
        Console.ReadKey(); // Wait for a key press before closing
    }

    static string Encrypt(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsUpper(letter))
            {
                letter = (char)((((letter - 'A' + shift) % 26 + 26) % 26) + 'A');
            }
            else if (char.IsLower(letter))
            {
                letter = (char)((((letter - 'a' + shift) % 26 + 26) % 26) + 'a');
            }

            buffer[i] = letter;
        }
        return new string(buffer);
    }

    static string Decrypt(string text, int shift)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsUpper(letter))
            {
                letter = (char)((((letter - 'A' - shift) % 26 + 26) % 26) + 'A');
            }
            else if (char.IsLower(letter))
            {
                letter = (char)((((letter - 'a' - shift) % 26 + 26) % 26) + 'a');
            }

            buffer[i] = letter;
        }
        return new string(buffer);
    }
}
