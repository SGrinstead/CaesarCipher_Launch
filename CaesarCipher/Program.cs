using System;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //asks for a message to encrypt then saves it
            string message = MessageInput();

            //asks for a number to shift the message by
            int shift = ShiftInput();

            //displays result
            var encryptedMessage = Encrypt(message, shift);
            DisplayResult(encryptedMessage);
        }

        static string Encrypt(string message, int shift)
        {
            //array of alphabet
            char[] alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            //alphabet offset by shift value
            char[] cipherAlphabet = GetOffsetAlphabet(alphabet, shift);

            //turns message into an array of char
            char[] splitMessage = message.ToCharArray();

            //empty string to hold encrypted message
            string encrypted = "";

            foreach (var letter in splitMessage)
            {
                //if its a valid letter
                if (alphabet.Contains(letter))
                {
                    //adds offset letter to encrypted string
                    int indexOfLetter = Array.IndexOf(alphabet, letter);
                    char encryptedLetter = cipherAlphabet[indexOfLetter];
                    encrypted += encryptedLetter;
                }
                //special characters and upper characters dont get changed
                else
                {
                    encrypted += letter;
                }
            }

            //returns the encrypted message
            return encrypted;
        }

        static string MessageInput()
        {
            Console.Write("Enter a message to Encrypt: ");
            return Console.ReadLine();
        }

        static int ShiftInput()
        {
            Console.Write("Enter a shift value (1 - 26): ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static char[] GetOffsetAlphabet(char[] alphabet, int shift)
        {
            char[] cipherAlphabet = new char[26];
            Array.Copy(alphabet, shift, cipherAlphabet, 0, 26 - shift);
            Array.Copy(alphabet, 0, cipherAlphabet, 26 - shift, shift);
            return cipherAlphabet;
        }

        static void DisplayResult(string encryptedMessage)
        {
            Console.WriteLine(encryptedMessage);
        }
    }
}
