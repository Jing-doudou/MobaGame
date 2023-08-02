using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkManager : Singleton<NetWorkManager>
{
    public void Init()
    {
        LogManager.Instance.DebugLog("NetWorkManager Init");
    }
    public void Destory()
    {

    }
 
}

