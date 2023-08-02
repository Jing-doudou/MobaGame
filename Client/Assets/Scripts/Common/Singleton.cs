using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//单例基类，懒汉模式
public class Singleton<T> where T : class, new()
{
    private static T m_Instance = null;

    public static T Instance
    {
        get
        {
            //如果为初始化就为其生命一个新的对象
            if (m_Instance == null)
            {
                m_Instance = new T();
            }
            return m_Instance;
        }
    }
}
