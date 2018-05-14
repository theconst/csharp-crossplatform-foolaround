using CustomElementsControlLibrary;
using PermutationsDLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RandomButtonApplication
{
    public partial class PermutationForm : Form
    {
        private List<TextBox> textBoxes;

        private IEnumerator<List<string>> permutations;
   
        public PermutationForm()
        {
            InitializeComponent();
            textBoxes = new List<TextBox>()
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7
            };
            textBoxes.ForEach(tb => tb.Leave += RefreshPermutations);
            nextButton.OnColorsChanged += ShowConfirmation;
        }

        private void ShowConfirmation(object sender, EventArgs e)
        {
            //Приклад використання події
            MessageBox.Show("Успішно змінено кольри кнопки.");
        }

        private void RefreshPermutations(object sender, EventArgs e)
        {
            permutations = textBoxes.Select(tb => tb.Text)
               .ToList()
               .GetPermutations()
               .Forever()
               .GetEnumerator();
        }

        private void HandleNextPermutation(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (permutations.MoveNext())
                {
                    foreach (var p in textBoxes.Zip(permutations.Current, (textBox, text) => new {
                        TextBox = textBox,
                        Text = text
                    }))
                    {
                        p.TextBox.Text = p.Text;
                    };
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                var newColors = new List<Color>();
                while (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    newColors.Add(colorDialog.Color);
                }
                nextButton.Colors = newColors;
            }
        }
    }
}
