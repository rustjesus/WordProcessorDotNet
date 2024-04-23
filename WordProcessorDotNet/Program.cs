using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace WordProcessor
{
    public class MyForm : Form
    {
        static List<string> dictionary = new List<string>();

        private void InitializeComponent()
        {

        }

        [STAThread]
        public static void Main(string[] args)
        {

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));

        }
        private Button myButton;
        private Random random;
        private TextBox inputBox;
        private TextBox inputBoxIndentLineCount;
        private Label outputLabel;
        private static RichTextBox fileTextOutput;
        private Label fileLabel;
        private Label indentCountLabel;


        private TextBox addLineInputBox;
        private Label addLineLabel_1;


        private TextBox replacebox1;
        private Label replacelabel1;

        private TextBox replacebox2;
        private Label replacelabel2;
        public MyForm()
        {
            this.Text = "Text File Modder";
            this.ClientSize = new Size(800, 600);
            //button 1
            myButton = new Button();
            myButton.Text = "Read File";
            myButton.Size = new Size(100, 50);
            myButton.Location = new Point(5, 5); // set the button's position
            myButton.Click += new EventHandler(ReadString);

            this.Controls.Add(myButton);

            //button 2
            myButton = new Button();
            myButton.Text = "Remove All Indentations";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(110, 5); // set the button's position
            myButton.Click += new EventHandler(RemoveAllIndents);

            this.Controls.Add(myButton);

            //button 3
            myButton = new Button();
            myButton.Text = "Add Indents Every X Lines";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(250, 5); // set the button's position
            myButton.Click += new EventHandler(AddIndentations);

            this.Controls.Add(myButton);

            //button 4
            myButton = new Button();
            myButton.Text = "Add To End Of Each Line";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(400, 5); // set the button's position
            myButton.Click += new EventHandler(AddEveryLine);

            this.Controls.Add(myButton);

            //button 5
            myButton = new Button();
            myButton.Text = "Remove Last Line";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(400, 150); // set the button's position
            myButton.Click += new EventHandler(RemoveLastLineFromFile);

            this.Controls.Add(myButton);


            //button 7
            myButton = new Button();
            myButton.Text = "Remove All Duplicate Words";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(550, 150); // set the button's position
            myButton.Click += new EventHandler(RemoveDuplicates);

            this.Controls.Add(myButton);

            //button 8
            myButton = new Button();
            myButton.Text = "Remove All Duplicate Words";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(550, 150); // set the button's position
            myButton.Click += new EventHandler(RemoveDuplicates);

            this.Controls.Add(myButton);

            //button 9
            myButton = new Button();
            myButton.Text = "Check Spelling";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(550, 300); // set the button's position
            myButton.Click += new EventHandler(RunSpellCheck);

            this.Controls.Add(myButton);

            //button 9
            myButton = new Button();
            myButton.Text = "Save text box to file";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(400, 300); // set the button's position
            myButton.Click += new EventHandler(SaveTextBoxToFile);

            this.Controls.Add(myButton);

            //button 10
            myButton = new Button();
            myButton.Text = "change text color";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(400, 500); // set the button's position
            myButton.Click += new EventHandler(ChangeTextColor);

            this.Controls.Add(myButton);
            /*
            //timer
            this.timer = new Timer();
            this.timer.Interval = 1000; // 1 seconds
            this.timer.Tick += new EventHandler(Timer_Tick);

            //random mover
            this.random = new Random();
            this.StartPosition = FormStartPosition.Manual;

            this.timer.Start();
            */

            // make the window resizable
            //this.FormBorderStyle = FormBorderStyle.Sizable;


            //TEXT VIEWING WINDOW
            fileTextOutput = new RichTextBox();
            fileTextOutput.Location = new Point(5, 150);
            fileTextOutput.Size = new Size(200, 400);
            fileTextOutput.BorderStyle = BorderStyle.FixedSingle; // add a border
            fileTextOutput.WordWrap = false; // don't wrap text to the next line
            fileTextOutput.ScrollBars = RichTextBoxScrollBars.Horizontal; // add a horizontal scrollbar
            this.Controls.Add(fileTextOutput);
            fileTextOutput.AutoScrollOffset = new Point(-1000, 0); // scroll the text to the left when it exceeds the width of the control

            //GET FILE NAME
            // Add label
            fileLabel = new Label();
            fileLabel.Text = "File name here:";
            fileLabel.Location = new Point(10, 55);
            fileLabel.Size = new Size(200, 20);
            fileLabel.BorderStyle = BorderStyle.FixedSingle; // add a border
            this.Controls.Add(fileLabel);

            // Create and configure input TextBox 
            inputBox = new TextBox();
            inputBox.Location = new Point(5, 80);
            inputBox.Size = new Size(200, 20);
            inputBox.BorderStyle = BorderStyle.FixedSingle; // add a border
            inputBox.TextChanged += new EventHandler(InputBox_TextChanged);
            this.Controls.Add(inputBox);

            // Create and configure output Label
            outputLabel = new Label();
            outputLabel.Location = new Point(5, 110);
            outputLabel.Size = new Size(200, 20);
            outputLabel.BorderStyle = BorderStyle.FixedSingle; // add a border
            this.Controls.Add(outputLabel);

            //SET INDENT EACH X LINES
            // Add label
            indentCountLabel = new Label();
            indentCountLabel.Text = "Set Line Indent Count (X):";
            indentCountLabel.Location = new Point(245, 55);
            indentCountLabel.Size = new Size(150, 20);
            indentCountLabel.BorderStyle = BorderStyle.FixedSingle; // add a border
            this.Controls.Add(indentCountLabel);

            // Create and configure input TextBox
            inputBoxIndentLineCount = new TextBox();
            inputBoxIndentLineCount.Location = new Point(240, 80);
            inputBoxIndentLineCount.Size = new Size(150, 20);
            inputBoxIndentLineCount.BorderStyle = BorderStyle.FixedSingle; // add a border
            inputBoxIndentLineCount.TextChanged += new EventHandler(SetIndentationLineCount);
            this.Controls.Add(inputBoxIndentLineCount);


            //CHANGE END OF EACH LINE
            // Add label
            addLineLabel_1 = new Label();
            addLineLabel_1.Text = "Add to each line:";
            addLineLabel_1.Location = new Point(400, 55);
            addLineLabel_1.Size = new Size(200, 20);
            addLineLabel_1.BorderStyle = BorderStyle.FixedSingle; // add a border
            this.Controls.Add(addLineLabel_1);

            // Create and configure input TextBox 
            addLineInputBox = new TextBox();
            addLineInputBox.Location = new Point(405, 80);
            addLineInputBox.Size = new Size(200, 20);
            addLineInputBox.BorderStyle = BorderStyle.FixedSingle; // add a border
            addLineInputBox.TextChanged += new EventHandler(SetStringForEachLine);
            this.Controls.Add(addLineInputBox);


            //CHANGE END OF EACH LINE
            //button 6
            myButton = new Button();
            myButton.Text = "Replace text";
            myButton.Size = new Size(120, 50);
            myButton.Location = new Point(250, 150); // set the button's position
            myButton.Click += new EventHandler(WriteStringReplace);

            this.Controls.Add(myButton);
            // Add label
            replacelabel1 = new Label();
            replacelabel1.Text = "Text to replace:";
            replacelabel1.Location = new Point(250, 205);
            replacelabel1.Size = new Size(120, 20);
            replacelabel1.BorderStyle = BorderStyle.FixedSingle; // add a border
            this.Controls.Add(replacelabel1);

            // Create and configure input TextBox 
            replacebox1 = new TextBox();
            replacebox1.Location = new Point(250, 230);
            replacebox1.Size = new Size(120, 20);
            replacebox1.BorderStyle = BorderStyle.FixedSingle; // add a border
            replacebox1.TextChanged += new EventHandler(SetStringToFind);
            this.Controls.Add(replacebox1);
            // Add label
            replacelabel2 = new Label();
            replacelabel2.Text = "Replacement text:";
            replacelabel2.Location = new Point(250, 260);
            replacelabel2.Size = new Size(120, 20);
            replacelabel2.BorderStyle = BorderStyle.FixedSingle; // add a border
            this.Controls.Add(replacelabel2);

            // Create and configure input TextBox 
            replacebox2 = new TextBox();
            replacebox2.Location = new Point(250, 285);
            replacebox2.Size = new Size(120, 20);
            replacebox2.BorderStyle = BorderStyle.FixedSingle; // add a border
            replacebox2.TextChanged += new EventHandler(SetStringToReplace);
            this.Controls.Add(replacebox2);

        }
        //this.outputLabel.Text is the file to use path
        private void ChangeTextColor(object sender, EventArgs e)
        {
            string text = ":D";
            int Index = fileTextOutput.Text.IndexOf(":D");
            int length = text.Length;
            fileTextOutput.Select(Index, length);
            fileTextOutput.SelectionColor = Color.Red;
        }
        private void ChangeStringColor(string text, Color color)
        {
            int Index = fileTextOutput.Text.IndexOf(text);
            int length = text.Length;
            fileTextOutput.Select(Index, length);
            fileTextOutput.SelectionColor = color;
        }
        public void RunSpellCheck(object sender, EventArgs e)
        {
            //get dictionary
            string fileName = "SpellCheckDictionary.txt";
            string directoryPath = Directory.GetCurrentDirectory();
            // Combine the directory path and file name
            string filePath = Path.Combine(directoryPath, fileName);

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (string line in lines)
            {
                dictionary.Add(line.ToLower());
            }
            // Run spell check on startup
            string output = SpellCheckBetter(fileTextOutput.Text);

            // Get a reference 
            fileTextOutput.Text = output;
        }
        string SpellCheckBetter(string input)
        {

            // Split input into lines
            string[] lines = input.Split('\n');

            // Check each line for spelling and grammar errors
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // Split line into words and punctuation marks
                string[] words = line.Split(new char[] { '"', '-', ' ', ',', '!', '?', '<', '>' }, StringSplitOptions.RemoveEmptyEntries);

                // Check each word for spelling and grammar errors
                StringBuilder checkedLine = new StringBuilder();
                for (int j = 0; j < words.Length; j++)
                {
                    string word = words[j];
                    bool isLastChar = false;

                    // Check if the word is the last character of the line and exclude the last character if it's a punctuation mark
                    if (j == words.Length - 1 && line[line.Length - 1] != ' ' && !Char.IsLetterOrDigit(line[line.Length - 1]))
                    {
                        word = word.Substring(0, word.Length - 1);
                        isLastChar = true;
                    }

                    // Check for spelling errors
                    if (!dictionary.Contains(word.ToLower()))
                    {
                        // Set the color of the misspelled word to red (WONT WORK?!)
                        fileTextOutput.SelectionStart = line.IndexOf(word);
                        fileTextOutput.SelectionLength = word.Length;
                        fileTextOutput.SelectionColor = Color.Red;

                        checkedLine.Append("*" + word);
                        if (!isLastChar) checkedLine.Append(" ");


                        continue;
                    }

                    // Check for common grammar errors
                    if (j > 0 && (word == "an"))
                    {
                        string previousWord = words[j - 1];
                        if (previousWord.EndsWith("ing") || previousWord.EndsWith("ed"))
                        {
                            // Suggest using "a" instead of "an" before verbs in the past or present participle form
                            checkedLine.Append("an *suggested: a*");
                            if (!isLastChar) checkedLine.Append(" ");
                            continue;
                        }
                    }

                    checkedLine.Append(word);
                    if (!isLastChar) checkedLine.Append(" ");
                }

                // Append checked line to output with original formatting intact
                output.Append(checkedLine.ToString().TrimEnd());
                if (i < lines.Length - 1)
                {
                    output.Append('\n'); // Add back the newline character that was removed by Split
                }
            }

            return output.ToString();
        }
        private void SaveTextBoxToFile(object sender, EventArgs e)
        {
            string outputText = fileTextOutput.Text; // Get the text to write
            File.WriteAllText(outputLabel.Text, outputText); // Write the text to the file

            MessageBox.Show("File saved!");
        }
        private string writeStringText;
        private string replaceStringText;
        public void SetStringToFind(object sender, EventArgs e)
        {
            writeStringText = replacebox1.Text;
        }
        public void SetStringToReplace(object sender, EventArgs e)
        {
            replaceStringText = replacebox2.Text;
        }
        public void WriteStringReplace(object sender, EventArgs e)
        {

            string searchText = writeStringText; // Set the text to search for
            string replaceText = replaceStringText; // Set the text to replace with
            string text = fileTextOutput.Text; // Get the text of the control
            text = text.Replace(searchText, replaceText); // Replace the text
            fileTextOutput.Text = text; // Set the text of the control to the modified text


            //ReadString(sender, e);


        }
        private string inputChange;
        private int lineCount;
        public void SetIndentationLineCount(object sender, EventArgs e)
        {
            // Set the value of X to the number of lines
            // after which you want to add indentation
            inputChange = inputBoxIndentLineCount.Text;
            int.TryParse(inputChange, out lineCount);
            //Debug.Log(lineCount);
        }
        public void AddIndentations(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(outputLabel.Text);

            // Write the output file with added indentation
            using (StreamWriter writer = new StreamWriter(outputLabel.Text))
            {
                int count = 0;
                foreach (string line in lines)
                {
                    // Write the current line
                    writer.WriteLine(line);

                    // Check if X number of lines have been written
                    count++;
                    if (count == lineCount)
                    {
                        // Add a blank line (indentation)
                        writer.WriteLine();

                        // Reset the count
                        count = 0;
                    }
                }
            }

            ReadString(sender, e);
        }
        public void RemoveLastLineFromFile(object sender, EventArgs e)
        {
            // Read all the lines from the file
            string[] lines = File.ReadAllLines(outputLabel.Text);

            // Remove the last line
            Array.Resize(ref lines, lines.Length - 1);

            // Overwrite the file with the modified lines
            File.WriteAllLines(outputLabel.Text, lines);


            ReadString(sender, e);
        }
        private void RemoveDuplicates(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();
            HashSet<string> uniqueWords = new HashSet<string>();

            using (StreamReader reader = new StreamReader(outputLabel.Text))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < words.Length; i++)
                    {
                        string word = words[i].ToLower();

                        if (!uniqueWords.Contains(word))
                        {
                            uniqueWords.Add(word);
                        }
                        else
                        {
                            words[i] = "";
                        }
                    }

                    line = string.Join(" ", words);
                    lines.Add(line);
                }
            }

            using (StreamWriter writer = new StreamWriter(outputLabel.Text))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
            ReadString(sender, e);
        }
        private static string finalReadString;
        private void ReadString(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(outputLabel.Text);
            finalReadString = reader.ReadToEnd();
            fileTextOutput.Text = finalReadString;
            reader.Close();
        }
        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            outputLabel.Text = inputBox.Text;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            int x = random.Next(Screen.PrimaryScreen.Bounds.Width - this.Width);
            int y = random.Next(Screen.PrimaryScreen.Bounds.Height - this.Height);

            this.Location = new Point(x, y);
        }

        private void RemoveAllIndents(object sender, EventArgs e)
        {
            string filePath = outputLabel.Text;
            string[] lines = File.ReadAllLines(filePath);

            // Remove blank lines and indentation from each line
            for (int i = 0; i < lines.Length; i++)
            {
                string trimmedLine = lines[i].TrimStart();
                if (!string.IsNullOrEmpty(trimmedLine))
                {
                    lines[i] = trimmedLine;
                }
                else
                {
                    lines[i] = null; // Mark blank lines for removal
                }
            }

            // Write modified lines back to the same file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    if (line != null)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            ReadString(sender, e);
        }


        private string stringForEachLine;
        public void SetStringForEachLine(object sender, EventArgs e)
        {
            stringForEachLine = addLineInputBox.Text;

            ReadString(sender, e);
        }
        public void AddEveryLine(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(outputLabel.Text);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] += stringForEachLine;
            }

            File.WriteAllLines(outputLabel.Text, lines);

            ReadString(sender, e);
        }
        public void RemoveLastCharacterFromEveryLine(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(outputLabel.Text);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > 0) // Make sure line is not empty
                {
                    lines[i] = lines[i].Substring(0, lines[i].Length - 1); // Remove last character
                }
            }

            File.WriteAllLines(outputLabel.Text, lines);

            ReadString(sender, e);
        }

    }
}