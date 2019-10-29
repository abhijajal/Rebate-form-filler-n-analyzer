/*
 * This class interacts with the Files and also with Form1.cs via function calls.
 * By: APJ180001
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg3_apj180001
{   

    class FileIO
    {
        private static string filePath; // path for the file, which user has opened.
        private static string outputFilePath = @"CS6326Asg3.txt"; // path for creating an output file
        private static string results; // string to store the final results.
        public static void setFilePath(string path) // sets the filePath
        {
            filePath = path;
            
        }

        public static string getResults() // returns the filePath
        {
            return results;
        }

        public static void loadFile() // loads the user specified file for evaluation.
        {
            if (File.Exists(filePath)) //if the file already exisits then only we can read from it.
            {
                string line;
                results = "";
                System.IO.StreamReader file =
        new System.IO.StreamReader(filePath);
                // For storing no of Records and Backspaces.
                int noOfRecords = 0;
                int noOfBackspaces = 0;
                // For storing various timeIntervals
                TimeSpan maxTime = new TimeSpan(0,0,0);
                TimeSpan minTime = new TimeSpan(24,0,0);
                TimeSpan totalTime= new TimeSpan(0,0,0);
                TimeSpan maxInrTime = new TimeSpan(0, 0, 0);
                TimeSpan minInrTime = new TimeSpan(24, 0, 0);
                TimeSpan totalInrTime = new TimeSpan(0, 0, 0);
                TimeSpan inrTimeTaken = new TimeSpan(0, 0, 0);
                TimeSpan timeTaken = new TimeSpan(0,0,0);
                // For storing the last time user, clicked on save button
                DateTime lastSavedTime = DateTime.Now;

                while ((line = file.ReadLine()) != null) // Repeating for each line in .txt file.
                {
                    noOfRecords += 1; 
                    string[] items = line.Split('\t');
                    // separating each data field using 'tabs'.
                    
                    if (items.Length == 15)
                    {
                        if (items[1].Length == 1 && Char.IsUpper(items[1][0]) && items[4].Length <= 25)
                        {
                            //Middle Name present hence, last name would be at "2".
                            noOfBackspaces+=Int32.Parse(items[14]);
                            if (noOfRecords != 1) // if its not the first record then, you can calculate inter record time intervals
                            {
                                // Substracting last time when save button was pressed from the time to enter into first field 
                                inrTimeTaken = Convert.ToDateTime(items[12]).Subtract(lastSavedTime);
                                // Adding the time to totalInrTime 
                                totalInrTime=totalInrTime.Add(inrTimeTaken);

                            }
                            lastSavedTime = Convert.ToDateTime(items[13]);    
                            timeTaken =Convert.ToDateTime(items[13]).Subtract(Convert.ToDateTime(items[12]));
                            Console.WriteLine(timeTaken);
                        }
                        else
                        {   //Middle Name not present,Hence last name would be at "1".
                            noOfBackspaces += Int32.Parse(items[14]);
                            if (noOfRecords != 1)
                            {
                                inrTimeTaken = Convert.ToDateTime(items[12]).Subtract(lastSavedTime);
                                totalInrTime= totalInrTime.Add(inrTimeTaken);
                            }
                            lastSavedTime = Convert.ToDateTime(items[13]);
                            timeTaken = Convert.ToDateTime(items[13]).Subtract(Convert.ToDateTime(items[12]));

                        }
                    }
                    else if (items.Length == 16)
                    {
                        //Middle Name present hence, and address line 2 present , Hence last name would be at "2" & phone number at "9".
                        noOfBackspaces += Int32.Parse(items[15]);
                        if (noOfRecords != 1)
                        {
                            inrTimeTaken = Convert.ToDateTime(items[13]).Subtract(lastSavedTime);
                            totalInrTime= totalInrTime.Add(inrTimeTaken);
                        }
                        lastSavedTime = Convert.ToDateTime(items[14]);
                        timeTaken = Convert.ToDateTime(items[14]).Subtract(Convert.ToDateTime(items[13]));

                    }
                    else if (items.Length == 14)
                    {
                        //No middlename, No address line 2, Hence last name would be at "1" and phone number at "7".
                        noOfBackspaces += Int32.Parse(items[13]);
                        if (noOfRecords != 1) 
                        {
                            inrTimeTaken = Convert.ToDateTime(items[11]).Subtract(lastSavedTime);
                            totalInrTime= totalInrTime.Add(inrTimeTaken);
                        }
                        lastSavedTime = Convert.ToDateTime(items[12]);
                        timeTaken = Convert.ToDateTime(items[12]).Subtract(Convert.ToDateTime(items[11]));

                    }
                    if(noOfRecords != 1)
                    {
                        if (TimeSpan.Compare(minInrTime, inrTimeTaken) == 1) // returns true if minInrTime is greater than inrTimeTaken
                        {
                            minInrTime = inrTimeTaken;
                        }
                        if (TimeSpan.Compare(maxInrTime, inrTimeTaken) == -1) // returns true if maxInrTime is lesser than inrTimeTaken
                        {
                            maxInrTime = inrTimeTaken;
                        }
                    }
                    if (TimeSpan.Compare(minTime,timeTaken) == 1)
                    {
                        minTime = timeTaken;
                    }
                    if (TimeSpan.Compare(maxTime, timeTaken) == -1)
                    {
                        maxTime = timeTaken;
                    }

                    //finally, adding the time intervals to total time.
                    totalTime = totalTime.Add(timeTaken);

                }
                file.Close();
                //Contacting everything to results 
                results += "Number of records: "+noOfRecords;
                results += "\r\n";
                
                results += "Minimum entry time: " + minTime.Minutes+":"+minTime.Seconds.ToString("00");
                results += "\r\n";

                results += "Maximum entry time: " + maxTime.Minutes + ":" + maxTime.Seconds.ToString("00");
                results += "\r\n";

                TimeSpan averageTime = new TimeSpan(totalTime.Ticks / noOfRecords);
                results += "Average entry time: " + averageTime.Minutes + ":" + averageTime.Seconds.ToString("00"); 
                results += "\r\n";

                results += "Minimum inter-record time: " + minInrTime.Minutes + ":" + minInrTime.Seconds.ToString("00");
                results += "\r\n";

                results += "Maximum inter-record time: " + maxInrTime.Minutes + ":" + maxInrTime.Seconds.ToString("00");
                results += "\r\n";

                TimeSpan averageInrTime = new TimeSpan(totalInrTime.Ticks / (noOfRecords-1)); //Since, there would be only 9 inter-record intervals
                results += "Average inter-record time: " + averageInrTime.Minutes + ":" + averageInrTime.Seconds.ToString("00");
                results += "\r\n";

                totalTime = totalTime.Add(totalInrTime);
                results += "Total time: " + totalTime.Minutes + ":" + totalTime.Seconds.ToString("00"); ;

                results += "\r\n";
                results += "Backspace count: " + noOfBackspaces;


            }
            
       }

        public static void writeToFile()
        {
            //This function would write everything stored in results to .txt file.
            if (!File.Exists(outputFilePath)) // If file does not exits, create the file.
            {
                var file=File.Create(outputFilePath);
                file.Close();
                TextWriter tw = new StreamWriter(outputFilePath);
                tw.WriteLine(results); // Writing the line in to .txt file
                tw.Close();
                
            }
            else if (File.Exists(outputFilePath)) // File already exists, open the file in write mode (not-append). 
            {
                using (var tw = new StreamWriter(outputFilePath, false))
                {
                    tw.WriteLine(results);    // Writing the line in to .txt file.
                    tw.Close();
                }
            }
        }
    }
}
