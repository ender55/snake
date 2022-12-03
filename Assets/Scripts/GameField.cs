public class GameField
{
    private Cell[,] field;
    
    public Cell[,] Field { get; }

    public int Height { get; }
    public int Width { get; }

    public GameField(int height = 18, int width = 32)
    {
        Height = height;
        Width = width;
        field = new Cell[height, width];
    }
}