using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Tile up;
    public Tile down;
    public Tile left;
    public Tile right;

    GameObject objOnTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectAdjacencies(Tile north, Tile south, Tile west, Tile east)
    {
        up = north;
        down = south;
        left = west;
        right = east;
    }

    public void MoveOn(GameObject obj)
    {
        objOnTile = obj;
    }

    public void MoveOff()
    {
        objOnTile = null;
    }
}
