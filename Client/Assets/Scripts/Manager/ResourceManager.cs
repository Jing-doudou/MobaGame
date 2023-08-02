using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    public void Init()
    {
        LogManager.Instance.DebugLog("ResourceManager Init");
    }
    public void Destory()
    {

    }  
}

