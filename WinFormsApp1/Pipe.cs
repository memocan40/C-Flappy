namespace WinFormsApp1
{
    public class Pipe
    {
        private int x;
        private int holePosition;
        private int holeSize;
        private int speed;
        private bool isScored;

        public int X { get { return x; } }
        public int Width { get { return 50; } }
        public bool IsScored { get { return isScored; } set { isScored = value; } }

        public Pipe(int x, int holePosition, int holeSize, int speed = 5)
        {
            this.x = x;
            this.holePosition = holePosition;
            this.holeSize = holeSize;
            this.speed = speed;
            isScored = false;
        }

        public void Move()
        {
            x -= speed;
        }

        public Rectangle GetTopRectangle()
        {
            return new Rectangle(x, 0, Width, holePosition);
        }

        public Rectangle GetBottomRectangle()
        {
            int bottomHeight = holePosition + holeSize;
            return new Rectangle(x, bottomHeight, Width, GameForm.ActiveForm.ClientSize.Height - bottomHeight);
        }

        public bool IsOffScreen()
        {
            return x + Width < 0;
        }

        public bool Intersects(Rectangle rect)
        {
            return rect.IntersectsWith(GetTopRectangle()) || rect.IntersectsWith(GetBottomRectangle());
        }

        public int GetScore()
        {
            if (isScored)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }


}
