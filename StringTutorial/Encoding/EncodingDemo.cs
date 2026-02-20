using System;
using System.Text;

namespace StringTutorial.EncodingDemo
{
    public class EncodingOperations
    {
        public static void Run()
        {
            Console.WriteLine("String Encoding and Decoding\n");

            string text = "Hello, World! 你好";

            // UTF-8 Encoding
            Console.WriteLine("1. UTF-8 Encoding:");
            byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(text);
            Console.WriteLine($"   Original: '{text}'");
            Console.WriteLine($"   UTF-8 Bytes: {utf8Bytes.Length} bytes");
            Console.WriteLine($"   Bytes: {BitConverter.ToString(utf8Bytes).Substring(0, Math.Min(50, BitConverter.ToString(utf8Bytes).Length))}...");
            string utf8Decoded = System.Text.Encoding.UTF8.GetString(utf8Bytes);
            Console.WriteLine($"   Decoded: '{utf8Decoded}'");

            // UTF-16 Encoding
            Console.WriteLine("\n2. UTF-16 Encoding:");
            byte[] utf16Bytes = System.Text.Encoding.Unicode.GetBytes(text);
            Console.WriteLine($"   UTF-16 Bytes: {utf16Bytes.Length} bytes");
            string utf16Decoded = System.Text.Encoding.Unicode.GetString(utf16Bytes);
            Console.WriteLine($"   Decoded: '{utf16Decoded}'");

            // ASCII Encoding
            Console.WriteLine("\n3. ASCII Encoding:");
            string asciiText = "Hello, World!";
            byte[] asciiBytes = System.Text.Encoding.ASCII.GetBytes(asciiText);
            Console.WriteLine($"   Original: '{asciiText}'");
            Console.WriteLine($"   ASCII Bytes: {asciiBytes.Length} bytes");
            Console.WriteLine($"   Bytes: {BitConverter.ToString(asciiBytes)}");
            string asciiDecoded = System.Text.Encoding.ASCII.GetString(asciiBytes);
            Console.WriteLine($"   Decoded: '{asciiDecoded}'");

            // Base64 Encoding
            Console.WriteLine("\n4. Base64 Encoding:");
            string plainText = "Hello, World!";
            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string base64 = Convert.ToBase64String(plainBytes);
            Console.WriteLine($"   Original: '{plainText}'");
            Console.WriteLine($"   Base64: '{base64}'");
            byte[] decodedBytes = Convert.FromBase64String(base64);
            string decoded = System.Text.Encoding.UTF8.GetString(decodedBytes);
            Console.WriteLine($"   Decoded: '{decoded}'");

            // Encoding comparison
            Console.WriteLine("\n5. Encoding Size Comparison:");
            string sample = "Hello";
            Console.WriteLine($"   Text: '{sample}'");
            Console.WriteLine($"   ASCII: {System.Text.Encoding.ASCII.GetBytes(sample).Length} bytes");
            Console.WriteLine($"   UTF-8: {System.Text.Encoding.UTF8.GetBytes(sample).Length} bytes");
            Console.WriteLine($"   UTF-16: {System.Text.Encoding.Unicode.GetBytes(sample).Length} bytes");
            Console.WriteLine($"   UTF-32: {System.Text.Encoding.UTF32.GetBytes(sample).Length} bytes");

            // Character encoding info
            Console.WriteLine("\n6. Character Encoding Info:");
            Console.WriteLine($"   Default Encoding: {System.Text.Encoding.Default.EncodingName}");
            Console.WriteLine($"   UTF-8 Code Page: {System.Text.Encoding.UTF8.CodePage}");
            Console.WriteLine($"   ASCII Code Page: {System.Text.Encoding.ASCII.CodePage}");
        }
    }
}
