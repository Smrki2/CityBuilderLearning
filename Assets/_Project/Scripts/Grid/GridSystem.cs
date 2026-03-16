using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static GridSystem instance;
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
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        GridInitialization();
    }

    private void OnDrawGizmos()
    {
        for(int i =0; i < gridSize.x; i++)
        {
            Gizmos.DrawLine(new Vector3(0, 0, i), new Vector3(gridSize.x, 0, i));
            Gizmos.DrawLine(new Vector3(i, 0, 0), new Vector3(i, 0, gridSize.y));
        }
    }
}
