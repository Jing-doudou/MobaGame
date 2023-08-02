using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public void Init()
    {
        LogManager.Instance.DebugLog("SoundManager Init");
    }
    public void Destory()
    {

    }
  
}

