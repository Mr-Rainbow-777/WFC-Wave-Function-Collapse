using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Tilemaps;
public class TileObject
{
    Tile tile;

    public List<int> Up;
    public List<int> Down;
    public List<int> Right;
    public List<int> Left;

    //tile本身的每个方向的sockets
    public string[] edges = new string[4];
    StringBuilder stringhelper = new StringBuilder();
    public TileObject(string[] edges,Tile tile)
    {
        this.edges = edges;
        this.tile = tile;
        this.Up = new List<int>();
        this.Down = new List<int>();
        this.Right = new List<int>();
        this.Left = new List<int>();
    }


    /// <summary>
    /// 对所有的tiles进行方向分类
    /// </summary>
    /// <param name="tiles">所有的模块tile</param>
    public void Analyze(List<TileObject> tiles)
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            TileObject tile = tiles[i];

            //Up
            if (tile.edges[2] == ReserveString(this.edges[0]))
            {
                this.Up.Add(i);
            }
            //Down
            if (tile.edges[0] == ReserveString(this.edges[2]))
            {
                this.Down.Add(i);
            }
            //Right
            if (tile.edges[3] == ReserveString(this.edges[1]))
            {
                this.Right.Add(i);
            }
            //Left
            if (tile.edges[1] == ReserveString(this.edges[3]))
            {
                this.Left.Add(i);
            }
        }
    }


    public string ReserveString(string s)
    {
        stringhelper.Clear();
        char[] chars = s.ToCharArray();
        for (int i = chars.Length-1; i >=0 ; i--)
        {
            stringhelper.Append(chars[i]);
        }
        return stringhelper.ToString();
    }





}

