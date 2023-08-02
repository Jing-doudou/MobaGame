using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void Init()
    {
        LogManager.Instance.DebugLog("GameManager Init");
    }
    public void Destory()
    {
        LogManager.Instance.DebugLog("GameManager Destory");
    }
 
}
