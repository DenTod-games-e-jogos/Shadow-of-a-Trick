using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pathfinding : MonoBehaviour
{
    [Tooltip("GameObject do tipo grid para a movimenta��o do aline.")]
    
    [SerializeField] 
    Grid grid;
    
    [Tooltip("GameObject do tipo Tilemap que correspondente as paredes impedindo a movimenta��o do Alien.")]
    
    [SerializeField] 
    Tilemap tilemap;
    
    Vector3Int alienCell;
    
    Vector3Int min;
    
    Vector3Int max;
    
    [Tooltip("GameObject do que tenha um  para que o Alien possa seguir.")]
    
    [SerializeField] 
    GameObject player;
    
    Vector3Int actualPlayerPosition;
    
    Vector3Int lastPlayerPosition;
    
    int[,] mapCosts;
    
    List<PathNode> route;
    
    [SerializeField] 
    Vector3 nextDestinaton;

    void Start()
    {
        min = new Vector3Int(tilemap.cellBounds.xMin, tilemap.cellBounds.yMin, tilemap.cellBounds.zMin);
        
        max = new Vector3Int(tilemap.cellBounds.xMax, tilemap.cellBounds.yMax, tilemap.cellBounds.zMax);
        
        lastPlayerPosition = new Vector3Int(int.MaxValue, int.MaxValue);
        
        alienCell = grid.WorldToCell(transform.position);
        
        player = GameObject.FindGameObjectWithTag("Player");

        mapCosts = new int[max.x - min.x, max.y - min.y];
        
        for (int i = 0; i < max.x - min.x; i++)
        {
            for(int j = 0; j < max.y - min.y; j++)
            {
                if (tilemap.GetTile(new Vector3Int(i + min.x, j + min.y, 0)) == null)
                {
                    mapCosts[i, j] = 0;
                }
                    
                else
                {
                    mapCosts[i, j] = 1;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            return;
        }

        actualPlayerPosition = grid.LocalToCell(player.transform.localPosition);
        
        alienCell = grid.LocalToCell(transform.localPosition);

        if (actualPlayerPosition != lastPlayerPosition)
        {
            lastPlayerPosition = actualPlayerPosition;
            
            route = null;
            
            route = CalculateRoute(actualPlayerPosition, alienCell, min);
        }
    }

    List<PathNode> CalculateRoute(Vector3Int endPos, Vector3Int startPos, Vector3Int offset)
    {
        PathNode[,] mapPaths;
        
        PathNode startNode = new PathNode(startPos-offset);
        
        startNode.CalculateDistanceCost(endPos - offset);
        
        startNode.gCost = 0;
        
        startNode.UpdatefCost();

        List<PathNode> openList = new List<PathNode> { startNode };
        
        List<PathNode> closedList = new List<PathNode>();

        mapPaths = new PathNode[Mathf.Abs(max.x - min.x), Mathf.Abs(max.y - min.y)];
        
        for (int i = 0; i < Mathf.Abs(max.x - min.x); i++)
        {
            for (int j = 0; j < Mathf.Abs(max.y - min.y); j++)
            {
                Vector3Int pos = new Vector3Int(i, j);
                
                if (pos != startPos - offset)
                {
                    if (mapCosts[i, j] == 0)
                    {
                        mapPaths[i, j] = new PathNode(pos);
                        
                        mapPaths[i, j].CalculateDistanceCost(endPos - offset);
                        
                        mapPaths[i, j].gCost = int.MaxValue;
                        
                        mapPaths[i, j].UpdatefCost();
                        
                        openList.Add(mapPaths[i, j]);
                    }
                } 
            }
        }
            
        mapPaths[startNode.coordinates.x, startNode.coordinates.y] = startNode;
        
        while(openList.Count > 0)
        {
            PathNode currentNode = GetLowestfCostNode(openList);
            
            if (currentNode.coordinates == (endPos - offset))
            {
                return CalculatedPath(currentNode);
            }
            
            openList.Remove(currentNode);
            
            closedList.Add(currentNode);

            foreach (PathNode neigbourNode in GetNeighbourList(currentNode, mapPaths))
            {
                if (closedList.Contains(neigbourNode))
                {
                    continue;
                }

                int actualgCost = currentNode.hCost;
                
                currentNode.CalculateDistanceCost(neigbourNode.coordinates);
                
                if ((currentNode.gCost + actualgCost) < neigbourNode.gCost)
                {
                    neigbourNode.comeFrom = currentNode;
                    
                    neigbourNode.gCost = currentNode.gCost + actualgCost;
                    
                    neigbourNode.CalculateDistanceCost(endPos - offset);
                    
                    neigbourNode.UpdatefCost();

                    if (!openList.Contains(neigbourNode))
                    {
                        openList.Add(neigbourNode);
                    }
                } 
                
                else
                {
                    currentNode.hCost = actualgCost;
                }
            }
        }

        return null;
    }

    List<PathNode> GetNeighbourList(PathNode currentNode, PathNode[,] mapPaths)
    {
        List<PathNode> neighbourList = new List<PathNode>();
        
        if (currentNode.coordinates.x - 1 >= 0)
        {
            if (mapPaths[currentNode.coordinates.x - 1, currentNode.coordinates.y] != null)
            {
                neighbourList.Add(mapPaths[currentNode.coordinates.x - 1, 
                currentNode.coordinates.y]);
            }
                
            if (currentNode.coordinates.y - 1 >= 0)
            {
                if (mapPaths[currentNode.coordinates.x - 1, currentNode.coordinates.y - 1] != null)
                {
                    neighbourList.Add(mapPaths[currentNode.coordinates.x - 1, 
                    currentNode.coordinates.y - 1]);
                }
            }
                
            if (currentNode.coordinates.y + 1 < (max.y - min.y))
            {
                if (mapPaths[currentNode.coordinates.x - 1, currentNode.coordinates.y + 1] != null)
                {
                    neighbourList.Add(mapPaths[currentNode.coordinates.x - 1, 
                    currentNode.coordinates.y + 1]);
                }
            }
        }
        
        if (currentNode.coordinates.x + 1 < (max.y - min.y))
        {
            if (mapPaths[currentNode.coordinates.x + 1, currentNode.coordinates.y] != null)
            {
                neighbourList.Add(mapPaths[currentNode.coordinates.x + 1, 
                currentNode.coordinates.y]);
            }
                
            if (currentNode.coordinates.y - 1 >= 0)
            {
                if (mapPaths[currentNode.coordinates.x + 1, currentNode.coordinates.y - 1] != null)
                {
                    neighbourList.Add(mapPaths[currentNode.coordinates.x + 1, 
                    currentNode.coordinates.y - 1]);
                }
            }
                
            if (currentNode.coordinates.y + 1 < (max.y - min.y))
            {
                if (mapPaths[currentNode.coordinates.x + 1, currentNode.coordinates.y + 1] != null)
                {
                    neighbourList.Add(mapPaths[currentNode.coordinates.x + 1, 
                    currentNode.coordinates.y + 1]);
                }
            }
        }
        
        if (currentNode.coordinates.y - 1 >= 0)
        {
            if (mapPaths[currentNode.coordinates.x, currentNode.coordinates.y - 1] != null)
            {
                neighbourList.Add(mapPaths[currentNode.coordinates.x, 
                currentNode.coordinates.y - 1]);
            }
        }
            
        if (currentNode.coordinates.y + 1 < (max.y - min.y))
        {
            if (mapPaths[currentNode.coordinates.x, currentNode.coordinates.y + 1] != null)
            {
                neighbourList.Add(mapPaths[currentNode.coordinates.x, 
                currentNode.coordinates.y + 1]);
            }
        }
            
        return neighbourList;
    }
    
    List<PathNode> CalculatedPath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        
        path.Add(endNode);
        
        PathNode currentNode = endNode;
        
        while (currentNode.comeFrom != null)
        {
            path.Add(currentNode.comeFrom);
            
            currentNode = currentNode.comeFrom;
        }

        path.Reverse();

        return path;
    }

    PathNode GetLowestfCostNode(List<PathNode> pathNodesList)
    {
        PathNode lowestCostNode = pathNodesList[0];
        
        for (int i =1; i < pathNodesList.Count; i++)
        {
            if(pathNodesList[i].fCost < lowestCostNode.fCost)
            {
                lowestCostNode = pathNodesList[i];
            }
        }

        return lowestCostNode;
    }

    public Vector3 GetDestination()
    {
        if (route == null)
        {
            nextDestinaton = grid.CellToWorld(alienCell);
            
            return nextDestinaton;
        }

        if (route.Count > 1)
        {
            route.RemoveAt(0);
            
            nextDestinaton = grid.CellToWorld(route[0].coordinates + min);

            return nextDestinaton;
        }

        else
        {
            nextDestinaton = grid.CellToWorld(actualPlayerPosition);
            
            return nextDestinaton;
        }
    }

    public Vector3 CheckDestination()
    {
        if (route == null || route.Count < 1)
        {
            return grid.CellToWorld(alienCell);
        }

        if (route != null || route.Count > 0)
        {
            return grid.CellToWorld(route[0].coordinates + min);
        }

        else
        {
            return grid.CellToWorld(alienCell);
        }
    }
}