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

    }
}

