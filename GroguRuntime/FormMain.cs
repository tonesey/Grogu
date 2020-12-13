using GroguCommon;
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

namespace GroguRuntime
{
    public partial class FormExecutor : Form
    {

        string _curFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        string _dataFile = "data.gro";

        private bool _randomForms;
        private bool _randomQuestions;
        private bool _allowBack;
        private string _timeLimit;

        public FormExecutor()
        {
            InitializeComponent();
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var dataFile = Path.Combine(_curFolder, _dataFile);
            if (!File.Exists(dataFile))
            {
                MessageBox.Show($"Impossibile trovare il file {dataFile}");
            }

            Quiz quiz = JsonConvert.DeserializeObject<Quiz>(File.ReadAllText(dataFile));

            _randomForms = quiz.RandomForms;
            _randomQuestions = quiz.RandomQuestions;
            _allowBack = quiz.AllowBack;
            _timeLimit = quiz.TimeLimit.ToString();

            tabControl.TabPages.Clear();
            for (int i = 0; i < quiz.Forms.Count; i++)
            {
                TabPage tabPage = new TabPage($"Scheda {i + 1}");
                var fc = new GroguControls.FormControl()
                {
                    IsDesign = false,
                    Id = (i + 1).ToString(),
                    Dock = DockStyle.Fill,
                    DataSource = quiz.Forms[i]
                };
                tabPage.Controls.Add(fc);
                tabControl.TabPages.Add(tabPage);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnAhead_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
