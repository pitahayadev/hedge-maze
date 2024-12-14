namespace Abstracts
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells { get; set; }
        
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[Width, Height];
            
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    // int index = (i * Width) + j;
                    // with walls: (i||j + 8 + i * Cell.WH)
                    int x = 8 + i * Cell.WIDTH;
                    int y = 8 + j * Cell.HEIGHT;
                    Cells[i, j] = Factory.Instantiate(x, y);
                }
            }
        }

        public Cell Get(int x, int y)
        {
            return Cells[x, y];
        }
    }
}