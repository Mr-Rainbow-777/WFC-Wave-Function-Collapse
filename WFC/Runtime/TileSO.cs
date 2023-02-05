using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
[CreateAssetMenu(menuName ="WFC/TileSetting",fileName ="TileSeeting")]
public class TileSO : ScriptableObject
{
    public Tile tile;
    [Tooltip("Ԥ���õ�Tile")]
    public TileSO targetTile;
    [Tooltip("tile�ĸ���id")]
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
    ///  ��Ӷ�Ӧ�����ϵ�tile
    /// </summary>
    /// <param name="guid">guid</param>
    /// <param name="dir">����</param>
    //public void AddComponentPerDir(string guid,Dir dir)
    //{
    //    switch (dir)
    //    {
    //        case Dir.Up:
    //            if (!_DirComponentsArray[0].lists.Contains(guid))
    //            {
    //                Debug.Log("��ӳɹ�");
    //                _DirComponentsArray[0].lists.Add(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("�Ѿ����ڴ�Grid�޷���ӣ�");
    //            }
    //            break;
    //        case Dir.Right:
    //            if (!_DirComponentsArray[1].lists.Contains(guid))
    //            {
    //                Debug.Log("��ӳɹ�");
    //                _DirComponentsArray[1].lists.Add(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("�Ѿ����ڴ�Grid�޷���ӣ�");
    //            }
    //            break;
    //        case Dir.Down:
    //            if (!_DirComponentsArray[2].lists.Contains(guid))
    //            {
    //                Debug.Log("��ӳɹ�");
    //                _DirComponentsArray[2].lists.Add(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("�Ѿ����ڴ�Grid�޷���ӣ�");

    //            }
    //            break;
    //        case Dir.Left:
    //            if (!_DirComponentsArray[3].lists.Contains(guid))
    //            {
    //                Debug.Log("��ӳɹ�");
    //                _DirComponentsArray[3].lists.Add(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("�Ѿ����ڴ�Grid�޷���ӣ�");
    //            }
    //            break;
    //        default:
    //            break;
    //    }
    //}

    /// <summary>
    /// ɾ����Ӧ���������tile
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
    //                Debug.Log("ɾ���ɹ�");
    //                _DirComponentsArray[0].lists.Remove(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("�����ڴ�Grid�޷�ɾ��");
    //            }
    //            break;
    //        case Dir.Right:
    //            if (_DirComponentsArray[1].lists.Contains(guid))
    //            {
    //                Debug.Log("ɾ���ɹ�");
    //                _DirComponentsArray[1].lists.Remove(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("�����ڴ�Grid�޷�ɾ��");
    //            }
    //            break;
    //        case Dir.Down:
    //            if (_DirComponentsArray[2].lists.Contains(guid))
    //            {
    //                Debug.Log("ɾ���ɹ�");
    //                _DirComponentsArray[2].lists.Remove(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("�����ڴ�Grid�޷�ɾ����");
    //            }
    //            break;
    //        case Dir.Left:
    //            if (_DirComponentsArray[3].lists.Contains(guid))
    //            {
    //                Debug.Log("ɾ���ɹ�");
    //                _DirComponentsArray[3].lists.Remove(guid);
    //            }
    //            else
    //            {
    //                Debug.LogError("�����ڴ�Grid�޷�ɾ����");
    //            }
    //            break;
    //        default:
    //            break;
    //    }
    //}

}
