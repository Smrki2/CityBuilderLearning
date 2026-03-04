using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GridCell[,] grid;
    [SerializeField] public Vector2Int gridSize;

    public GridCell GetCell(Vector2Int cellPosition)
    {
        return grid[cellPosition.x, cellPosition.y];
    }

    public bool GetCellState(Vector2Int cellPosition)
    {
        return grid[cellPosition.x, cellPosition.y].isUsed;
    }

    public void GridInitialization()
    {
        if (grid == null)
        {
            grid = new GridCell[gridSize.x, gridSize.y];
            for (int i = 0; i < gridSize.x; i++)
            {
                for(int j=0;  j<gridSize.y; j++)
                {
                    grid[i, j] = new GridCell(new Vector2Int(i,j));
                }
            }
        }
    }

    public void Awake()
    {
        GridInitialization();
    }
}
