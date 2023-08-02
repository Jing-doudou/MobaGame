using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchManager : Singleton<PatchManager>
{
    public void Init()
    {
        LogManager.Instance.DebugLog("PatchManager Init");
    }
    public void Destory()
    {

    } 
}
