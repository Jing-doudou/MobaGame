using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaManager : Singleton<LuaManager>
{
    public void Init()
    {
        LogManager.Instance.DebugLog("LuaManager Init");
    }
    public void Destory()
    {
    }
}
