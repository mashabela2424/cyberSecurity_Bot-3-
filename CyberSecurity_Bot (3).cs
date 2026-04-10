using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurirty_awareness_ChatBot_3_
{
    public class Program
    {
        static void Main(string[] args)
        {

  // Property to store the user's name
        public string UserName { get; set; }

        // Constructor - automatically starts the chatbot when an object is created
        public program()
        {
            StartChat();
        }

        // Main method to control chatbot flow
        private void StartChat()
        {
            string project_location = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine(project_location);
             
            string updated_path = project_location.Replace("bin\\Debug\\", "");

            string full_path = Path.Combine(updated_path, "greeting.wav");

            PlayVoiceGreeting(full_path);   // Play audio greeting
            DisplayAsciiArt();     // Show logo in ASCII format
            GetUserName();         // Prompt user for their name
            ChatLoop();            // Start interaction loop
        }
        // Plays a voice greeting from a .wav file
        private void PlayVoiceGreeting(string full_path)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(full_path))
                {
                    player.PlaySync();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);

            }

        }

        // Converts an image into ASCII art and displays it in the console
        private void DisplayAsciiArt()
        {
            // Get the application's base directory
            string project_path = AppDomain.CurrentDomain.BaseDirectory;

            // Remove the "bin\\Debug\\" part to reach project root folder
            string new_project_path = project_path.Replace("bin\\Debug\\", "");

            // Combine project path with image file name
            string full_path = Path.Combine(new_project_path, "chatbotlogo.jpeg");

            // Load image and resize it for console display
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(210, 200));

            // Loop through each pixel row (height)
            for (int height = 0; height < image.Height; height++)
            {
                // Loop through each pixel column (width)
                for (int width = 0; width < image.Width; width++)
                {


                    for (int width = 0; width < image.Width; width++)
                    {
                        // Get pixel color at current position
                        Color pixelColor = image.GetPixel(width, height);

                        // Calculate brightness by summing RGB values
                        int color = (pixelColor.R + pixelColor.G + pixelColor.B);

                        // Map brightness to ASCII characters (lighter → '.', darker → '@')
                        char ascii_design = color > 200 ? '.' :
                                            color > 150 ? '*' :
                                            color > 100 ? '0' :
                                            color > 50 ? '#' : '@';

                        // Print ASCII character to console
                        Console.Write(ascii_design);
                    }

                    // Move to next line after each row
                    Console.WriteLine();


                }
            }

        // Prompts user for their name and validates input
        private void GetUserName()
        {
            Console.Write("Enter your name: ");
            UserName = Console.ReadLine();

            // Ensure name is not empty or whitespace
            while (string.IsNullOrWhiteSpace(UserName))
            {
                Console.Write("Name cannot be empty. Try again: ");
                UserName = Console.ReadLine();
            }

            // Display welcome message in green text
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();//Skip a line
            Console.WriteLine("******************************************************************");
            Console.WriteLine($"Welcome to Cybersecurity Awareness ChatBot, {UserName}!");
            Console.WriteLine("******************************************************************");
            Console.ResetColor();
        }

    }
}
        }

