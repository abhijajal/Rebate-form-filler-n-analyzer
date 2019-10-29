using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Asg2_apj180001
{
    //Class that handles all the IO operations from and to the .txt file.
    public class IO
    {
        public const string path = @"CS6326Asg2.txt"; //path and the name of the file.
        private static List<List<String>> fileData;
        // Variable to load and unload data from and to the file.
        


        public static Boolean IsEmailValid(string EmailAddr)
        {
            // Just a simple function for validating the email             
            if (EmailAddr != null || EmailAddr != "")
            {
                Regex n = new Regex("(?<user>[^@]+)@(?<host>.+)");
                Match v = n.Match(EmailAddr);
                if (!v.Success || EmailAddr.Length != v.Length)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static List<string> listOfStateCodes()
        {
            // Function which will return list of state codes, which can be later consumed by the comboBox for state.
            List<string> listOfStateCode = new List<string>();
            listOfStateCode.Add("AL");
            listOfStateCode.Add("AK");
            listOfStateCode.Add("AZ");
            listOfStateCode.Add("AR");
            listOfStateCode.Add("CA");
            listOfStateCode.Add("CO");
            listOfStateCode.Add("CT");
            listOfStateCode.Add("DE");
            listOfStateCode.Add("DC");
            listOfStateCode.Add("FL");
            listOfStateCode.Add("GA");
            listOfStateCode.Add("GA");
            listOfStateCode.Add("HI");
            listOfStateCode.Add("ID");
            listOfStateCode.Add("IL");
            listOfStateCode.Add("IN");
            listOfStateCode.Add("IA");
            listOfStateCode.Add("KS");
            listOfStateCode.Add("KY");
            listOfStateCode.Add("LA");
            listOfStateCode.Add("ME");
            listOfStateCode.Add("MD");
            listOfStateCode.Add("MA");
            listOfStateCode.Add("MI");
            listOfStateCode.Add("MN");
            listOfStateCode.Add("MS");
            listOfStateCode.Add("MO");
            listOfStateCode.Add("MT");
            listOfStateCode.Add("NE");
            listOfStateCode.Add("NV");
            listOfStateCode.Add("NH");
            listOfStateCode.Add("NJ");
            listOfStateCode.Add("NM");
            listOfStateCode.Add("NY");
            listOfStateCode.Add("NC");
            listOfStateCode.Add("ND");
            listOfStateCode.Add("OH");
            listOfStateCode.Add("OK");
            listOfStateCode.Add("OR");
            listOfStateCode.Add("PA");
            listOfStateCode.Add("RI");
            listOfStateCode.Add("SC");
            listOfStateCode.Add("SD");
            listOfStateCode.Add("TN");
            listOfStateCode.Add("TX");
            listOfStateCode.Add("UT");
            listOfStateCode.Add("VT");
            listOfStateCode.Add("VA");
            listOfStateCode.Add("WA");
            listOfStateCode.Add("WV");
            listOfStateCode.Add("WI");
            listOfStateCode.Add("WY");

            return listOfStateCode;
        }

        public static void readDataFromFile()
        {
            //Function that will read data from the .txt file and load it into fileData variable;
            fileData = new List<List<string>>();

            if (File.Exists(path)) //if the file already exisits then only we can read from it.
            {
                string line;
                System.IO.StreamReader file =
        new System.IO.StreamReader(@path);
                
                while ((line = file.ReadLine()) != null) // Repeating for each line in .txt file.
                {
                    List<string> list = new List<string>();
                    System.Console.WriteLine(line);
                    String[] items = line.Split('\t');
                    // separating each data field using 'tabs'.
                    System.Console.WriteLine(items.Length);
                    string fullName = items[0];
                    //KeyGeneration
                    //Well, this is not a Database, hence there is no key, But just for faster record validation (Is case of indentifying duplicate records.)
                    // I have created a key, which would only be store, in the variable inside the program, But not in the .txt file.
                    //Key is just contactenation of first name,last name and phonenumber and its stored in the variable at index "0".
                    if (items.Length == 15)
                    {
                        if (items[1].Length == 1 && Char.IsUpper(items[1][0]) && items[4].Length <= 25)
                        {
                            //Middle Name present hence, last name would be at "2".
                            list.Add(items[0] + items[2] + items[8]);

                         }
                        else
                        {   //Middle Name not present,Hence last name would be at "1".
                            list.Add(items[0] + items[1] + items[8]); 
                        }
                    }
                    else if (items.Length == 16)
                    {
                        //Middle Name present hence, and address line 2 present , Hence last name would be at "2" & phone number at "9".
                        list.Add(items[0] + items[2] + items[9]);   
                    }
                    else if (items.Length == 14)
                    {
                        //No middlename, No address line 2, Hence last name would be at "1" and phone number at "7".
                        list.Add(items[0] + items[1] + items[7]);
                    }

                    foreach (string it in items)
                    {
                        list.Add(it);
                    }
                    fileData.Add(list); //finally, adding the created list to the variable.
                }
                file.Close();
            }
        }


        public static void writeDataToFile()
        {   
            //This function would write everything stored in fileData variable into .txt file.
            if (!File.Exists(path)) // If file does not exits, create the file.
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                foreach (List<string> itemList in fileData) //For each list in the fileData
                {
                    string data = "";
                    foreach (String item in itemList)
                    {
                        if (itemList.IndexOf(item) == 0)     //Not adding the key, to txt file.
                        {

                        }
                        else if (itemList.IndexOf(item) == 1) // Adding the firstname.
                        {
                            data += item;
                        }
                        else                               // Adding all the remaing fields preceded by tab.
                        {
                            data += "\t" + item;
                        }
                    }
                    tw.WriteLine(data); // Writing the line in to .txt file.

                }
                tw.Close();
            }
            else if (File.Exists(path)) // File already exists, open the file in write mode (not-append). 
            {
                using (var tw = new StreamWriter(path, false))
                {
                    foreach (List<string> itemList in fileData) //For each list in the fileData
                    {
                        string data = "";
                        foreach (String item in itemList)
                        {
                            if (itemList.IndexOf(item) == 0)   //Not adding the key, to txt file.
                            {

                            }
                            else if (itemList.IndexOf(item) == 1) // Adding the firstname.
                            {
                                data += item;
                            }
                            else                               // Adding all the remaing fields preceded by tab
                            {
                                data += "\t" + item; 
                            }
                        }
                        tw.WriteLine(data);    // Writing the line in to .txt file.

                    }
                    tw.Close();
                }
            }
        }

        public static bool isKeyPresent(string key)
        {
            //Function that checks, where the key matches with any other existing records.
            //Key is just contactenation of first name, last name and phone number, and its just for easy validation.
            foreach (List<string> list in fileData)
            {
                if (list[0] == key)
                    return true;
            }
            return false;
        }

        public static List<List<String>> getFileData()
        {   //Returing the fileData variable, thereby enabling the sharing of information between IO and Form1 class.
            return fileData;
        }

        public static void removeFromFileData(int index)
        {
            //Funtion that deletes a list at the given index from fileData;
            fileData.RemoveAt(index);
        }

        public static void addListToFileData(List<string> list)
        {
            //Function that appends the list item to fileData variable.
            fileData.Add(list);
        }

        public static List<string> getListFromFileData(int index)
        {
            // Function that returns the specific list from the fileData at a given index.
            return fileData[index];

        }
    }
}