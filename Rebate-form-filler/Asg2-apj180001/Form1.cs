using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace Asg2_apj180001
{

    public partial class Form1 : Form
    {
        int index;
        string timeToSave = "none";
        string timeToFirstEntry = "none";
        int noOfBackspaces = 0;

        public Form1()
        {
            InitializeComponent();
            initComboState();

            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);
            loadDataInListView();
            dateRecieved.MaxDate = DateTime.Today;
            stripLabel.Text = "Add";

        }

        private void initComboState()
        {
           foreach (string eachStateCode in IO.listOfStateCodes())
            {
                comboState.Items.Add(eachStateCode);
            }
        }

        private void loadDataInListView()
        {
            IO.readDataFromFile();
            ListViewItem li;
            listView1.Items.Clear();
            foreach (List<string> listOfStrings in IO.getFileData())
            {
                string fullName = listOfStrings[1];
                if (listOfStrings.Count == 16)
                {
                    if (listOfStrings[2].Length == 1 && Char.IsUpper(listOfStrings[2][0]) && listOfStrings[5].Length <= 25)
                    {
                        //Middle Name present
                        fullName += " " + listOfStrings[2] + " " + listOfStrings[3];
                        li = listView1.Items.Add(fullName);
                        li.SubItems.Add(listOfStrings[9]);
                    }
                    else
                    {
                        fullName += " " + listOfStrings[2];
                        li = listView1.Items.Add(fullName);
                        li.SubItems.Add(listOfStrings[9]);
                    }
                }
                else if (listOfStrings.Count == 17)
                {
                    //add to list 0 n 2
                    fullName += " " + listOfStrings[2] + " " + listOfStrings[3];
                    li = listView1.Items.Add(fullName);
                    li.SubItems.Add(listOfStrings[10]);

                }
                else if (listOfStrings.Count == 18)
                {
                    fullName += " " + listOfStrings[2];
                    li = listView1.Items.Add(fullName);
                    li.SubItems.Add(listOfStrings[8]);
                }
            }
        }
        


        private void LabelPhoneNo_Click(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void LabelPofa_Click(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void ComboPofa_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }

        
        private void TextEmail_TextChanged(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void ComboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void ComboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void TextLastName_TextChanged(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void MaskedZipCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            updateButtons();

        }
        


        private void Form1_Load(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void TextFirstName_TextChanged(object sender, EventArgs e)
        {
            if(timeToFirstEntry=="none")
            {
                timeToFirstEntry= DateTime.Now.ToString("h:mm:ss tt");
            }
            updateButtons();

        }

        private void enableButton(String buttonName)
        {
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
        {
            if (textFirstName.TextLength > 0 && textLastName.TextLength > 0 &&
               textAddr1.TextLength > 0 && textCity.TextLength > 0 &&
               comboState.SelectedIndex > -1 && maskedZipCode.MaskCompleted &&
               comboGender.SelectedIndex > -1 && textPhoneNo.TextLength > 0 &&
               IO.IsEmailValid(textEmail.Text) && comboPofa.SelectedIndex > -1)
            {
                string key = textFirstName.Text + textLastName.Text + textPhoneNo.Text;
                if (buttonSave.Text == "Save")
                {
                    if(IO.isKeyPresent(key) == true )
                    {
                        stripValue.Text = "Record already present";
                        disableButton("save");
                    }
                    else
                    {
                        enableButton("save");
                        stripValue.Text = "Click on save button to save";
                       
                    }


                }
                else if (buttonSave.Text == "Modify")
                {
                    String previousKey=IO.getFileData()[index].ElementAt(0);
                    if(key == previousKey)
                    {
                        stripValue.Text = "Make some changes and then Click on Modify button to modify";
                        
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
                        }
                    }
                }
               

                
            }
            else
            {
                disableButton("save");
                if(buttonSave.Text=="Save")
                {
                    stripValue.Text = "Not enough data to save";
                }
                else if(buttonSave.Text=="Modify")
                {
                    stripValue.Text = "Not enough data to modify";
                }

            }

            if (textFirstName.TextLength > 0 || textLastName.TextLength > 0 ||
               textAddr1.TextLength > 0 || textCity.TextLength > 0 ||
               comboState.SelectedIndex > -1 || maskedZipCode.MaskCompleted ||
               comboGender.SelectedIndex > -1 || textPhoneNo.TextLength > 0 ||
               IO.IsEmailValid(textEmail.Text) || comboPofa.SelectedIndex > -1)
            {

                enableButton("clear");
            }
        }
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 8)
            {
                noOfBackspaces+=1;
                Console.WriteLine(noOfBackspaces);
            }

            if (textFirstName.TextLength > 0 && textLastName.TextLength > 0 &&
                textAddr1.TextLength > 0 && textCity.TextLength > 0 &&
                comboState.SelectedIndex>-1 && maskedZipCode.MaskCompleted &&
                comboGender.SelectedIndex>-1 && textPhoneNo.TextLength >0 &&
                IO.IsEmailValid(textEmail.Text) && comboPofa.SelectedIndex >-1 )
            {

                enableButton("save");
                enableButton("clear");
            }
            else
            {
                disableButton("save");
            }
        }

        

        private void TextCity_TextChanged(object sender, EventArgs e)
        {
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
            string message = "Are you sure you want to delete this record?";
            string caption = "Delete";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                IO.removeFromFileData(index);
                disableButton("delete");
                writeFileContentstoFile();
                stripValue.Text = "Not enough data to save";
            }
            else
            {
                   
            }

        }

        

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (buttonSave.Text == "Save")
            {
                if(timeToSave=="none")
                {
                    timeToSave = DateTime.Now.ToString("h:mm:ss tt");
                }
                addCurrentDataToFileContents();
               
            }
            else if (buttonSave.Text == "Modify")
            {
                modifyCurrentDataToFileContents();
                disableButton("modify");
            }
            writeFileContentstoFile();
            
        }

        void writeFileContentstoFile()
        {
            IO.writeDataToFile();
            clearAll();
            loadDataInListView();
        }

        private void addCurrentDataToFileContents()
        {
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
                timeToSave = "none";
                timeToFirstEntry = "none";
                noOfBackspaces = 0;
                IO.addListToFileData(currentList);

            }

        }

       

        private void modifyCurrentDataToFileContents()
        {
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
                timeToSave = "none";
                timeToFirstEntry = "none";
                noOfBackspaces = 0;
            

            }
        }

        private void MaskedZipCode_TextChanged(object sender, EventArgs e)
        {
            updateButtons();
            
        }

        private void TextAddr1_TextChanged(object sender, EventArgs e)
        {
            updateButtons();
        }

        private void TextPhoneNo_TextChanged(object sender, EventArgs e)
        {
            updateButtons();

        }

        private void clearAll()
        {
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
            timeToSave = "none";
            timeToFirstEntry = "none";
            noOfBackspaces = 0;
        }

        
        

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
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
            List<String> dataList = IO.getListFromFileData(index);
            enableButton("modify");
            enableButton("delete");
            
            if (dataList.Count() == 16)
            {
                if (dataList[2].Length == 1 && Char.IsUpper(dataList[2][0]) && dataList[5].Length <= 25)
                {
                    //Middle Name present
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
            int iHeight = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Height += iHeight;
            panel1.Height += iHeight;
            listView1.Height += iHeight;
            int iWidth = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            listView1.Width += iWidth;
            panel1.Width += iWidth;
            this.Width += iWidth;
            this.CenterToScreen();

        }
    }

    
}

