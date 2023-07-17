namespace Game_of_life
{
    partial class Land
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
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            btnReset = new Button();
            btnPause = new Button();
            btnStart = new Button();
            toolTipInfo = new ToolTip(components);
            pnlCellContainer = new Panel();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.LightGreen;
            pnlHeader.Controls.Add(btnReset);
            pnlHeader.Controls.Add(btnPause);
            pnlHeader.Controls.Add(btnStart);
            pnlHeader.Location = new Point(-1, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1712, 112);
            pnlHeader.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.BackgroundImage = Properties.Resources.Reset;
            btnReset.BackgroundImageLayout = ImageLayout.Stretch;
            btnReset.Image = Properties.Resources.Reset;
            btnReset.Location = new Point(1593, 22);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(77, 68);
            btnReset.TabIndex = 2;
            btnReset.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTipInfo.SetToolTip(btnReset, "Reset");
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnPause
            // 
            btnPause.BackgroundImage = Properties.Resources.Pause;
            btnPause.BackgroundImageLayout = ImageLayout.Stretch;
            btnPause.Enabled = false;
            btnPause.Location = new Point(158, 22);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(77, 68);
            btnPause.TabIndex = 1;
            toolTipInfo.SetToolTip(btnPause, "Pause");
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStart
            // 
            btnStart.BackgroundImage = Properties.Resources.Start;
            btnStart.BackgroundImageLayout = ImageLayout.Stretch;
            btnStart.Image = Properties.Resources.Start;
            btnStart.Location = new Point(40, 21);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(76, 68);
            btnStart.TabIndex = 0;
            btnStart.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTipInfo.SetToolTip(btnStart, "Start");
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // pnlCellContainer
            // 
            pnlCellContainer.BackColor = Color.White;
            pnlCellContainer.Location = new Point(12, 126);
            pnlCellContainer.Name = "pnlCellContainer";
            pnlCellContainer.Size = new Size(1683, 710);
            pnlCellContainer.TabIndex = 1;
            // 
            // Land
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1707, 848);
            Controls.Add(pnlCellContainer);
            Controls.Add(pnlHeader);
            Name = "Land";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game of life";
            Load += Land_Load;
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnReset;
        private Button btnPause;
        private Button btnStart;
        private ToolTip toolTipInfo;
        private Panel pnlCellContainer;
    }
}