namespace WinFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class GameForm : Form
    {
        private Bird bird;
        private List<Pipe> pipes;
        private Timer gameTimer;
        private Label label1;
        private int score;
        private Random rand;

        public GameForm()
        {
            InitializeComponent();

            // Initialize game objects
            bird = new Bird(40, new Point(50, this.Height / 2));
            pipes = new List<Pipe>();
            AddPipe();

            // Start game timer
            gameTimer = new Timer();
            gameTimer.Interval = 30;
            gameTimer.Tick += new EventHandler(GameLoop);
            gameTimer.Start();

            // Initialize score label
            score = 0;
            label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16, FontStyle.Bold);
            label1.Location = new Point(10, 10);
            label1.Text = "Score: " + score;
            this.Controls.Add(label1);

            rand = new Random();
        }
        private void InitializeComponent()
        {
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "Score: 0";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 708);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "GameForm";
            Text = "GameForm";
            KeyDown += GameForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // Update bird position
            bird.Update();

            // Check for collision with pipes
            foreach (Pipe pipe in pipes)
            {
                if (bird.GetRectangle().IntersectsWith(pipe.GetTopRectangle()) ||
                    bird.GetRectangle().IntersectsWith(pipe.GetBottomRectangle()))
                {
                    gameTimer.Stop();
                    MessageBox.Show("Game over!");
                    return;
                }
            }

            // Move pipes to the left
            foreach (Pipe pipe in pipes)
            {
                pipe.Move();

                // Check for score
                if (!pipe.IsScored && pipe.X + pipe.Width < bird.X)
                {
                    pipe.IsScored = true;
                    score++;
                    label1.Text = "Score: " + score;
                }
            }

            // Add new pipe if necessary
            if (pipes[pipes.Count - 1].X + pipes[pipes.Count - 1].Width < this.Width)
            {
                AddPipe();
            }

            // Redraw the screen
            Invalidate();
        }

        private void AddPipe()
        {
            Random rand = new Random();
            int holePosition = rand.Next(150, 300);
            Pipe pipe = new Pipe(this.Width - 300, holePosition, 100, this.Height);
            pipes.Add(pipe);
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Debug.WriteLine(1234);
                bird.Flap();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw bird
            e.Graphics.FillEllipse(Brushes.Red, bird.GetRectangle());

            // Draw pipes
            foreach (Pipe pipe in pipes)
            {
                e.Graphics.FillRectangle(Brushes.Green, pipe.GetTopRectangle());
                e.Graphics.FillRectangle(Brushes.Green, pipe.GetBottomRectangle());
            }
        }
    }
}
