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
        m_Log.Debugf("����һ��debug��־");
        m_Log.Infof("����һ��Info��־");
        m_Log.Warnf("����һ��Warn��־");
        m_Log.Errorf("����һ��Error��־");

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

