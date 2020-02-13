using System;

using System.IO;

namespace SummarizeTempsLab

{
    class Program
    {
        static void Main(string[] args)
        {

             string fileName;

            // temperature data is in temps.txt
            // Write out prompt to the console
            Console.WriteLine("Enter filename");
            // Read the filename from the console
            fileName = Console.ReadLine();

            // Test whether file exists

            // If the file exists
            if (File.Exists(fileName))
            {
                Console.WriteLine("File Exist");
                // Ask the user to enter the temperature threshold
                Console.WriteLine("Enter Threshold");
                string input;
                int threshold;
                input = Console.ReadLine();
                threshold = int.Parse(input);

                int sumTemps = 0;
                int numAbove = 0;
                int numBelow = 0;

                // Open the file and create Steam Reader
                // Read a line into a string variable
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string line = sr.ReadLine();
                    int temp;
                    // While the line is not null
                    while (line != null)
                    {
                        // Convert (parse) into an integer variable
                        temp = int.Parse(line);

                        // Add Temperature to summing variable
                        sumTemps += temp;
                        Console.WriteLine(sumTemps);

                        // If the current temperature value >= threshold 
                        if (temp >= threshold)
                        {
                            // Increment "above" counter by 1
                            numAbove += 1;
                        }

                        else
                        {
                            // Else (temperature is below)
                            // Increment "below" counter by 1
                            numBelow += 1;
                        }
                        
                        line = sr.ReadLine();
                    }
                }

                // Print out temperatures above the threshold
                Console.WriteLine("Temps Above = " + numAbove);
                // Print out temperatures below the threshold
                Console.WriteLine("Temps below = " + numBelow);

                // Calculate the average
                int average = sumTemps / (numAbove + numBelow);

                // Print out average
                Console.WriteLine("Average Temperature = " + average);
            }     
            

            else
            {
                //Else (file does not exist)
                //Tell the user the file does not exist
                Console.WriteLine("File does not exist");
            }

        }

    }

}