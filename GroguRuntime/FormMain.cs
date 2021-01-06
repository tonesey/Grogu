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
        private int _totalMinutes;

        public DateTime _endTime { get; private set; }

        private int _totalForms;
        private int _curFormIndex;

        private DateTime _startTime;

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
                return;
            }

            Quiz quiz = JsonConvert.DeserializeObject<Quiz>(File.ReadAllText(dataFile));

            _totalForms = quiz.Forms.Count;
            _curFormIndex = 0;
            UpdateTitle();

            _randomForms = quiz.RandomForms;
            _randomQuestions = quiz.RandomQuestions;
            _allowBack = quiz.AllowBack;
            _totalMinutes = quiz.TimeLimit;

            _endTime = DateTime.Now.AddMinutes(_totalMinutes);

            btnBack.Enabled = _allowBack;

            tabControl.TabPages.Clear();
            for (int i = 0; i < _totalForms; i++)
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

            StartTimer();
        }

        private void StartTimer()
        {
            _startTime = Utils.GetNistTime();
            timer1.Enabled = true;
        }

        private void UpdateTitle()
        {
            labelTitle.Text = $"Quesito {_curFormIndex + 1}/{_totalForms}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void btnAhead_Click(object sender, EventArgs e)
        {
            var curIndex = tabControl.SelectedIndex;
            if (curIndex + 1 < tabControl.TabPages.Count)
            {
                switch (MessageBox.Show($"Non sarà possibile tornare al quesito precedente, proseguire? ", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case DialogResult.No:
                        return;
                    default:
                        break;
                }

                tabControl.SelectedIndex = curIndex + 1;
                _curFormIndex = tabControl.SelectedIndex;
            }
            else
            {
                //TODO richiedere consegna
                switch (MessageBox.Show($"Consegnare? ", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case DialogResult.No:
                        return;
                    default:
                        break;
                }
            }

            UpdateTitle();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _startTime.AddSeconds(1);
            UpdateProgr();
        }

        private void UpdateProgr()
        {
            


        }
    }
}
