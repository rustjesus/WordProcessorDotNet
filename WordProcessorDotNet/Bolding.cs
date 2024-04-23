using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordProcessorDotNet
{
    internal class Bolding
    {
        //TEXT BOLDING**********************
        public void MakeTextBold(RichTextBox textBox)
        {
            if (textBox.SelectionFont != null)
            {
                textBox.SelectionFont = new Font(textBox.SelectionFont.FontFamily, textBox.Font.Size, FontStyle.Bold);
            }

        }
        public void MakeTextNotBold(RichTextBox textBox)
        {
            if (textBox.SelectionFont != null)
            {
                Font currentFont = textBox.SelectionFont;
                FontStyle newStyle = currentFont.Style & ~FontStyle.Bold;
                textBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }
        public void SaveBoldModeValue(int value)
        {
            var data = new { Value = value };

            string jsonFilePath = Path.Combine(Application.StartupPath, "boldModeValue.json");
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(jsonFilePath, json);
        }

        public int LoadBoldModeValue()
        {
            Settings settings = new Settings();
            string jsonFilePath = Path.Combine(Application.StartupPath, "boldModeValue.json");
            if (File.Exists(jsonFilePath))
            {
                var json = File.ReadAllText(jsonFilePath);
                dynamic data = JsonConvert.DeserializeObject(json);

                if (data != null)
                {
                    int value = Convert.ToInt32(data.Value);
                    settings.boldMode = value;
                    return value;
                }
            }

            return 0;
        }
    }
}
