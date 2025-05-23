namespace Osobne_Financije
{
    partial class FrmSavingsGoals
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblExpenses = new System.Windows.Forms.Label();
            this.lblReports = new System.Windows.Forms.Label();
            this.lblIncomes = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCurrentSavings = new System.Windows.Forms.TextBox();
            this.txtSavingsGoal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGoal = new System.Windows.Forms.Button();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.txtGoalAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLimitAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLimit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvLimits = new System.Windows.Forms.DataGridView();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLimits)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.Navy;
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.btnLogout);
            this.panel4.Controls.Add(this.lblExpenses);
            this.panel4.Controls.Add(this.lblReports);
            this.panel4.Controls.Add(this.lblIncomes);
            this.panel4.Controls.Add(this.lblMain);
            this.panel4.Location = new System.Drawing.Point(-1, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(264, 702);
            this.panel4.TabIndex = 19;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::Osobne_Financije.Properties.Resources.Untitled_design__7_1;
            this.pictureBox2.Location = new System.Drawing.Point(25, 650);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Osobne_Financije.Properties.Resources.Untitled_design__4_3;
            this.pictureBox1.Location = new System.Drawing.Point(65, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogout.Location = new System.Drawing.Point(74, 650);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(118, 38);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "ODJAVA";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblExpenses
            // 
            this.lblExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpenses.AutoSize = true;
            this.lblExpenses.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblExpenses.ForeColor = System.Drawing.Color.White;
            this.lblExpenses.Location = new System.Drawing.Point(70, 414);
            this.lblExpenses.Name = "lblExpenses";
            this.lblExpenses.Size = new System.Drawing.Size(105, 21);
            this.lblExpenses.TabIndex = 6;
            this.lblExpenses.Text = "TROŠKOVI";
            this.lblExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExpenses.Click += new System.EventHandler(this.lblExpenses_Click);
            this.lblExpenses.MouseEnter += new System.EventHandler(this.lblExpenses_MouseEnter);
            this.lblExpenses.MouseLeave += new System.EventHandler(this.lblExpense_MouseLeave);
            // 
            // lblReports
            // 
            this.lblReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblReports.ForeColor = System.Drawing.Color.White;
            this.lblReports.Location = new System.Drawing.Point(70, 500);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(110, 21);
            this.lblReports.TabIndex = 4;
            this.lblReports.Text = "IZVJEŠTAJI";
            this.lblReports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReports.Click += new System.EventHandler(this.lblReports_Click);
            this.lblReports.MouseEnter += new System.EventHandler(this.lblReports_MouseEnter);
            this.lblReports.MouseLeave += new System.EventHandler(this.lblReports_MouseLeave);
            // 
            // lblIncomes
            // 
            this.lblIncomes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIncomes.AutoSize = true;
            this.lblIncomes.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblIncomes.ForeColor = System.Drawing.Color.White;
            this.lblIncomes.Location = new System.Drawing.Point(80, 333);
            this.lblIncomes.Name = "lblIncomes";
            this.lblIncomes.Size = new System.Drawing.Size(85, 21);
            this.lblIncomes.TabIndex = 2;
            this.lblIncomes.Text = "PRIHODI";
            this.lblIncomes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIncomes.Click += new System.EventHandler(this.lblIncomes_Click);
            this.lblIncomes.MouseEnter += new System.EventHandler(this.lblIncomes_MouseEnter);
            this.lblIncomes.MouseLeave += new System.EventHandler(this.lblIncomes_MouseLeave);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblMain.ForeColor = System.Drawing.Color.White;
            this.lblMain.Location = new System.Drawing.Point(77, 251);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(98, 21);
            this.lblMain.TabIndex = 1;
            this.lblMain.Text = "POČETNA";
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMain.Click += new System.EventHandler(this.lblMain_Click);
            this.lblMain.MouseEnter += new System.EventHandler(this.lblMain_MouseEnter);
            this.lblMain.MouseLeave += new System.EventHandler(this.lblMain_MouseLeave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label11.Location = new System.Drawing.Point(67, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(275, 35);
            this.label11.TabIndex = 1;
            this.label11.Text = "CILJEVI ŠTEDNJE";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(721, 26);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.label1.Size = new System.Drawing.Size(159, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cilj uštede:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Menu;
            this.panel3.Controls.Add(this.txtCurrentSavings);
            this.panel3.Controls.Add(this.txtSavingsGoal);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(262, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1086, 120);
            this.panel3.TabIndex = 20;
            // 
            // txtCurrentSavings
            // 
            this.txtCurrentSavings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentSavings.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentSavings.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentSavings.ForeColor = System.Drawing.Color.Navy;
            this.txtCurrentSavings.Location = new System.Drawing.Point(891, 82);
            this.txtCurrentSavings.Name = "txtCurrentSavings";
            this.txtCurrentSavings.Size = new System.Drawing.Size(157, 28);
            this.txtCurrentSavings.TabIndex = 8;
            this.txtCurrentSavings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSavingsGoal
            // 
            this.txtSavingsGoal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavingsGoal.BackColor = System.Drawing.SystemColors.Window;
            this.txtSavingsGoal.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSavingsGoal.ForeColor = System.Drawing.Color.Navy;
            this.txtSavingsGoal.Location = new System.Drawing.Point(891, 34);
            this.txtSavingsGoal.Name = "txtSavingsGoal";
            this.txtSavingsGoal.Size = new System.Drawing.Size(157, 28);
            this.txtSavingsGoal.TabIndex = 7;
            this.txtSavingsGoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Menu;
            this.label8.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(657, 68);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(10, 8, 10, 7);
            this.label8.Size = new System.Drawing.Size(223, 42);
            this.label8.TabIndex = 5;
            this.label8.Text = "Trenutna ušteda:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(931, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "Iznos";
            // 
            // btnGoal
            // 
            this.btnGoal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoal.BackColor = System.Drawing.Color.Navy;
            this.btnGoal.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoal.ForeColor = System.Drawing.SystemColors.Window;
            this.btnGoal.Location = new System.Drawing.Point(1000, 270);
            this.btnGoal.Name = "btnGoal";
            this.btnGoal.Size = new System.Drawing.Size(135, 35);
            this.btnGoal.TabIndex = 39;
            this.btnGoal.Text = "POSTAVI CILJ";
            this.btnGoal.UseVisualStyleBackColor = false;
            this.btnGoal.Click += new System.EventHandler(this.btnGoal_Click);
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(449, 250);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(152, 24);
            this.cmbCategories.TabIndex = 38;
            // 
            // txtGoalAmount
            // 
            this.txtGoalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoalAmount.Location = new System.Drawing.Point(993, 232);
            this.txtGoalAmount.Name = "txtGoalAmount";
            this.txtGoalAmount.Size = new System.Drawing.Size(152, 22);
            this.txtGoalAmount.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(930, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 27);
            this.label5.TabIndex = 40;
            this.label5.Text = "CILJ UŠTEDE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(330, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 27);
            this.label3.TabIndex = 41;
            this.label3.Text = "LIMIT";
            // 
            // txtLimitAmount
            // 
            this.txtLimitAmount.Location = new System.Drawing.Point(449, 306);
            this.txtLimitAmount.Name = "txtLimitAmount";
            this.txtLimitAmount.Size = new System.Drawing.Size(152, 22);
            this.txtLimitAmount.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(332, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 21);
            this.label6.TabIndex = 43;
            this.label6.Text = "Iznos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(331, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Kategorija";
            // 
            // btnLimit
            // 
            this.btnLimit.BackColor = System.Drawing.Color.Navy;
            this.btnLimit.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLimit.Location = new System.Drawing.Point(466, 182);
            this.btnLimit.Name = "btnLimit";
            this.btnLimit.Size = new System.Drawing.Size(135, 35);
            this.btnLimit.TabIndex = 45;
            this.btnLimit.Text = "DODAJ LIMIT";
            this.btnLimit.UseVisualStyleBackColor = false;
            this.btnLimit.Click += new System.EventHandler(this.btnLimit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvLimits);
            this.panel1.Location = new System.Drawing.Point(335, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 274);
            this.panel1.TabIndex = 46;
            // 
            // dgvLimits
            // 
            this.dgvLimits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLimits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLimits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLimits.Location = new System.Drawing.Point(0, 0);
            this.dgvLimits.Name = "dgvLimits";
            this.dgvLimits.RowHeadersWidth = 51;
            this.dgvLimits.RowTemplate.Height = 24;
            this.dgvLimits.Size = new System.Drawing.Size(810, 274);
            this.dgvLimits.TabIndex = 0;
            // 
            // FrmSavingsGoals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1348, 699);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLimit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLimitAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGoal);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.txtGoalAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSavingsGoals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ciljevi štednje";
            this.Load += new System.EventHandler(this.FrmSavingsGoals_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLimits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblExpenses;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Label lblIncomes;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGoal;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.TextBox txtGoalAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLimitAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCurrentSavings;
        private System.Windows.Forms.TextBox txtSavingsGoal;
        private System.Windows.Forms.Button btnLimit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLimits;
    }
}