using UnityEngine;

public class PathNode
{
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    public Vector3Int coordinates;

    public int gCost = int.MaxValue;
    public int hCost = 0;
    public int fCost = 0;

    public PathNode comeFrom = null;

    public PathNode(Vector3Int coordinates)
    {
        this.coordinates = coordinates;
    }

    public void CalculateDistanceCost(Vector3Int destinationPosition)
    {
        int xDistance = Mathf.Abs(this.coordinates.x - destinationPosition.x);
        int yDistance = Mathf.Abs(this.coordinates.y - destinationPosition.y);
        int remaining = Mathf.Abs(xDistance - yDistance);

        this.hCost = MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST* remaining;
    }

    public void UpdatefCost()
    {
        fCost = hCost + gCost;
        if (fCost < 0)
        {
            fCost = int.MaxValue;
        }
    }

}
