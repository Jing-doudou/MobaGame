using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogManager : Singleton<LogManager>
{
    private  LogSystem m_Log;
    public void Init()
    {
        m_Log = new LogSystem();
        Debug.Log("LogManager Init!");
        m_Log.OpenFile("");
        m_Log.SetLevel(1);
    }
    public void Destory()
    {

    }
    public void DebugLog(string str)
    {
        m_Log.Debugf("这是一个debug日志");
        m_Log.Infof("这是一个Info日志");
        m_Log.Warnf("这是一个Warn日志");
        m_Log.Errorf("这是一个Error日志");

    }
    public void WarnLog(string str)
    {
        Debug.Log(str);
    }
    public void ErrorLog(string str)
    {
        Debug.Log(str);
    }
}

