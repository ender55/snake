public class Cell
{
    private CellContent currentCellContent;

    public CellContent CurrentCellContent { get; set; }

    public enum CellContent
    {
        Snake,
        Food,
        Wall,
        Floor
    }
}