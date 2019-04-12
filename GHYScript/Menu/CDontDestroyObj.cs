using UnityEngine;
using System.Collections;

public class CDontDestroyObj : MonoBehaviour
{

    // Use this for initialization
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
