using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public List<int> options;
    public bool Collapsed;
    public bool Drawed=false;
    public Cell(int length, bool collapsed)
    {
        this.Collapsed = collapsed;
        if(options==null)
        {
            options = new List<int>();
        }
        for (int i = 0; i < length; i++)
        {
            options.Add(i);
        }
        
    }

    public Cell(List<int> options)
    {
         this.Collapsed = false;
         this.options =options;
    }

    public Cell()
    {
        this.Collapsed = false;
        this.options = null;
    }

}
