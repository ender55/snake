public class GameField
{
    private int height;
    private int width;
    private Cell[,] field;

    public int Height => height;
    public int Width => width;

    public GameField(int height = 18, int width = 32)
    {
        this.height = height;
        this.width = width;
        field = new Cell[height, width];
    }
}