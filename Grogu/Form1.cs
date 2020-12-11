using GroguControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grogu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btCreateLayout_Click(object sender, EventArgs e)
        {

            var forms = Convert.ToInt32(txtForms.Text);
            //var questions = Convert.ToInt32(txtQuestions.Text);
            this.SuspendLayout();
            for (int i = 0; i < forms; i++)
            {
                TabPage t = new TabPage($"Quesito {i + 1}");
                var fc = new GroguControls.FormControl();
                fc.Dock = DockStyle.Fill;
                t.Controls.Add(fc);
                tabControl.TabPages.Add(t);
                //t.Controls.Add()
            }
            this.ResumeLayout();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var forms = Convert.ToInt32(txtForms.Text);
            for (int i = 0; i < forms; i++)
            {
                TabPage t = tabControl.TabPages[i];
                FormControl fc = t.Controls[0] as FormControl;
                if (fc != null) {

                    var res = fc.GetForm();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
