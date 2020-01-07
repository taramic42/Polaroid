using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Grid
{
    [System.Serializable]
    public struct rowData
    {
        public Tile[] tile;
    }

    public rowData[] row = new rowData[0];

	public Grid()
	{
	}

    public Grid(GameObject gameGrid)
    {
        Tile temp;

        int rowNum = gameGrid.transform.childCount;

        row = new rowData[rowNum];

        for (int i = 0; i < rowNum; i++)
        {
            //Setup size of row
            row[i].tile = new Tile[gameGrid.transform.GetChild(i).childCount];

            //Setup each tile in row
            for(int j = 0; j < row[i].tile.Length; j++)
            {
                temp = gameGrid.transform.GetChild(i).GetChild(j).GetComponent<Tile>();

                if (temp != null)
                {
                    row[i].tile[j] = gameGrid.transform.GetChild(i).GetChild(j).GetComponent<Tile>();
                }
            }
        }
    }
}
