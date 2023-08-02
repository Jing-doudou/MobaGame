using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : Singleton<VideoManager>
{
    public void Init()
    {
        LogManager.Instance.DebugLog("VideoManager Init");
    }
    public void Destory()
    {

    }
 
}
