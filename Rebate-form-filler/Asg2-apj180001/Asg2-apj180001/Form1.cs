using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Asg2_apj180001
{

    public partial class Form1 : Form
    {
        private const float V = (float) 1.5;
        int index; //to store which record is currently being modified from the list view.
        string timeToSave = "none"; // variable to store the time in string, when user clicks on save button.
        string timeToFirstEntry = "none"; // variable to store the time in string, when user enters something in the first field. i.e first name.
        int noOfBackspaces = 0; // variable to count the no of times backspace was pressed while entering the form details.
        int oldHeight = 0;
        int oldWidth = 0;
        int newHeight = 0;
        int newWidth = 0;
        public Form1()
        {
            InitializeComponent();
            initComboState(); // Intializes the combo box for state selection.

            this.KeyPreview = true; // Setting this to true, for adding the KeyPressEventHandler.
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);  // Handler, for registering keyPresses called each time user inputs something.
            loadDataInListView(); // Loads the data in the list view.
            dateRecieved.MaxDate = DateTime.Today; //Setting the max date for dataRecieved to today.
            stripLabel.Text = "Add"; //showing the current mode is Add mode.

        }

        private void initComboState()
        {
            // Gets the list of state codes from IO class, and appends into the state combo box.
           foreach (string eachStateCode in IO.listOfStateCodes())
            {
                comboState.Items.Add(eachStateCode);
            }
        }

        private void loadDataInListView()
        {
            //Loads the data into the list view
            IO.readDataFromFile(); // Loads the data in to fileData from the .txt file.
            ListViewItem li;
            listView1.Items.Clear(); // Making sure, its empty, everytime, we reload the data.
            foreach (List<string> listOfStrings in IO.getFileData())  // For each list in fileData
            {
                string fullName = listOfStrings[1]; //Since, "0" has the key.
                //fullName is contactination of FirstName, Middle Name (if present) and Last name to be displayed in the list view.
                if (listOfStrings.Count == 16)
                {
                    if (listOfStrings[2].Length == 1 && Char.IsUpper(listOfStrings[2][0]) && listOfStrings[5].Length <= 25)
                    {
                        //Middle Name present, address line not present.
                        fullName += " " + listOfStrings[2] + " " + listOfStrings[3];
                        li = listView1.Items.Add(fullName); // Adding fullName to the list view
                        li.SubItems.Add(listOfStrings[9]);  // Adding phone number to list view
                    }
                    else
                    {
                        //Middle name not present, address line 2 present.
                        fullName += " " + listOfStrings[2];
                        li = listView1.Items.Add(fullName);
                        li.SubItems.Add(listOfStrings[9]);
                    }
                }
                else if (listOfStrings.Count == 17)
                {
                    //Middle name present and address line 2 also present.
                    fullName += " " + listOfStrings[2] + " " + listOfStrings[3];
                    li = listView1.Items.Add(fullName);
                    li.SubItems.Add(listOfStrings[10]);

                }
                else if (listOfStrings.Count == 15)
                {
                    //Middle name not present, address line 2 also not present.
                    fullName += " " + listOfStrings[2];
                    li = listView1.Items.Add(fullName);
                    li.SubItems.Add(listOfStrings[8]);
                }
            }
        }
        


       
        private void ComboPofa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 
            if (!(comboPofa.SelectedIndex > -1))
            {
                comboPofa.BackColor = Color.Red;
            }
            else
            {
                comboPofa.BackColor = Color.White;
            }
            updateButtons();
        }

        
        private void TextEmail_TextChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 
            if(!IO.IsEmailValid(textEmail.Text))
            {
                textEmail.BackColor = Color.Red;
            }
            else
            {
                textEmail.BackColor = Color.White;
            }

            updateButtons();

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 

            updateButtons();

        }

        private void ComboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 
            if (!(comboGender.SelectedIndex>-1))
            {
                comboGender.BackColor = Color.Red;
            }
            else
            {
                comboGender.BackColor = Color.White;
            }
            updateButtons();

        }

        private void ComboState_SelectedIndexChanged(object sender, EventArgs e)
        {

            //updates the status of the buttons when the event happens. 
            if (!(comboState.SelectedIndex > -1))
            {
                comboState.BackColor = Color.Red;
            }
            else
            {
                comboState.BackColor = Color.White;
            }
            updateButtons();

        }

        private void TextLastName_TextChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 
            if (!(textLastName.TextLength>0))
            {
                textLastName.BackColor = Color.Red;
            }
            else
            {
                textLastName.BackColor = Color.White;
            }
            updateButtons();

        }

        private void MaskedZipCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //updates the status of the buttons when the event happens. 
               
            updateButtons();

        }
        


        private void Form1_Load(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 

            updateButtons();

        }

        private void TextFirstName_TextChanged(object sender, EventArgs e)
        {
            //If it is the first name, input has changed in first name, then save the time to timeToFirstEntry.
            if (!(textFirstName.TextLength > 0))
            {
                textFirstName.BackColor = Color.Red;
            }
            else
            {
                textFirstName.BackColor = Color.White;
            }

            if (timeToFirstEntry=="none")
            {
                timeToFirstEntry= DateTime.Now.ToString("h:mm:ss tt");
            }
            //updates the status of the buttons when the event happens. 

            updateButtons();

        }

        private void enableButton(String buttonName)
        {
            //Enables a given button.
            //Save and Modify are the same button, changes into one another, based on the scenario.
            switch(buttonName)
            {
                case "save":
                    buttonSave.Enabled = true;
                    break;
                case "clear":
                    buttonClear.Enabled = true;
                    break;
                case "delete":
                    buttonDelete.Enabled = true;
                    break;
                case "modify":
                    buttonSave.Enabled = true;
                    stripLabel.Text = "Modify";
                    buttonSave.Text = "Modify";
                    break;

            };
        }
        private void disableButton(String buttonName)
        {
            //Disables a given button.
            //Save and Modify are the same button, changes into one another, based on the scenario.
            switch (buttonName)
            {
                case "save":
                    buttonSave.Enabled = false;
                    break;
                case "clear":
                    buttonClear.Enabled = false;
                    break;
                case "delete":
                    buttonDelete.Enabled = false;
                    break;
                case "modify":
                    buttonSave.Enabled = false;
                    buttonSave.Text = "Save";
                    stripLabel.Text = "Add";
                    break;

            };
        }

        void updateButtons()
        {  // When DataEntered is Sufficient and valid.
            if (textFirstName.TextLength > 0 && textLastName.TextLength > 0 &&
               textAddr1.TextLength > 0 && textCity.TextLength > 0 &&
               comboState.SelectedIndex > -1 && maskedZipCode.MaskCompleted &&
               comboGender.SelectedIndex > -1 && textPhoneNo.TextLength > 0 &&
               IO.IsEmailValid(textEmail.Text) && comboPofa.SelectedIndex > -1)
            {
                string key = textFirstName.Text + textLastName.Text + textPhoneNo.Text;
                if (buttonSave.Text == "Save") // if we are in add mode.
                {
                    if(IO.isKeyPresent(key) == true )
                    {
                        stripValue.Text = "Record already present"; //updating the message in status strip.
                        disableButton("save");
                    }
                    else
                    {
                        enableButton("save");
                        stripValue.Text = "Click on save button to save";
                       
                    }


                }
                else if (buttonSave.Text == "Modify") // if we are in modified mode.
                {
                    String previousKey=IO.getListFromFileData(index).ElementAt(0);
                    if(key == previousKey)
                    {
                        stripValue.Text = "Make some changes and then Click on Modify button to modify";
                        enableButton("modify");
                    }
                    else
                    {
                        if(IO.isKeyPresent(key))
                        {
                            stripValue.Text = "Record already present, can't modify";
                            buttonSave.Enabled = false;
                        }
                        else
                        {
                            stripValue.Text = "Click on Modify button to modify";
                            enableButton("modify");
                        }
                    }
                }
               

                
            }
            else
            {   // If values are insufficient or invalid.
                disableButton("save");
                if(buttonSave.Text=="Save")
                {
                    stripValue.Text = "Not enough valid data to save";
                }
                else if(buttonSave.Text=="Modify")
                {
                    stripValue.Text = "Not enough valid data to modify";
                }

            }

            // If anything is non- empty.
            if (textFirstName.TextLength > 0 || textLastName.TextLength > 0 ||
               textMiddleName.TextLength >0 || textAddr1.TextLength > 0 || 
               textAddr2.TextLength >0  ||textCity.TextLength > 0 ||
               comboState.SelectedIndex > -1 || maskedZipCode.MaskCompleted ||
               comboGender.SelectedIndex > -1 || textPhoneNo.TextLength > 0 ||
               textEmail.TextLength >0  || comboPofa.SelectedIndex > -1 )
            {

                enableButton("clear");
            }
            else
            {
                disableButton("clear");
            }
        }
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Detects whether "backspace" has been pressed and counts the no of backspaces.
            if(e.KeyChar == 8) // 8 is ascii for backspace.
            {
                noOfBackspaces+=1;
                Console.WriteLine(noOfBackspaces);
            }

            
        }

        

        private void TextCity_TextChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 

            if (!(textCity.TextLength > 0))
            {
                textCity.BackColor = Color.Red;
            }
            else
            {
                textCity.BackColor = Color.White;
            }

            updateButtons();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {

            clearAll();
            disableButton("modify");
            disableButton("delete");
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            //Creating a prompt for deletion
            string message = "Are you sure you want to delete this record?";
            string caption = "Delete";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes) // If clicked yes
            {
                //Removes the list from the fileData and writes the updated data to the .txt file.
                IO.removeFromFileData(index);   
                disableButton("delete");
                writeFileContentstoFile();
                stripValue.Text = "Not enough valid data to save";
                stripLabel.Text = "Add";
            }
            else // If clicked no or closed.
            {
                   
            }

        }

        

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (buttonSave.Text == "Save") // if we are in save mode.
            {
                // If its the first time data has been saved, then save the current time to timeToSave.
                if(timeToSave=="none")
                {
                    timeToSave = DateTime.Now.ToString("h:mm:ss tt");
                }
                addCurrentDataToFileContents();
               
            }
            else if (buttonSave.Text == "Modify") // if we are in modify mode.
            {
                modifyCurrentDataToFileContents();
                disableButton("modify");
            }
            writeFileContentstoFile();
            
        }

        void writeFileContentstoFile()
        {
            //Writing data loaded in fileData variable to .txt file, clearing all inputs and loading the updated data into the list view.
            IO.writeDataToFile();
            clearAll();
            loadDataInListView();
        }

        private void addCurrentDataToFileContents()
        {
            //Adds the current filled data into the fieData after doing validation.
            List<String> currentList = new List<string>();
            string key = textFirstName.Text + textLastName.Text + textPhoneNo.Text;

            if(IO.isKeyPresent(key)== true)
            {
                Console.WriteLine("Record Already present");
            }
            else
            {
                currentList.Add(key);
                currentList.Add(textFirstName.Text);
                if (textMiddleName.TextLength > 0)
                    currentList.Add(textMiddleName.Text);
                currentList.Add(textLastName.Text);
                currentList.Add(textAddr1.Text);
                if (textAddr2.TextLength > 0)
                    currentList.Add(textAddr2.Text);
                currentList.Add(textCity.Text);
                currentList.Add(comboState.Text);
                currentList.Add(maskedZipCode.Text); ;
                currentList.Add(comboGender.Text);
                currentList.Add(textPhoneNo.Text);
                currentList.Add(textEmail.Text);
                currentList.Add(comboPofa.Text);
                currentList.Add(dateRecieved.Value.ToString("MM/dd/yyyy"));
                currentList.Add(timeToFirstEntry);
                currentList.Add(timeToSave);
                currentList.Add(noOfBackspaces.ToString());
                //resetting values
                timeToSave = "none"; 
                timeToFirstEntry = "none";
                noOfBackspaces = 0;
                IO.addListToFileData(currentList);

            }

        }

       

        private void modifyCurrentDataToFileContents()
        {
            //After, validating, updating the data in the fileData.
            string key = textFirstName.Text + textLastName.Text + textPhoneNo.Text;
            if (key != IO.getListFromFileData(index)[0] && IO.isKeyPresent(key))
            {
                Console.WriteLine("Record Already present");
            }
            else
            {
                List<String> item = IO.getListFromFileData(index);
                string timeToFirstEntry = (item.ElementAt(item.Count() - 3));
                string timeToSave = (item.ElementAt(item.Count() - 2));
                string noOfBacks = (item.ElementAt(item.Count()-1));
                item.Clear();
                item.Add(key);
                item.Add(textFirstName.Text);
                if (textMiddleName.TextLength > 0)
                    item.Add(textMiddleName.Text);
                item.Add(textLastName.Text);
                item.Add(textAddr1.Text);
                if (textAddr2.TextLength > 0)
                    item.Add(textAddr2.Text);
                item.Add(textCity.Text);
                item.Add(comboState.Text);
                item.Add(maskedZipCode.Text); ;
                item.Add(comboGender.Text);
                item.Add(textPhoneNo.Text);
                item.Add(textEmail.Text);
                item.Add(comboPofa.Text);
                item.Add(dateRecieved.Value.ToString("MM/dd/yyyy"));
                item.Add(timeToFirstEntry);
                item.Add(timeToSave);
                item.Add(noOfBacks);
                //resetting values.
                timeToSave = "none";
                timeToFirstEntry = "none";
                noOfBackspaces = 0;
            

            }
        }

        private void MaskedZipCode_TextChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 
            if (!(maskedZipCode.MaskCompleted))
            {
                maskedZipCode.BackColor = Color.Red;
            }
            else
            {
                maskedZipCode.BackColor = Color.White;
            }

            updateButtons();
            
        }

        private void TextAddr1_TextChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 
            if (!(textAddr1.TextLength > 0))
            {
                textAddr1.BackColor = Color.Red;
            }
            else
            {
                textAddr1.BackColor = Color.White;
            }

            updateButtons();
        }

        private void TextPhoneNo_TextChanged(object sender, EventArgs e)
        {
            //updates the status of the buttons when the event happens. 
            if (!(textPhoneNo.TextLength > 0))
            {
                textPhoneNo.BackColor = Color.Red;
            }
            else
            {
                textPhoneNo.BackColor = Color.White;
            }

            updateButtons();

        }

        private void clearAll()
        {
            //Clears all the fields.
            textFirstName.Clear();
            textMiddleName.Clear();
            textLastName.Clear();
            textAddr1.Clear();
            textAddr2.Clear();
            textCity.Clear();
            comboState.SelectedIndex = -1;
            maskedZipCode.Clear();
            comboGender.SelectedIndex = -1;
            textPhoneNo.Clear();
            textEmail.Clear();
            comboPofa.SelectedIndex = -1;
            dateRecieved.Value = DateTime.Today;
            //resetting values.
            timeToSave = "none";
            timeToFirstEntry = "none";
            noOfBackspaces = 0;
        }

        
        

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //When item has been clicked or changed from the listview, store the value of index in index variable.
            try{
                ListViewItem item = ((ListView)sender).SelectedItems[0];

                index=listView1.Items.IndexOf(item);
                loadFormData(index);
            }
            catch(Exception)
            {
                Console.WriteLine("Changing Index");   
            }
        }

        private void loadFormData(int index)
        {
            // Loads the form data once, item has been selected from the listView.
            List<String> dataList = IO.getListFromFileData(index); //getting the list at a specific index from formData.
            enableButton("modify");
            enableButton("delete");
            //Key is stored at index "0".
            if (dataList.Count() == 16)
            {
                if (dataList[2].Length == 1 && Char.IsUpper(dataList[2][0]) && dataList[5].Length <= 25)
                {
                    //Middle Name present and Address line 2 absent.
                    textFirstName.Text = dataList[1];
                    textMiddleName.Text = dataList[2];
                    textLastName.Text = dataList[3];
                    textAddr1.Text = dataList[4];
                    textAddr2.Clear();
                    textCity.Text = dataList[5];
                    comboState.Text = dataList[6];
                    maskedZipCode.Text = dataList[7];
                    comboGender.Text = dataList[8];
                    textPhoneNo.Text = dataList[9];
                    textEmail.Text = dataList[10];
                    comboPofa.Text = dataList[11];
                    dateRecieved.Value = Convert.ToDateTime(dataList[12]);
                    

                }
                else
                {
                    //Middle name not present, Address line to present.
                    textFirstName.Text = dataList[1];
                    textMiddleName.Clear();
                    textLastName.Text = dataList[2];
                    textAddr1.Text = dataList[3];
                    textAddr2.Text = dataList[4];
                    textCity.Text = dataList[5];
                    comboState.Text = dataList[6];
                    maskedZipCode.Text = dataList[7];
                    comboGender.Text = dataList[8];
                    textPhoneNo.Text = dataList[9];
                    textEmail.Text = dataList[10];
                    comboPofa.Text = dataList[11];
                    dateRecieved.Value = Convert.ToDateTime(dataList[12]);



                }
            }
            else if (dataList.Count() == 17)
            {
                //Both Middle name and Address line 2 are present.
                textFirstName.Text = dataList[1];
                textMiddleName.Text = dataList[2];
                textLastName.Text = dataList[3];
                textAddr1.Text = dataList[4];
                textAddr2.Text = dataList[5];
                textCity.Text = dataList[6];
                comboState.Text = dataList[7];
                maskedZipCode.Text = dataList[8];
                comboGender.Text = dataList[9];
                textPhoneNo.Text = dataList[10];
                textEmail.Text = dataList[11];
                comboPofa.Text = dataList[12];
                dateRecieved.Value = Convert.ToDateTime(dataList[13]);



            }
            else if (dataList.Count() == 15)
            {
                // if both middle name and addressline are absent.
                textFirstName.Text = dataList[1];
                textMiddleName.Clear();
                textLastName.Text = dataList[2];
                textAddr1.Text = dataList[3];
                textAddr2.Clear();
                textCity.Text = dataList[4];
                comboState.Text = dataList[5];
                maskedZipCode.Text = dataList[6];
                comboGender.Text = dataList[7];
                textPhoneNo.Text = dataList[8];
                textEmail.Text = dataList[9];
                comboPofa.Text = dataList[10];
                dateRecieved.Value = Convert.ToDateTime(dataList[11]);

            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Console.WriteLine("Form Resized!");
        
        }

        private void TextMiddleName_TextChanged(object sender, EventArgs e)
        {
           
            updateButtons();
        }

        private void TextAddr2_TextChanged(object sender, EventArgs e)
        {
            
            updateButtons();
        }

        private void ComboState_TextChanged(object sender, EventArgs e)
        {
            if (!(comboState.SelectedIndex > -1))
            {
                comboState.BackColor = Color.Red;
            }
            else
            {
                comboState.BackColor = Color.White;
            }
            updateButtons();

        }

        private void ComboGender_TextChanged(object sender, EventArgs e)
        {
            if (!(comboGender.SelectedIndex > -1))
            {
                comboGender.BackColor = Color.Red;
            }
            else
            {
                comboGender.BackColor = Color.White;
            }
            updateButtons();

        }

        private void ComboPofa_TextChanged(object sender, EventArgs e)
        {
            if (!(comboPofa.SelectedIndex > -1))
            {
                comboPofa.BackColor = Color.Red;
            }
            else
            {
                comboPofa.BackColor = Color.White;
            }
            updateButtons();
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            //When item has been clicked or changed from the listview, store the value of index in index variable.
            try
            {
                ListViewItem item = ((ListView)sender).SelectedItems[0];

                index = listView1.Items.IndexOf(item);
                loadFormData(index);
            }
            catch (Exception)
            {
                Console.WriteLine("Changing Index");
            }
        }
    }

    
}

