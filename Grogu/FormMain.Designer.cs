
namespace Grogu
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtForms = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btCreateLayout = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.checkRandomForms = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.checkRandomQuestions = new System.Windows.Forms.CheckBox();
            this.checkAllowBack = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtForms
            // 
            this.txtForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtForms.Location = new System.Drawing.Point(233, 538);
            this.txtForms.Name = "txtForms";
            this.txtForms.Size = new System.Drawing.Size(35, 20);
            this.txtForms.TabIndex = 0;
            this.txtForms.Text = "5";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 542);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nr Schede";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.Location = new System.Drawing.Point(17, 566);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(129, 24);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Genera e salva";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(17, 624);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Esci";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1101, 501);
            this.tabControl.TabIndex = 8;
            // 
            // btCreateLayout
            // 
            this.btCreateLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCreateLayout.Location = new System.Drawing.Point(17, 537);
            this.btCreateLayout.Name = "btCreateLayout";
            this.btCreateLayout.Size = new System.Drawing.Size(129, 23);
            this.btCreateLayout.TabIndex = 9;
            this.btCreateLayout.Text = "Crea layout";
            this.btCreateLayout.UseVisualStyleBackColor = true;
            this.btCreateLayout.Click += new System.EventHandler(this.btCreateLayout_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 572);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nome";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilename.Location = new System.Drawing.Point(233, 568);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(162, 20);
            this.txtFilename.TabIndex = 10;
            this.txtFilename.Text = "quiz1.gro";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpen.Location = new System.Drawing.Point(17, 595);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(129, 23);
            this.buttonOpen.TabIndex = 12;
            this.buttonOpen.Text = "Apri...";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // checkRandomForms
            // 
            this.checkRandomForms.AutoSize = true;
            this.checkRandomForms.Location = new System.Drawing.Point(10, 73);
            this.checkRandomForms.Name = "checkRandomForms";
            this.checkRandomForms.Size = new System.Drawing.Size(146, 17);
            this.checkRandomForms.TabIndex = 13;
            this.checkRandomForms.Text = "Schede in ordine casuale";
            this.checkRandomForms.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkAllowBack);
            this.groupBox1.Controls.Add(this.checkRandomQuestions);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.checkRandomForms);
            this.groupBox1.Location = new System.Drawing.Point(416, 537);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 111);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opzioni esecuzione verifica";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tempo Massimo (min)";
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTime.Location = new System.Drawing.Point(121, 25);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(35, 20);
            this.txtTime.TabIndex = 14;
            this.txtTime.Text = "30";
            // 
            // checkRandomQuestions
            // 
            this.checkRandomQuestions.AutoSize = true;
            this.checkRandomQuestions.Location = new System.Drawing.Point(197, 50);
            this.checkRandomQuestions.Name = "checkRandomQuestions";
            this.checkRandomQuestions.Size = new System.Drawing.Size(155, 17);
            this.checkRandomQuestions.TabIndex = 16;
            this.checkRandomQuestions.Text = "Domande in ordine casuale";
            this.checkRandomQuestions.UseVisualStyleBackColor = true;
            // 
            // checkAllowBack
            // 
            this.checkAllowBack.AutoSize = true;
            this.checkAllowBack.Location = new System.Drawing.Point(9, 50);
            this.checkAllowBack.Name = "checkAllowBack";
            this.checkAllowBack.Size = new System.Drawing.Size(182, 17);
            this.checkAllowBack.TabIndex = 17;
            this.checkAllowBack.Text = "Consenti ritorno a domanda prec.";
            this.checkAllowBack.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 659);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btCreateLayout);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtForms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Grogu Quiz Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtForms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btCreateLayout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.CheckBox checkRandomForms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkAllowBack;
        private System.Windows.Forms.CheckBox checkRandomQuestions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
    }
}

