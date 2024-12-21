namespace ZombieSimulation.Forms
{
    partial class MainForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.pauseButton = new Button { Text = "Pause", Location = new Point(10, 650) };
            this.pauseButton.Click += PauseButton_Click;
            this.Controls.Add(this.pauseButton);

            this.saveButton = new Button { Text = "Save", Location = new Point(100, 650) };
            this.saveButton.Click += SaveButton_Click;
            this.Controls.Add(this.saveButton);

            this.loadButton = new Button { Text = "Load", Location = new Point(190, 650) };
            this.loadButton.Click += LoadButton_Click;
            this.Controls.Add(this.loadButton);

            this.restartButton = new Button { Text = "Restart", Location = new Point(280, 650) };
            this.restartButton.Click += RestartButton_Click;
            this.Controls.Add(this.restartButton);

            this.unitCountLabel = new Label { Text = "Number of units:", Location = new Point(370, 630), AutoSize = true };
            this.Controls.Add(this.unitCountLabel);

            this.unitCountTextBox = new TextBox { Location = new Point(370, 650), Width = 100, Text = "200", TextAlign = HorizontalAlignment.Center };
            this.Controls.Add(this.unitCountTextBox);

            this.intervalLabel = new Label { Text = "Interval (ms):", Location = new Point(480, 630), AutoSize = true };
            this.Controls.Add(this.intervalLabel);

            this.intervalTextBox = new TextBox { Location = new Point(480, 650), Width = 75, Text = "100", TextAlign = HorizontalAlignment.Center };
            this.intervalTextBox.TextChanged += IntervalTextBox_TextChanged;
            this.Controls.Add(this.intervalTextBox);

            this.timeUntilZombieDeathLabel = new Label { Text = "Time until zombie death (ticks):", Location = new Point(565, 630), AutoSize = true };
            this.Controls.Add(this.timeUntilZombieDeathLabel);

            this.timeUntilZombieDeathTextBox = new TextBox { Location = new Point(565, 650), Width = 170, Text = "100", TextAlign = HorizontalAlignment.Center };
            this.timeUntilZombieDeathTextBox.TextChanged += TimeUntilZombieDeathTextBox_TextChanged;
            this.Controls.Add(this.timeUntilZombieDeathTextBox);

            this.cureLabel = new Label { Text = "Click on a zombie to cure it.", Location = new Point(10, 620), BackColor = Color.LightYellow, AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };
            this.Controls.Add(this.cureLabel);

            this.timer = new System.Windows.Forms.Timer { Interval = 100 };
            this.timer.Tick += Timer_Tick;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(850, 725);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Zombie Simulation";
            this.ResumeLayout(false);
        }
    }
}
