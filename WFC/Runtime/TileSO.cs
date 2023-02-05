using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
[CreateAssetMenu(menuName ="WFC/TileSetting",fileName ="TileSeeting")]
public class TileSO : ScriptableObject
{
    public Tile tile;
    [Tooltip("预放置的Tile")]
    public TileSO targetTile;
    [Tooltip("tile的个人id")]
    private string guid = System.Guid.NewGuid().ToString();
    public Texture2D preview;
    public string GUID
    {
        get => guid;
    }

    [Serializable]
    public struct DirList
    {
        public List<TileSO> lists;
    }

    public DirList[] _DirComponentsArray = new DirList[4]
    {
        new DirList(),
        new DirList(),
        new DirList(),
        new DirList(),
    };



    /// <summary>
    ///  添加对应方向上的tile
    /// </summary>
    /// <param name="guid">guid</param>
    /// <param name="dir">方向</param>
    //public void AddComponentPerDir(string guid,Dir dir)
    //{
    //    switch (dir)
    //    {
    //        case Dir.Up:
    //            if (!_DirComponentsArray[0].lists.Contains(guid))
    //            {
    //                Debug.Log("添加成功");
    //                _DirComponentsArray[0].lists.Add(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("已经存在此Grid无法添加！");
    //            }
    //            break;
    //        case Dir.Right:
    //            if (!_DirComponentsArray[1].lists.Contains(guid))
    //            {
    //                Debug.Log("添加成功");
    //                _DirComponentsArray[1].lists.Add(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("已经存在此Grid无法添加！");
    //            }
    //            break;
    //        case Dir.Down:
    //            if (!_DirComponentsArray[2].lists.Contains(guid))
    //            {
    //                Debug.Log("添加成功");
    //                _DirComponentsArray[2].lists.Add(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("已经存在此Grid无法添加！");

    //            }
    //            break;
    //        case Dir.Left:
    //            if (!_DirComponentsArray[3].lists.Contains(guid))
    //            {
    //                Debug.Log("添加成功");
    //                _DirComponentsArray[3].lists.Add(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("已经存在此Grid无法添加！");
    //            }
    //            break;
    //        default:
    //            break;
    //    }
    //}

    /// <summary>
    /// 删除相应方向的限制tile
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="dir"></param>
    //public void DeleteComponentPerDir(string guid, Dir dir)
    //{
    //    switch (dir)
    //    {
    //        case Dir.Up:
    //            if(_DirComponentsArray[0].lists.Contains(guid))
    //            {
    //                Debug.Log("删除成功");
    //                _DirComponentsArray[0].lists.Remove(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("不存在此Grid无法删除");
    //            }
    //            break;
    //        case Dir.Right:
    //            if (_DirComponentsArray[1].lists.Contains(guid))
    //            {
    //                Debug.Log("删除成功");
    //                _DirComponentsArray[1].lists.Remove(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("不存在此Grid无法删除");
    //            }
    //            break;
    //        case Dir.Down:
    //            if (_DirComponentsArray[2].lists.Contains(guid))
    //            {
    //                Debug.Log("删除成功");
    //                _DirComponentsArray[2].lists.Remove(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("不存在此Grid无法删除！");
    //            }
    //            break;
    //        case Dir.Left:
    //            if (_DirComponentsArray[3].lists.Contains(guid))
    //            {
    //                Debug.Log("删除成功");
    //                _DirComponentsArray[3].lists.Remove(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("不存在此Grid无法删除！");
    //            }
    //            break;
    //        default:
    //            break;
    //    }
    //}

}
