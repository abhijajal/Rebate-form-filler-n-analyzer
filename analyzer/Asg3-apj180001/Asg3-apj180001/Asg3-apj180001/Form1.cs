/*
 * This class interacts with the UI and also does function calls to FileIO class.
 * By: APJ180001
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Asg3_apj180001
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
                       
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {  // When open button is clicked 
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {  // Opening a dialog box, which only allows to open .txt files.
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {  // Once, the file has been opened..
                textFilePath.Text = openFileDialog.FileName;
                FileIO.setFilePath(openFileDialog.FileName);
                // loading the file at the path specified, displaying the results and saving it to a file.
                FileIO.loadFile();
                displayResults();
                FileIO.writeToFile();
            }
        }

        private void displayResults()
        {   //displaying the results 
            string result=FileIO.getResults();
            textDisplay.Text = result;  
        }
       
    }
}
