using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] bool useAutomaticMapping;

    [SerializeField] Grid grid;
    [SerializeField] GameObject gridObject;
    [SerializeField] Player playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        if(useAutomaticMapping)
            GameObjectMapping();
        else
            BasicMapping();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameObjectMapping()
    {
        grid = new Grid(gridObject);
        BasicMapping();
    }

    private void BasicMapping()
    {
        Tile up;
        Tile down;
        Tile left;
        Tile right;

        for (int row = 0; row < grid.row.Length; row++)
        {
            for (int column = 0; column < grid.row[row].tile.Length; column++)
            {
                if (grid.row[row].tile[column] != null)
                {
                    up = null;
                    down = null;
                    left = null;
                    right = null;

                    if (row > 0)
                    {
                        up = grid.row[row - 1].tile[column];
                    }

                    if (row < grid.row.Length - 1)
                    {
                        down = grid.row[row + 1].tile[column];
                    }

                    if (column > 0)
                    {
                        left = grid.row[row].tile[column - 1];
                    }

                    if (column < grid.row[row].tile.Length - 1)
                    {
                        right = grid.row[row].tile[column + 1];
                    }

                    grid.row[row].tile[column].ConnectAdjacencies(up, down, left, right);
                }
            }
        }
    }

}
