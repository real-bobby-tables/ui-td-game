using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathgenerator : MonoBehaviour
{
    [SerializeField] private int size = 20;
    [SerializeField] private GameObject waypointPrefab;
    [SerializeField] private GameObject towerLocationPrefab;
    [SerializeField] private GameObject towerLocationButtonPrefab;
    [SerializeField] private Transform mapCanvastransform;
    private int[,] grid;// 0-empty, 1-path, 2-tower
    public static List<GameObject> path;

    // Start is called before the first frame update
    void Awake()
    {
        grid = new int[size, size];
        path = new List<GameObject>();
        createGrid();
        createTowerLocations();
    }
    private void createGrid() 
    {
        int nextMove, prevMove = -1;
        int x = 0, z = UnityEngine.Random.Range(0,size);
        while (x < size-1)
        {
            //0-up, 1-down, 2-right
            nextMove = UnityEngine.Random.Range(0, 3);
            while((nextMove == 0 && prevMove == 1) || (nextMove == 1 && prevMove == 0))
                    nextMove = UnityEngine.Random.Range(0, 3);
            prevMove = nextMove;
            switch (nextMove)
            {
                case 0:
                    if (z < size - 1)
                        z++;
                    else 
                    {
                        x++;
                        prevMove = 2;
                    }
                    break;
                case 1:
                    if(z>0)
                        z--;
                    else
                    {
                        x++;
                        prevMove = 2;
                    }
                    break;
                case 2:
                    x++;
                    break;
            }
            FillGridWithPath(x, z);
        }
    }

    void FillGridWithPath(int x, int z) 
    {
        grid[x, z] = 1;
        path.Add(Instantiate(waypointPrefab, new Vector3(x, FindTerrainHeight(x, z), z), Quaternion.identity, transform));
        path[path.Count - 1].name = (path.Count - 1).ToString();
    }
    private void createTowerLocations() 
    {
        for (int x = 0; x < size; x++) 
        {
            for (int z = 0; z < size; z++) 
            {
                if (grid[x,z] == 0 && CanPlaceTower(x,z)) 
                {
                    grid[x, z] = 2;
                    Instantiate(towerLocationPrefab, new Vector3(x, FindTerrainHeight(x,z), z), Quaternion.identity, mapCanvastransform);
                    Instantiate(towerLocationButtonPrefab, new Vector3(x, FindTerrainHeight(x,z), z), Quaternion.Euler(90,0,0), mapCanvastransform);
                }
            }
        }
    }

    float FindTerrainHeight(int x, int z)
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(x, 0, z), Vector3.down, out hit))
            return hit.point.y + 1.0f;
        else return 0;
    }

    private bool CanPlaceTower(int x, int z) 
    {
        for (int i = -1; i <= 1; i++) 
        {
            for (int j = -1; j <= 1; j++)
            {
                int a = x + i;
                int b = z + j;
                if (a >= 0 && a < size && b >= 0 && b < size && grid[a, b] == 1)
                    return true;
            }
        }
        return false;
    }
}
