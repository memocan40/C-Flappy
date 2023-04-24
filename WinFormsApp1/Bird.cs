namespace WinFormsApp1
{

    public class Bird
    {
        private int size;
        private Point position;
        private int velocity;
        private int gravity;

        public Bird(int size, Point position)
        {
            this.size = size;
            this.position = position;
            this.velocity = 0;
            this.gravity = 2;
        }

        public int X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public void Update()
        {
            velocity += gravity;
            Y += velocity;
        }

        public void Flap()
        {
            velocity = -20;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(position.X, position.Y, size, size);
        }
    }


}
