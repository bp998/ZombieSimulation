using System;
using System.Drawing;
using System.Windows.Forms;
using ZombieSimulation.Models;
using ZombieSimulation.Services;

namespace ZombieSimulation.Forms
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer timer;
        private Button pauseButton;
        private Button saveButton;
        private Button loadButton;
        private Button restartButton;
        private TextBox unitCountTextBox;
        private Label unitCountLabel;
        private TextBox intervalTextBox;
        private Label intervalLabel;
        private Label timeUntilZombieDeathLabel;
        private TextBox timeUntilZombieDeathTextBox;
        private Label cureLabel;
        private int timeUntilZombieDeath;

        public MainForm()
        {
            InitializeComponent();

            this.Text = "Zombie Simulation";
            this.Size = new Size(850, 725);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            timer.Start();

            this.MouseClick += MainForm_MouseClick;
            this.MouseMove += MainForm_MouseMove;

            GameState.Instance.InitializeUnits(200);

            if (int.TryParse(timeUntilZombieDeathTextBox.Text, out int timeToDeath))
            {
                timeUntilZombieDeath = timeToDeath;
            }
            else
            {
                timeUntilZombieDeath = 100;
            }
        }

        private void PauseButton_Click(object? sender, EventArgs e)
        {
            GameState.Instance.IsPaused = !GameState.Instance.IsPaused;
            pauseButton.Text = GameState.Instance.IsPaused ? "Resume" : "Pause";
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            GameState.Instance.SaveState("gamestate.dat");
        }

        private void LoadButton_Click(object? sender, EventArgs e)
        {
            GameState.Instance.LoadState("gamestate.dat");
            this.Invalidate();
        }

        private void RestartButton_Click(object? sender, EventArgs e)
        {
            if (int.TryParse(unitCountTextBox.Text, out int unitCount))
            {
                GameState.Instance.InitializeUnits(unitCount);
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Please enter a valid number of units.");
            }
        }

        private void IntervalTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (int.TryParse(intervalTextBox.Text, out int interval))
            {
                timer.Interval = interval;
            }
            else
            {
                MessageBox.Show("Please enter a valid interval in milliseconds.");
            }
        }

        private void TimeUntilZombieDeathTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (!int.TryParse(timeUntilZombieDeathTextBox.Text, out timeUntilZombieDeath))
            {
                MessageBox.Show("Please enter a valid time until zombie death in milliseconds.");
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (!GameState.Instance.IsPaused)
            {
                GameState.Instance.UpdateSimulation(timeUntilZombieDeath);
                this.Invalidate();
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 10;
            int y = e.Y / 10;

            foreach (var unit in GameState.Instance.Units)
            {
                if (unit.Position.X == x && unit.Position.Y == y && unit.State == UnitState.Zombie)
                {
                    unit.State = UnitState.Healthy;
                    this.Invalidate();
                    break;
                }
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / 10;
            int y = e.Y / 10;

            bool overZombie = false;
            foreach (var unit in GameState.Instance.Units)
            {
                if (unit.Position.X == x && unit.Position.Y == y && unit.State == UnitState.Zombie)
                {
                    overZombie = true;
                    break;
                }
            }

            this.Cursor = overZombie ? Cursors.Hand : Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            foreach (var unit in GameState.Instance.Units)
            {
                Brush brush;
                switch (unit.State)
                {
                    case UnitState.Healthy:
                        brush = Brushes.Green;
                        break;
                    case UnitState.Zombie:
                        brush = Brushes.Red;
                        break;
                    case UnitState.Dead:
                        brush = Brushes.Gray;
                        break;
                    default:
                        brush = Brushes.Black;
                        break;
                }
                g.FillRectangle(brush, unit.Position.X * 10, unit.Position.Y * 10, 10, 10);
            }
        }
    }
}
