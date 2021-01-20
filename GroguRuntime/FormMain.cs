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

        string _answFile = "data.run";
        //string _answFilePath; 

        QuizAnswers _quizAnswers = new QuizAnswers();

        private bool _randomForms;
        private bool _randomQuestions;
        private bool _allowBack;
        private int _totalMinutes;

        public DateTime _endTime { get; private set; }
        public DateTime _curTime { get; private set; }

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

            #region verifica presenza quiz da ripristinare
            var resumedFile = Path.Combine(_curFolder, _answFile);
            if (File.Exists(resumedFile))
            {
                //resume da verifica interrotta
                _quizAnswers = JsonConvert.DeserializeObject<QuizAnswers>(File.ReadAllText(resumedFile));
                _curFormIndex = _quizAnswers.SavedAnswers.Count;
            }
            #endregion

            Quiz quiz = JsonConvert.DeserializeObject<Quiz>(File.ReadAllText(dataFile));

            //controllo inizio verifica
            _curTime = Utils.GetNistTime();
            var minStartTime = quiz.StartDateTime;
            if (_curTime < minStartTime)
            {
                MessageBox.Show($"La verifica può essere eseguita non prima della data: {minStartTime}");
                Application.Exit();
            }

            _totalForms = quiz.Forms.Count;

            UpdateTitle();

            _randomForms = quiz.RandomForms;
            _randomQuestions = quiz.RandomQuestions;
            _allowBack = quiz.AllowBack;
            _totalMinutes = quiz.TimeLimit;

            if (_randomForms)
            {
                quiz.Forms.Shuffle();
            }

            _endTime = DateTime.Now.AddMinutes(_totalMinutes);

            btnBack.Enabled = _allowBack;

            tabControl.TabPages.Clear();
            for (int i = 0; i < _totalForms; i++)
            {
                var qf = quiz.Forms[i];

                if (_randomQuestions)
                {
                    qf.Answers.Shuffle();
                }

                TabPage tabPage = new TabPage($"Scheda {i + 1}");
                var fc = new GroguControls.FormControl()
                {
                    IsDesign = false,
                    Id = (i + 1).ToString(),
                    Dock = DockStyle.Fill,
                    DataSource = qf
                };
                tabPage.Controls.Add(fc);
                tabControl.TabPages.Add(tabPage);
            }

            tabControl.SelectedIndex = _curFormIndex;

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
            if (tabControl.SelectedIndex + 1 < tabControl.TabPages.Count)
            {
                switch (MessageBox.Show($"Non sarà possibile tornare al quesito precedente, proseguire? ", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case DialogResult.No:
                        return;
                    default:
                        break;
                }

                var form = (tabControl.TabPages[_curFormIndex].Controls[0] as GroguControls.FormControl);
                SaveQuiz(form.GetQuestion(), form.GetAnswer());

                _curFormIndex++;

                tabControl.SelectedIndex = _curFormIndex;
            }
            else
            {
                //TODO richiedere consegna
                switch (MessageBox.Show($"Consegnare? ", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        return;
                    default:
                        break;
                }
            }

            UpdateTitle();
        }

        private void SaveQuiz(Image question, Image answer)
        {
            _quizAnswers.SavedAnswers.Add(new QuizAnswer() { QuestionImageContent = Utils.ImageToBase64(question), AnswerImageContent = Utils.ImageToBase64(answer) });
            string json = JsonConvert.SerializeObject(_quizAnswers);
            var fileToSave = Path.Combine(_curFolder, _answFile);
            if (File.Exists(fileToSave))
            {
                File.Delete(fileToSave);
            }
            File.WriteAllText(fileToSave, json);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateProgr();
        }

        private void UpdateProgr()
        {
            _curTime = _curTime.AddSeconds(1);
            var value = ((_curTime.Ticks - _startTime.Ticks) * 100) / (_endTime.Ticks - _startTime.Ticks);
            progressBar1.Value = (int)value;
        }
    }
}
