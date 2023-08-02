using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�������࣬����ģʽ
public class Singleton<T> where T : class, new()
{
    private static T m_Instance = null;

    public static T Instance
    {
        get
        {
            //���Ϊ��ʼ����Ϊ������һ���µĶ���
            if (m_Instance == null)
            {
                m_Instance = new T();
            }
            return m_Instance;
        }
    }
}
