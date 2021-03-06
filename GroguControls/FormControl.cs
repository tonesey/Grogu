﻿using GroguCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroguControls
{
    public partial class FormControl : UserControl
    {
        //public bool IsOpen { get; private set; } = false;
        public bool IsDesign { get; set; } = true;
        public string Id { get; set; }

        QuizForm _DataSource = null;
        public QuizForm DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
                _isDsChange = true;
                OnDataSourceChanged(value);
                _isDsChange = false;
            }
        }

        public FormControl()
        {
            InitializeComponent();
            piA1.SizeMode = PictureBoxSizeMode.Normal;
            piA2.SizeMode = PictureBoxSizeMode.Normal;
            piA3.SizeMode = PictureBoxSizeMode.Normal;
            piA4.SizeMode = PictureBoxSizeMode.Normal;
            piA5.SizeMode = PictureBoxSizeMode.Normal;
            txtOpenResp.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //for (int i = 1; i <= 5; i++)
            //{
            //    TextBox txt = GetControl($"txtA{i}Value") as TextBox;
            //    txt.Visible = IsDesign;
            //    PictureBox pi = GetControl($"piA{i}") as PictureBox;
            //    CheckBox chSel = GetControl($"chSel{i}") as CheckBox;
            //    chSel.Visible = !IsDesign;
            //}

            //chOpen.Visible = IsDesign;

            //if (IsDesign)
            //{
            //    tableLayoutPanelMain.ColumnStyles[2] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F);
            //}
            //else
            //{
            //    tableLayoutPanelMain.ColumnStyles[2] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F);
            //}
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
            if (!IsDesign) return;
            Image cImage = Clipboard.GetImage();

            if (cImage != null)
            {
                target.Image = (Image)cImage;
            }
        }

        bool _isDsChange = false;
        private void OnDataSourceChanged(QuizForm qf)
        {
            if (qf == null)
            {
                return;
            }

            piQ.Image = Utils.Base64ToImage(qf.Question.ImageContent);

            if (IsDesign && qf.IsOpen)
            {
                chOpen.Checked = true;
            }

            for (int i = 1; i <= qf.Answers.Count; i++)
            {
                Answer answer = qf.Answers.ElementAt(i - 1);
                TextBox txtValue = GetControl($"txtA{i}Value") as TextBox;
                PictureBox piAnswer = GetControl($"piA{i}") as PictureBox;

                if (!string.IsNullOrEmpty(answer.ImageContent))
                {
                    piAnswer.Image = Utils.Base64ToImage(answer.ImageContent);
                }
                if (IsDesign)
                {
                    txtValue.Text = answer.Value.ToString();
                }
            }

            UpdateUI(qf.IsOpen);
        }

        public QuizForm GetForm()
        {
            QuizForm qf = new QuizForm
            {
                Question = new Question()
            };

            //validazione
            if (piQ.Image == null)
            {
                MessageBox.Show($"Domanda mancante in scheda {Id}");
                return null;
            }

            for (int i = 1; i <= 5; i++)
            {
                TextBox txt = GetControl($"txtA{i}Value") as TextBox;
                PictureBox pi = GetControl($"piA{i}") as PictureBox;
                double qVal;
                if (!qf.IsOpen && (pi.Image != null) && !double.TryParse(txt.Text, out qVal))
                {
                    MessageBox.Show($"Inserire valore risposta {i} in scheda {Id}");
                    return null;
                }
            }

            qf.Question.ImageContent = Utils.ImageToBase64(piQ.Image);
            qf.IsOpen = chOpen.Checked;

            for (int i = 1; i <= 5; i++)
            {
                PictureBox pi = GetControl($"piA{i}") as PictureBox;
                TextBox txt = GetControl($"txtA{i}Value") as TextBox;
                Answer answ = new Answer();
                bool answerValid = false;
                if (!qf.IsOpen)
                {
                    //risposta chiusa - immagine
                    if (pi.Image != null)
                    {
                        answ.ImageContent = Utils.ImageToBase64(pi.Image);
                        answ.Value = Convert.ToDouble(txt.Text);
                        answerValid = true;
                    }
                }

                if (answerValid)
                {
                    qf.Answers.Add(answ);
                }
            }
            return qf;
        }

        public Image GetQuestion()
        {
            return piQ.Image;
        }

        public Image GetAnswer()
        {
            Image retVal = null;
            if (DataSource.IsOpen)
            {
                //se aperta ricavare immagine da textbox
                retVal = Utils.DrawText(txtOpenResp.Text);
                retVal.Save($@"c:\temp\res_open_{Id}.png", ImageFormat.Png);
            }
            else
            {
                List<Bitmap> multiRes = new List<Bitmap>();
                //se a risposte multiple restituire immagine corrispondente al check attuale
                for (int i = 1; i <= 5; i++)
                {
                    CheckBox chSel = GetControl($"chSel{i}") as CheckBox;
                    if (chSel.Checked)
                    {
                        //risposta selezionata
                        PictureBox pi = GetControl($"piA{i}") as PictureBox;
                        multiRes.Add((Bitmap)pi.Image);
                    }
                }
                retVal = Utils.MergeImages(multiRes);
                retVal.Save($@"c:\temp\res_multi_{Id}.png", ImageFormat.Png);
            }
            return retVal;
        }

        private void chOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (_isDsChange) return;

            //IsOpen = chOpen.Checked;
            UpdateUI(chOpen.Checked);
        }

        private void UpdateUI(bool isOpen)
        {
            this.SuspendLayout();

            if (isOpen)
            {
                //risposte aperte
                tableLayoutPanelMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            }
            else
            {
                //scelta multipla
                tableLayoutPanelMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            }

            for (int i = 1; i <= 5; i++)
            {
                PictureBox pi = GetControl($"piA{i}") as PictureBox;
                pi.SizeMode = PictureBoxSizeMode.Normal;
                TextBox txt = GetControl($"txtA{i}Value") as TextBox;
                pi.Visible = !isOpen;
                txt.Visible = !isOpen && IsDesign;
                Label l = GetControl($"labelA{i}") as Label;
                l.Visible = !isOpen;
                CheckBox chSel = GetControl($"chSel{i}") as CheckBox;
                chSel.Visible = !isOpen && !IsDesign;
            }

            chOpen.Visible = IsDesign;

            txtOpenResp.Visible = !IsDesign && isOpen;

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

        private void labelA1_Click(object sender, EventArgs e)
        {

        }


    }
}
