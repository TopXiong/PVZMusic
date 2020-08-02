using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class Marigold : MonoBehaviour,BasePlayObject
{

    public Vector2Int point;
    public int tone;

    /// <summary>
    /// 播放时调用
    /// </summary>
    public void OnPlay()
    {
        GameObject sun = Instantiate(Resources.Load("Prefabs/CoinSilver", typeof(GameObject)) as GameObject);
        sun.transform.position = transform.position;
        //修改尺寸
        sun.transform.SetParent(transform);
        sun.transform.localScale = SpriteAdapter.Instance.baseVector;
        sun.GetComponent<Sun>().point = point;
        sun.GetComponent<Sun>().tone = tone;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
