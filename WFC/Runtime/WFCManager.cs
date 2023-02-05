using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class WFCManager : MonoBehaviour
{
    Tilemap map;
    public int resolution = 8;


    private List<TileObject> AllTilesObjects = new List<TileObject>();
    public List<Tile> AllTiles = new List<Tile>();
    private List<Cell> Grids = new List<Cell>();
    private bool Fail = false;
    private bool Success = false;
    private void Awake()
    {
        map = GetComponent<Tilemap>();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Success) { return; }
        WFCLogic();
    }



    private void OnGUI()
    {
        if(GUILayout.Button("Generate",GUILayout.MinWidth(200),GUILayout.MinHeight(100)))
        {
            StartOver();
            Success = false;
        }
    }


    public void Init()
    {
            //顺时针编号排布  Up  Right  Down  Left
            //----------------------进行socket编排分类-------------------------//
            AllTilesObjects.Add(new TileObject(new string[] { "AAA","ABB","BBA","AAA" }, AllTiles[0]));
            AllTilesObjects.Add(new TileObject(new string[] { "AAA", "ABB", "BBB", "BBA" }, AllTiles[1]));
            AllTilesObjects.Add(new TileObject(new string[] { "AAA", "AAA", "ABB", "BBA" }, AllTiles[2]));
            AllTilesObjects.Add(new TileObject(new string[] { "ABB", "BBB", "BBA", "AAA" }, AllTiles[3]));
            AllTilesObjects.Add(new TileObject(new string[] { "BBB", "BBB", "BBB", "BBB" }, AllTiles[4]));
            AllTilesObjects.Add(new TileObject(new string[] { "BBA", "AAA", "ABB", "BBB" }, AllTiles[5]));
            AllTilesObjects.Add(new TileObject(new string[] { "ABB", "BBA", "AAA", "AAA" }, AllTiles[6]));
            AllTilesObjects.Add(new TileObject(new string[] { "BBB", "BBA", "AAA", "ABB" }, AllTiles[7]));
            AllTilesObjects.Add(new TileObject(new string[] { "BBA", "AAA", "AAA", "ABB" }, AllTiles[8]));


        // Generate the adjacency rules based on edges
        for (int i = 0; i < AllTiles.Count; i++)
        {
            var tile = AllTilesObjects[i];
            tile.Analyze(AllTilesObjects);
        }

        StartOver();

    }


    public void StartOver()
    {
        
        Grids.Clear();
        for (int i = 0; i < resolution*resolution; i++)
        {
            Grids.Add(new Cell(AllTilesObjects.Count, false));
        }
        map.ClearAllTiles();
    }

    public void WFCLogic()
    {
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                Cell grid = Grids[i + j * resolution];
                //判断是否collapse
                if (grid.Collapsed&&!grid.Drawed)
                {
                    if(grid.options.Count==0)
                    {
                        //Debug.LogError($"({i},{j})");
                        Debug.Log("fail!");
                        StartOver();
                        Fail = true;
                        return;
                    }
                    //如果collapse  则执行绘图指令
                    int index = grid.options[0];
                    map.SetTile(new Vector3Int(i, j), AllTiles[index]);
                    grid.Drawed = true;
                    Debug.Log($"({i},{j})");
                }
            }
        }

        //找到包含最小信息量的grid
        var gridCopy = new List<Cell>(Grids);
        gridCopy.RemoveAll(cell => cell.Collapsed);

        if (gridCopy.Count == 0)
        {
            Debug.Log("success!");
            Success = true;
            return;
        }
        //进行最小信息量排序
        gridCopy.Sort((a, b) =>
        {
            return a.options.Count - b.options.Count;
        });

        //最小信息量数目
        var len = gridCopy[0].options.Count;
        int stopindex = 0;
        for (int i = 0; i < gridCopy.Count; i++)
        {
            if (gridCopy[i].options.Count > len)
            {
                stopindex = i;
                break;
            }
        }

        if (stopindex > 0)
        {
            gridCopy = gridCopy.GetRange(0, stopindex + 1);
        }

        //进行随机选取Grid和Options
        int randomGridIndex = Random.Range(0, gridCopy.Count);
        Cell curCell = gridCopy[randomGridIndex];
        curCell.Collapsed = true;
        if (curCell.options.Count == 0)
        {
            StartOver();
            return;
        }
        //Warning!!!
        int randomOptionIndex = Random.Range(0, curCell.options.Count);
        int optionNum = curCell.options[randomOptionIndex];
        curCell.options = new List<int>()
        {
            optionNum,
        };

        List<Cell> nextGrids = new List<Cell>(resolution * resolution);
        for (int i = 0; i < resolution*resolution; i++)
        {
            nextGrids.Add(new Cell());
        }

        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                int index = i + j * resolution;
                if (Grids[index].Collapsed)
                {
                    nextGrids[index] = Grids[index];
                }
                else
                {
                    List<int> options = new List<int>
                    {
                        0,1,2,3,4,5,6,7,8,
                    };
                    //Up Test
                    if(j < resolution - 1)
                    {
                        Cell target = Grids[i + (j + 1) * resolution];
                        List<int> validOptions = new List<int>();
                        foreach (var option in target.options)
                        {
                            var valid = AllTilesObjects[option].Down;
                            validOptions.AddRange(valid);
                        }
                        CheckValid(options, validOptions);
                    }
                    //Down Test
                    if (j > 0)
                    {
                        Cell target = Grids[i + (j - 1) * resolution];
                        List<int> validOptions = new List<int>();
                        foreach (var option in target.options)
                        {
                            var valid = AllTilesObjects[option].Up;
                            validOptions.AddRange(valid);
                        }
                        CheckValid(options, validOptions);
                    }
                    //Right Test
                    if (i < resolution - 1)
                    {
                        Cell target = Grids[i + 1 + j * resolution];
                        List<int> validOptions = new List<int>();
                        foreach (var option in target.options)
                        {
                            var valid = AllTilesObjects[option].Left;
                            validOptions.AddRange(valid);
                        }
                        CheckValid(options, validOptions);
                    }
                    //Left Test
                    if (i > 0)
                    {
                        Cell target = Grids[i - 1 + j * resolution];
                        List<int> validOptions = new List<int>();
                        foreach (var option in target.options)
                        {
                            var valid = AllTilesObjects[option].Right;
                            validOptions.AddRange(valid);
                        }
                        CheckValid(options, validOptions);
                    }
                    nextGrids[index] = new Cell(options);
                }
            }

        }
        Grids = nextGrids;

    }


    private void CheckValid(List<int> Options,List<int> validOptions)
    {
        //options : Up Down Left Right
        // ValidOptions : Up Left 


        for (int i = Options.Count-1; i >=0; i--)
        {
            var element = Options[i];

            if(!validOptions.Contains(element))
            {
                Options.Remove(element);
            }
        }
    }




}



