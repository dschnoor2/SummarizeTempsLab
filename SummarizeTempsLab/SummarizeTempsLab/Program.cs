using System;

using System.IO;

namespace SummarizeTempsLab

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Summarize Temperatures Lab***");
            string fileName;
             
            bool userContinue = true;
            string choice = "";

            // temperature data is in temps.txt
            // Write out prompt to the console
            Console.WriteLine("Enter filename");
            fileName = Console.ReadLine();

            // Test whether file exists

            // If the file exists
            if (File.Exists(fileName))
                {
              Console.WriteLine("File Exist");
                           
                //Loop for userContinue
                while (userContinue)
                {
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
                          
                           // If the current temperature value >= threshold 
                           if (temp >= threshold)
                           {
                              // Increment "above" counter by 1
                              numAbove += 1;
                           }
                              // Else (temperature is below)
                           else
                           {
                                
                               // Increment "below" counter by 1
                               numBelow += 1;
                           }

                                line = sr.ReadLine();
                        }
                    }

                    // Print out temperatures above the threshold
                    Console.WriteLine("Temperatures Above = " + numAbove);
                    Console.WriteLine("Temperatured Below = " + numBelow);

                    int average = sumTemps / (numAbove + numBelow);

                    Console.WriteLine("Average Temperature = " + average);

                    //Print out Total Temps
                    Console.WriteLine("Total number of Temperatures = " + (numAbove +numBelow));

                    using (StreamWriter sw = new StreamWriter("output.txt"))
                    {
                        sw.WriteLine("***Summary Temperatures Lab***");
                        sw.WriteLine(System.DateTime.Now.ToString());
                        sw.WriteLine("Temps Above = " + numAbove);
                        sw.WriteLine("Temps Below = " + numBelow);
                        sw.WriteLine("Average Temp = " + average);
                        sw.WriteLine("Total Number of Temperatures = " + (numAbove + numBelow));
                    }
                
                    //Write Line to console "Do you Wish to Continue?
                    Console.WriteLine("Do you wish to coninue? Enter yes or no");
                    choice = Console.ReadLine();

                    if (choice == "yes")
                    {
                       continue;
                    }
                    else
                    {
                       userContinue = false;

                       //Write Line to Console "Program has Ended"
                       Console.WriteLine("Program has Ended...THANK YOU!");
                    }
               
                }
            }
                else
                {
                    //Else (file does not exist)
                    //Tell the user the file does not exist
                    Console.WriteLine("File does not exist!");
                }
            
        }

    }

}