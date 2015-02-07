//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters.
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first 
//letter of the string with the first of the key, the second – with the second, etc. When 
//the last key character is reached, the next is the first.

using System;
using System.Text;
class EncodeDecode
{
    static void Main()
    {
        Console.Write("Enter: ");
        string message = Console.ReadLine();
        Console.Write("Enter chip: ");
        string cipher = Console.ReadLine();
        string encoded = EncodeMessage(message, cipher);
        string decoded = DecodeMessage(encoded, cipher);
        Console.WriteLine("Encoded message is: " + encoded);
        Console.WriteLine("Decoded message is: " + decoded);
    }

    //They are the same, but for more clear understanding I did it this way
    static string EncodeMessage(string input, string key)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            result.Append((char)(input[i] ^ key[i % key.Length]));
        }

        return result.ToString();
    }

    static string DecodeMessage(string input, string key)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            result.Append((char)(input[i] ^ key[i % key.Length]));
        }

        return result.ToString();
    }
}