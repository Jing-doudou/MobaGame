using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LogManager.Instance.Init();
        GameManager.Instance.Init();
        LuaManager.Instance.Init();
        NetWorkManager.Instance.Init();
        PatchManager.Instance.Init();
        ResourceManager.Instance.Init();
        SoundManager.Instance.Init();
        VideoManager.Instance.Init();
        
    }
    private void OnDestroy()
    {
        GameManager.Instance.Destory();
    }
    private void OnApplicationQuit()
    {
        
    }

}
