namespace SafeCrackerPuzzle
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grpBxGame = new System.Windows.Forms.GroupBox();
            this.lblTile = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAutoSolve = new System.Windows.Forms.Button();
            this.chkBxDisplayTotals = new System.Windows.Forms.CheckBox();
            this.chkBxEnableHint1 = new System.Windows.Forms.CheckBox();
            this.chkBxEnableHint2 = new System.Windows.Forms.CheckBox();
            this.lblDummy = new System.Windows.Forms.Label();
            this.btnShowSolution = new System.Windows.Forms.Button();
            this.grpBxGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxGame
            // 
            this.grpBxGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBxGame.Controls.Add(this.lblDummy);
            this.grpBxGame.Controls.Add(this.lblTile);
            this.grpBxGame.Controls.Add(this.btnRight);
            this.grpBxGame.Controls.Add(this.btnLeft);
            this.grpBxGame.Location = new System.Drawing.Point(5, 5);
            this.grpBxGame.Name = "grpBxGame";
            this.grpBxGame.Size = new System.Drawing.Size(822, 162);
            this.grpBxGame.TabIndex = 0;
            this.grpBxGame.TabStop = false;
            this.grpBxGame.Text = "Game";
            // 
            // lblTile
            // 
            this.lblTile.BackColor = System.Drawing.Color.Silver;
            this.lblTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTile.Location = new System.Drawing.Point(88, 18);
            this.lblTile.Name = "lblTile";
            this.lblTile.Size = new System.Drawing.Size(44, 24);
            this.lblTile.TabIndex = 2;
            this.lblTile.Text = "999";
            this.lblTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Wingdings 3", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRight.Location = new System.Drawing.Point(47, 18);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(39, 23);
            this.btnRight.TabIndex = 1;
            this.btnRight.Text = "Æ";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Wingdings 3", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnLeft.Location = new System.Drawing.Point(7, 18);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(39, 23);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Text = "Å";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(832, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(92, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(833, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btnAutoSolve
            // 
            this.btnAutoSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoSolve.Location = new System.Drawing.Point(832, 36);
            this.btnAutoSolve.Name = "btnAutoSolve";
            this.btnAutoSolve.Size = new System.Drawing.Size(92, 23);
            this.btnAutoSolve.TabIndex = 3;
            this.btnAutoSolve.Text = "Auto-Solve";
            this.btnAutoSolve.UseVisualStyleBackColor = true;
            this.btnAutoSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // chkBxDisplayTotals
            // 
            this.chkBxDisplayTotals.AutoCheck = false;
            this.chkBxDisplayTotals.AutoSize = true;
            this.chkBxDisplayTotals.Location = new System.Drawing.Point(833, 90);
            this.chkBxDisplayTotals.Name = "chkBxDisplayTotals";
            this.chkBxDisplayTotals.Size = new System.Drawing.Size(92, 17);
            this.chkBxDisplayTotals.TabIndex = 4;
            this.chkBxDisplayTotals.Text = "Display Totals";
            this.chkBxDisplayTotals.UseVisualStyleBackColor = true;
            this.chkBxDisplayTotals.Click += new System.EventHandler(this.chkBxDisplayTotals_Click);
            // 
            // chkBxEnableHint1
            // 
            this.chkBxEnableHint1.AutoCheck = false;
            this.chkBxEnableHint1.AutoSize = true;
            this.chkBxEnableHint1.Location = new System.Drawing.Point(833, 109);
            this.chkBxEnableHint1.Name = "chkBxEnableHint1";
            this.chkBxEnableHint1.Size = new System.Drawing.Size(90, 17);
            this.chkBxEnableHint1.TabIndex = 5;
            this.chkBxEnableHint1.Text = "Enable Hint 1";
            this.chkBxEnableHint1.UseVisualStyleBackColor = true;
            this.chkBxEnableHint1.Click += new System.EventHandler(this.chkBxEnableHint_Click);
            // 
            // chkBxEnableHint2
            // 
            this.chkBxEnableHint2.AutoCheck = false;
            this.chkBxEnableHint2.AutoSize = true;
            this.chkBxEnableHint2.Location = new System.Drawing.Point(833, 128);
            this.chkBxEnableHint2.Name = "chkBxEnableHint2";
            this.chkBxEnableHint2.Size = new System.Drawing.Size(90, 17);
            this.chkBxEnableHint2.TabIndex = 6;
            this.chkBxEnableHint2.Text = "Enable Hint 2";
            this.chkBxEnableHint2.UseVisualStyleBackColor = true;
            this.chkBxEnableHint2.Click += new System.EventHandler(this.chkBxEnableHint2_Click);
            // 
            // lblDummy
            // 
            this.lblDummy.AutoSize = true;
            this.lblDummy.Location = new System.Drawing.Point(7, 44);
            this.lblDummy.Name = "lblDummy";
            this.lblDummy.Size = new System.Drawing.Size(339, 13);
            this.lblDummy.TabIndex = 3;
            this.lblDummy.Text = "The field is dynamically generated based on the location of these items";
            this.lblDummy.Visible = false;
            // 
            // btnShowSolution
            // 
            this.btnShowSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowSolution.Location = new System.Drawing.Point(832, 63);
            this.btnShowSolution.Name = "btnShowSolution";
            this.btnShowSolution.Size = new System.Drawing.Size(92, 23);
            this.btnShowSolution.TabIndex = 7;
            this.btnShowSolution.Text = "Show Solution";
            this.btnShowSolution.UseVisualStyleBackColor = true;
            this.btnShowSolution.Click += new System.EventHandler(this.btnShowSolution_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 172);
            this.Controls.Add(this.btnShowSolution);
            this.Controls.Add(this.chkBxEnableHint2);
            this.Controls.Add(this.chkBxEnableHint1);
            this.Controls.Add(this.chkBxDisplayTotals);
            this.Controls.Add(this.btnAutoSolve);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.grpBxGame);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(944, 211);
            this.MinimumSize = new System.Drawing.Size(944, 211);
            this.Name = "Form1";
            this.Text = "SafeCracker 50 Puzzle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grpBxGame.ResumeLayout(false);
            this.grpBxGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxGame;
        private System.Windows.Forms.Label lblTile;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAutoSolve;
        private System.Windows.Forms.CheckBox chkBxDisplayTotals;
        private System.Windows.Forms.CheckBox chkBxEnableHint1;
        private System.Windows.Forms.CheckBox chkBxEnableHint2;
        private System.Windows.Forms.Label lblDummy;
        private System.Windows.Forms.Button btnShowSolution;
    }
}

