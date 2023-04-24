namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Erstelle eine neue Instanz der GameForm
            GameForm gameForm = new GameForm();

            // Zeige die GameForm an
            gameForm.Show();
        }
    }
}