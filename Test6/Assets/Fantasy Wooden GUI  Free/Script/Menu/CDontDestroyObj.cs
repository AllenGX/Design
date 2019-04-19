using UnityEngine;
using System.Collections;

//挂上这个脚本的对象将变成全局单例不会被销毁的对象，挂上后，子节点也不会被销毁，但这个脚本只能挂在一个物体上不能反复利用，
//不推荐用这个来实现全局变量，还是扔到CMenuObject类里比较好
public class CDontDestroyObj : MonoBehaviour
{

    // Use this for initialization
    //取到这个对象的引用
    public static CDontDestroyObj dd;
    private void Awake()
    {
        if (dd == null)
        {
            DontDestroyOnLoad(gameObject);
            dd = this;
        }
        else if (dd != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
