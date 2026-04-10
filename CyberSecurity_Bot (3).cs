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
        private void ChatLoop()
        {
            while (true)
            {
                // Prompt user input in yellow
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(UserName + " : ");
                Console.ResetColor();

                string input = Console.ReadLine();

                // Validate input
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: Please type something," + UserName + ".");
                    continue;
                }

                // Convert input to lowercase for easier matching
                input = input.ToLower();

                // Exit condition
                if (input.Contains("exit"))
                {
                    Console.WriteLine("Bot: Goodbye! Stay safe online, " + UserName + "!");
                    break;
                }
                // Generate response based on user input
                Respond(input);
            }

        }
        // Handles chatbot responses based on keywords
        private void Respond(string input)
        {
            // Set bot response color
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Bot: ");

            // Convert input to lowercase for consistent matching
            string lowerInput = input.ToLower().Trim();

            // Define response patterns (keeping your original responses)
            var responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["how are you"] = "I'm great! Thanks for asking",
                ["purpose"] = "I help you stay safe online by teaching cybersecurity.",
                ["ask"] = "You can ask about passwords, phishing, and safe browsing.",
                ["password"] = "Use strong passwords with letters, numbers, and symbols.",
                ["phishing"] = "Phishing tricks you into giving personal info. Be careful of suspicious emails.",
                ["safe browsing"] = "Always check for HTTPS and avoid unknown links."
            };


            // Check for matches in order of specificity (longer patterns first to avoid partial matches)
            var sortedResponses = responses.OrderByDescending(r => r.Key.Length);
            bool foundMatch = false;

            foreach (var kvp in sortedResponses)
            {
                if (lowerInput.Contains(kvp.Key.ToLower()))
                {
                    TypeText(kvp.Value);
                    foundMatch = true;
                    break;
                }
            }

            // Default response if no match found
            if (!foundMatch)
            {
                TypeText("I didn't quite understand that. Could you rephrase");
            }

            // Reset console color
            Console.ResetColor();
        }

        // Displays text with a typing animation effect
        private void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);     // Print each character
                Thread.Sleep(20);     // Delay to simulate typing
            }
            Console.WriteLine();      // Move to next line after message
        }
    }
}