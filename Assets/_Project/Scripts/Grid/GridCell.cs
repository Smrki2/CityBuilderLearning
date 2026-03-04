using UnityEngine;

[System.Serializable]
public class GridCell 
{
    public Vector2Int cellPosition;
    public BuildingDataSO buildingType;
    public GameObject building;
    public bool isUsed;

    public GridCell() { }

    public GridCell(Vector2Int cellPosition)
    {
        this.cellPosition = cellPosition;
    }
}
