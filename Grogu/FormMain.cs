using GroguCommon;
using GroguControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grogu
{
    public partial class FormMain : Form
    {

        string _curFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        public FormMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btCreateLayout_Click(object sender, EventArgs e)
        {
            int formsNr = 0;
            if (!int.TryParse(txtForms.Text, out formsNr))
            {
                MessageBox.Show($"Inserire il nr  di schede da generare");
                return;
            }

            //var questions = Convert.ToInt32(txtQuestions.Text);
            this.SuspendLayout();
            for (int i = 0; i < formsNr; i++)
            {
                TabPage tabPage = new TabPage($"Scheda {i + 1}");
                var fc = new GroguControls.FormControl()
                {
                    Id = (i + 1).ToString(),
                    Dock = DockStyle.Fill
                };
                tabPage.Controls.Add(fc);
                tabControl.TabPages.Add(tabPage);
            }
            this.ResumeLayout();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var forms = Convert.ToInt32(txtForms.Text);
            Quiz q = new Quiz
            {
                RandomForms = checkRandomForms.Checked,
                RandomQuestions = checkRandomQuestions.Checked,
                AllowBack = checkAllowBack.Checked,
                StartDateTime = dtStart.Value
            };

            int timeLimit = 0;
            if (!int.TryParse(txtTime.Text, out timeLimit))
            {
                MessageBox.Show($"Inserire il tempo massimo per la consegna verifica");
                return;
            }
            q.TimeLimit = timeLimit;

            for (int i = 0; i < forms; i++)
            {
                TabPage t = tabControl.TabPages[i];
                FormControl fc = t.Controls[0] as FormControl;
                if (fc != null)
                {
                    QuizForm res = fc.GetForm();
                    q.Forms.Add(res);
                }
            }

            string json = JsonConvert.SerializeObject(q);
            var fileToSave = Path.Combine(_curFolder, txtFilename.Text);
            if (File.Exists(fileToSave))
            {
                switch (MessageBox.Show($"SovraScrivere {fileToSave}?", "Attenzione", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        return;
                    default:
                        break;
                }
            }

            File.WriteAllText(fileToSave, json);
            MessageBox.Show("File salvato");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Apri verifica";
            theDialog.Filter = "GRO files|*.gro";
            if (theDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = theDialog.FileName;

            Quiz quiz = JsonConvert.DeserializeObject<Quiz>(File.ReadAllText(filename));

            dtStart.Value = quiz.StartDateTime;
            checkRandomForms.Checked = quiz.RandomForms;
            checkRandomQuestions.Checked = quiz.RandomQuestions;
            checkAllowBack.Checked = quiz.AllowBack;
            txtTime.Text = quiz.TimeLimit.ToString();
            tabControl.TabPages.Clear();

            for (int i = 0; i < 5; i++)
            {
                TabPage tabPage = new TabPage($"Scheda {i + 1}");
                var fc = new GroguControls.FormControl()
                {
                    IsDesign = true,
                    Id = (i + 1).ToString(),
                    Dock = DockStyle.Fill,
                    DataSource = quiz.Forms[i]
                };
                tabPage.Controls.Add(fc);
                tabControl.TabPages.Add(tabPage);
            }
        }
    }
}
