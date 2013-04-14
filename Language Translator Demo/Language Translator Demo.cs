using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Language_Translator_Demo
{
    public partial class Form1 : Form
    {
        // Create a new dictionary to store the Spanish words and their translations
        Dictionary<string, string> words = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add the Spanish words and their translations
            words.Add("Tengo", "I have"); 
            words.Add("tengo", "I have");
            words.Add("una", "a"); 
            words.Add("uno", "a");
            words.Add("bicicleta", "bicycle"); 
            words.Add("Bicicleta", "bicycle");
            words.Add("bicicleta nueva", "new bicycle");
            words.Add("Bicicleta nueva", "new bicycle");
            words.Add("Una bicicleta nueva", "A new bicycle");
            words.Add("una bicicleta nueva", "a new bicycle");
            words.Add("nueva", "new"); 
            words.Add("Nueva", "new");
            words.Add("Tengo una", "I have a");
            words.Add("tengo una", "I have a");
            words.Add("Tengo una bicicleta", "I have a bicycle");
            words.Add("tengo una bicicleta", "I have a bicycle");
            words.Add("Tengo una bicicleta nueva", "I have a new bicycle");
            words.Add("tengo una bicicleta nueva", "I have a new bicycle");

            words.Add("Me", "me"); 
            words.Add("me", "me");
            words.Add("puede", "can"); 
            words.Add("comer", "eat");
            words.Add("ahora", "now");
            words.Add("¿Me puede comer ahora?", "Can I eat now?");
            words.Add("¿me puede comer ahora?", "Can I eat now?");

            words.Add("Vamos a ir", "Let's go");
            words.Add("vamos a ir", "Let's go");
            words.Add("vamos", "Let's go");
            words.Add("Vamos", "Let's go");
            words.Add("al", "to the"); 
            words.Add("al cine", "the movies");
            words.Add("mañana", "tomorrow");
            words.Add("Vamos a ir al cine mañana", "Let's go to the movies tomorrow");
            words.Add("vamos a ir al cine mañana", "Let's go to the movies tomorrow");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit the application here
            Application.Exit();
        }

        private void clearSpanish_Click(object sender, EventArgs e)
        {
            // Clear the Spanish textbox
            spanishTB.Text = "";
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear both the Spanish textbox and the translation label
            spanishTB.Text = "";
            translation.Text = "";
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            // Check to see if the Spanish word/sentence is in our dictionary
            // and output the translation
            string value = "";

            // Error-checking
            if (spanishTB.Text == "")
            {
                MessageBox.Show("Nothing to translate!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (words.TryGetValue(spanishTB.Text, out value))
            {
                translation.Font = new System.Drawing.Font("Arial", 18.0f);
                translation.ForeColor = Color.White;
                translation.BackColor = Color.Transparent;
                translation.TextAlign = ContentAlignment.MiddleCenter;
                translation.Text = value;
            }
            else
            {
                translation.Text = "";

                MessageBox.Show("No translation found!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                spanishTB.SelectionStart = 0;
                spanishTB.SelectionLength = spanishTB.Text.Length;
            }
        }

        private void spanishTB_KeyDown(object sender, KeyEventArgs e)
        {
            // Allows the user to hit enter to translate instead of 
            // having to always click the button
            if (e.KeyCode == Keys.Enter)
                translateButton.PerformClick();
        }
    }
}
