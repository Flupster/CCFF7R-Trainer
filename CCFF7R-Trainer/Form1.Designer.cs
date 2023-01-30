namespace CCFF7R_Trainer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.gameProcessFoundLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxInstantDeath = new System.Windows.Forms.CheckBox();
            this.dataGridElapsed = new System.Windows.Forms.DataGridView();
            this.Elapsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelBattleState = new System.Windows.Forms.Label();
            this.checkBoxSkipBattles = new System.Windows.Forms.CheckBox();
            this.checkBoxInstantBattleSkip = new System.Windows.Forms.CheckBox();
            this.labelStopwatch = new System.Windows.Forms.Label();
            this.dataGridHP = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridElapsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHP)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "HP";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameProcessFoundLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(294, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // gameProcessFoundLabel
            // 
            this.gameProcessFoundLabel.Name = "gameProcessFoundLabel";
            this.gameProcessFoundLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gameProcessFoundLabel.Size = new System.Drawing.Size(59, 17);
            this.gameProcessFoundLabel.Text = "Loading...";
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 5;
            this.mainTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxInstantDeath
            // 
            this.checkBoxInstantDeath.AutoSize = true;
            this.checkBoxInstantDeath.Checked = true;
            this.checkBoxInstantDeath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInstantDeath.Location = new System.Drawing.Point(12, 12);
            this.checkBoxInstantDeath.Name = "checkBoxInstantDeath";
            this.checkBoxInstantDeath.Size = new System.Drawing.Size(135, 19);
            this.checkBoxInstantDeath.TabIndex = 1;
            this.checkBoxInstantDeath.Text = "Instant death on end";
            this.checkBoxInstantDeath.UseVisualStyleBackColor = true;
            // 
            // dataGridElapsed
            // 
            this.dataGridElapsed.AllowUserToAddRows = false;
            this.dataGridElapsed.AllowUserToResizeColumns = false;
            this.dataGridElapsed.AllowUserToResizeRows = false;
            this.dataGridElapsed.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridElapsed.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridElapsed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridElapsed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Elapsed});
            this.dataGridElapsed.Location = new System.Drawing.Point(185, 12);
            this.dataGridElapsed.Name = "dataGridElapsed";
            this.dataGridElapsed.ReadOnly = true;
            this.dataGridElapsed.RowHeadersVisible = false;
            this.dataGridElapsed.RowTemplate.Height = 25;
            this.dataGridElapsed.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridElapsed.Size = new System.Drawing.Size(103, 412);
            this.dataGridElapsed.TabIndex = 2;
            // 
            // Elapsed
            // 
            this.Elapsed.HeaderText = "Elapsed";
            this.Elapsed.Name = "Elapsed";
            this.Elapsed.ReadOnly = true;
            this.Elapsed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // labelBattleState
            // 
            this.labelBattleState.AutoSize = true;
            this.labelBattleState.Location = new System.Drawing.Point(12, 154);
            this.labelBattleState.Name = "labelBattleState";
            this.labelBattleState.Size = new System.Drawing.Size(78, 15);
            this.labelBattleState.TabIndex = 3;
            this.labelBattleState.Text = "Battle State: 0";
            // 
            // checkBoxSkipBattles
            // 
            this.checkBoxSkipBattles.AutoSize = true;
            this.checkBoxSkipBattles.Location = new System.Drawing.Point(12, 37);
            this.checkBoxSkipBattles.Name = "checkBoxSkipBattles";
            this.checkBoxSkipBattles.Size = new System.Drawing.Size(86, 19);
            this.checkBoxSkipBattles.TabIndex = 5;
            this.checkBoxSkipBattles.Text = "Skip Battles";
            this.checkBoxSkipBattles.UseVisualStyleBackColor = true;
            // 
            // checkBoxInstantBattleSkip
            // 
            this.checkBoxInstantBattleSkip.AutoSize = true;
            this.checkBoxInstantBattleSkip.Location = new System.Drawing.Point(12, 62);
            this.checkBoxInstantBattleSkip.Name = "checkBoxInstantBattleSkip";
            this.checkBoxInstantBattleSkip.Size = new System.Drawing.Size(168, 19);
            this.checkBoxInstantBattleSkip.TabIndex = 6;
            this.checkBoxInstantBattleSkip.Text = "Instant Skip Battle (Glitchy)";
            this.checkBoxInstantBattleSkip.UseVisualStyleBackColor = true;
            // 
            // labelStopwatch
            // 
            this.labelStopwatch.AutoSize = true;
            this.labelStopwatch.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelStopwatch.Location = new System.Drawing.Point(12, 105);
            this.labelStopwatch.Name = "labelStopwatch";
            this.labelStopwatch.Size = new System.Drawing.Size(91, 32);
            this.labelStopwatch.TabIndex = 8;
            this.labelStopwatch.Text = "00.000";
            // 
            // dataGridHP
            // 
            this.dataGridHP.AllowUserToAddRows = false;
            this.dataGridHP.AllowUserToDeleteRows = false;
            this.dataGridHP.AllowUserToResizeColumns = false;
            this.dataGridHP.AllowUserToResizeRows = false;
            this.dataGridHP.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridHP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridHP.Location = new System.Drawing.Point(12, 172);
            this.dataGridHP.Name = "dataGridHP";
            this.dataGridHP.ReadOnly = true;
            this.dataGridHP.RowHeadersVisible = false;
            this.dataGridHP.RowTemplate.Height = 25;
            this.dataGridHP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridHP.Size = new System.Drawing.Size(164, 252);
            this.dataGridHP.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 449);
            this.Controls.Add(this.labelStopwatch);
            this.Controls.Add(this.checkBoxInstantBattleSkip);
            this.Controls.Add(this.checkBoxSkipBattles);
            this.Controls.Add(this.labelBattleState);
            this.Controls.Add(this.dataGridElapsed);
            this.Controls.Add(dataGridHP);
            this.Controls.Add(this.checkBoxInstantDeath);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CCFF7R Battle Timer";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridElapsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        public ToolStripStatusLabel gameProcessFoundLabel;
        private System.Windows.Forms.Timer mainTimer;
        private CheckBox checkBoxInstantDeath;
        private DataGridView dataGridElapsed;
        private DataGridView dataGridHP;
        private Label labelBattleState;
        private DataGridViewTextBoxColumn Elapsed;
        private CheckBox checkBoxSkipBattles;
        private CheckBox checkBoxInstantBattleSkip;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Label labelStopwatch;
    }
}