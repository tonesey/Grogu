using GroguCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroguControls
{
    public partial class FormControl : UserControl
    {
        public bool IsOpen { get; private set; } = false;

        public FormControl()
        {
            InitializeComponent();
        }

        private void piA1_Click(object sender, EventArgs e)
        {
            PasteImage(piA1);
        }

        private void piA2_Click(object sender, EventArgs e)
        {
            PasteImage(piA2);
        }

        private void piA3_Click(object sender, EventArgs e)
        {
            PasteImage(piA3);
        }

        private void piA4_Click(object sender, EventArgs e)
        {
            PasteImage(piA4);
        }

        private void piA5_Click(object sender, EventArgs e)
        {
            PasteImage(piA5);
        }

        private void piQ_Click(object sender, EventArgs e)
        {
            PasteImage(piQ);
        }

        private void PasteImage(PictureBox target)
        {
            Image cImage = Clipboard.GetImage();

            if (cImage != null)
            {
                target.Image = (Image)cImage;
            }
        }


        //Bitmap default_image = new Bitmap(pictureBox5.Image);


        public QuizForm GetForm()
        {
            QuizForm q = new QuizForm();
            q.Question = new Question();


            if (piQ.Image == null)
            {
                MessageBox.Show("Immagine domanda mancante");
                return null;
            }

            q.Question.Content = new Bitmap(piQ.Image);
            q.IsOpen = chOpen.Checked;

            for (int i = 1; i <= 5; i++)
            {
                PictureBox pi = GetControl($"piA{i}") as PictureBox;
                TextBox txt = GetControl($"txtA{i}Value") as TextBox;
                Answer answ = new Answer();
                bool answerValid = false;
                if (!q.IsOpen)
                {
                    //risposta chiusa - immagine
                    var bmp = new Bitmap(pi.Image);
                    if (bmp != null)
                    {

                        answ.Value = Convert.ToDouble(txt.Text);
                        answerValid = true;
                    }
                }

                if (answerValid)
                {
                    q.Answers.Add(answ);
                }
            }
            return q;
        }

        private void chOpen_CheckedChanged(object sender, EventArgs e)
        {
            IsOpen = chOpen.Checked;
            if (chOpen.Checked)
            {
                //risposte aperte
                tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            }
            else
            {
                //scelta multipla
                tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            }
            UpdateUI(chOpen.Checked);
        }

        private void UpdateUI(bool isOpen)
        {
            this.SuspendLayout();
            for (int i = 1; i <= 5; i++)
            {
                PictureBox pi = GetControl($"piA{i}") as PictureBox;
                pi.SizeMode = PictureBoxSizeMode.Normal;
                TextBox txt = GetControl($"txtA{i}Value") as TextBox;
                pi.Visible = !isOpen;
                txt.Visible = !isOpen;
            }
            this.ResumeLayout();
        }

        public IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl)).Concat(controls);
        }

        private Control GetControl(string name)
        {

            var ctrls = GetAll(this);
            return ctrls.FirstOrDefault(c => c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

        }


    }
}
