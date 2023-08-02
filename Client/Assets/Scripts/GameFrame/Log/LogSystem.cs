using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class LogSystem
{
    private enum LogLevel
    {
        Debug = 0, Info = 1, Warn = 2, Error = 3
    }
    //��Ϸ��־��ŵ�Ŀ¼
    private string m_FileLogPath = "";
    //��־�ļ�д����
    private FileStream m_LogFile = null;
    //�ļ�д����
    private BinaryWriter m_Writer = null;
    //��ǰ�ļ��Ĵ�С
    private int m_FileSize;
    //��ǰ�����Log�ȼ�
    private int m_logLevel = (int)LogLevel.Debug;
    /// <summary>
    /// ����־�ļ�
    /// </summary>
    /// <param name="filePath">�ļ�·��</param>
    /// <returns></returns>
    public bool OpenFile(string filePath)
    {
        m_FileLogPath = filePath;
        try
        {
            //�����־�ļ�·��Ϊ�գ������ƽ̨�����ļ�
            if (m_FileLogPath == "")
            {
                //�жϵ�ǰ��Ϸ���е�ƽ̨��ƻ��
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {

                }
                //�жϵ�ǰ��Ϸ���е�ƽ̨�ǰ�׿
                else if (Application.platform == RuntimePlatform.Android)
                {

                }
                //�жϵ�ǰ��Ϸ���е�ƽ̨��winds
                else if (Application.platform == RuntimePlatform.WindowsPlayer)
                {

                }
                //�жϵ�ǰ��Ϸ���е�ƽ̨�ǿ���ģʽ
                else if (Application.platform == RuntimePlatform.WindowsEditor ||
                    Application.platform == RuntimePlatform.OSXEditor)
                {
                    string path = Application.dataPath;
                    string name = string.Format("{0}_ClientLog.txt", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
                    //Substring �ӵ�һ��������ʼ���ƣ�����Ϊ�ڶ�������
                    path = path.Substring(0, path.IndexOf("Assets"));
                    m_FileLogPath = Path.Combine(path, name);
                }
            }
            //if�й����ļ�����ɾ��//��ȡ��ǰ�ļ����ڵ�Ŀ¼
            string strDir = Path.GetDirectoryName(m_FileLogPath);
            if (Directory.Exists(strDir))
            {
                //��ȡ��ǰ�ļ���������txt�ļ���׺���ʼ�
                string[] oldLogFiles = Directory.GetFiles(strDir, "*.txt");
                foreach (string fileName in oldLogFiles)
                {
                    //�����ļ�����
                    File.SetAttributes(fileName, FileAttributes.Normal);
                    //ɾ��
                    File.Delete(fileName);
                }
            }
            //FileAccess �ļ�����Ȩ�ޣ��ɶ���д��FileShare �ļ�����Ȩ�ޣ��ļ������ɾ�����ļ��ɶ�
            m_LogFile = new FileStream(m_FileLogPath, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete | FileShare.Read);
            m_Writer = new BinaryWriter(m_LogFile);
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log(e);
            return false;
        }
        return true;
    }
    /// <summary>
    /// �ر��ļ������д����
    /// </summary>
    public void CloseFile()
    {
        if (m_Writer != null)
        {
            m_Writer.Close();
            m_Writer = null;
        }
        if (m_LogFile != null)
        {
            m_LogFile.Close();
            m_LogFile.Dispose();
            m_LogFile = null;
        }
    }
    /// <summary>
    /// Log���
    /// </summary>
    /// <param name="msg">msg</param>
    private void PrintLog(string msg)
    {
        string timeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff");
        timeStr += " " + msg + "\n";
        m_Writer.Write(timeStr);
        //ˢ�µ���������
        m_Writer.Flush();

        m_FileSize += timeStr.Length;
        //�����ǰ���ļ�����1M�����½�һ���ļ�����д��
        if (m_FileSize >= 1024 * 1024 * 1024)
        {
            //�½�һ���ļ�
            NewLogFile();
        }
    }
    private void NewLogFile()
    {
        CloseFile();
        //�жϵ�ǰ��Ϸ���е�ƽ̨��ƻ��
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {

        }
        //�жϵ�ǰ��Ϸ���е�ƽ̨�ǰ�׿
        else if (Application.platform == RuntimePlatform.Android)
        {

        }
        //�жϵ�ǰ��Ϸ���е�ƽ̨��winds
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {

        }
        //�жϵ�ǰ��Ϸ���е�ƽ̨�ǿ���ģʽ
        else if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.OSXEditor)
        {
            string path = Application.dataPath;
            path = path.Substring(0, path.IndexOf("Assets"));
            m_FileLogPath = Path.Combine(path, string.Format("{0}_ClientLog.txt", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")));
        }

        m_LogFile = new FileStream(m_FileLogPath, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete | FileShare.Read);
        m_Writer = new BinaryWriter(m_LogFile);
    }
    public void Debugf(string format)
    {
        if (m_logLevel > (int)LogLevel.Debug)
        {
            return;
        }
        string strDebug = "[debug]\t";
        strDebug += format;
        PrintLog(strDebug);
    }
    public void Infof(string format)
    {
        if (m_logLevel > (int)LogLevel.Info)
        {
            return;
        }
        string strInfo = "[Info]\t";
        strInfo += format;
        PrintLog(strInfo);
    }
    public void Warnf(string format)
    {
        if (m_logLevel > (int)LogLevel.Warn)
        {
            return;
        }
        string strWarn = "[Warn]\t";
        strWarn += format;
        PrintLog(strWarn);
    }
    public void Errorf(string format)
    {
        if (m_logLevel > (int)LogLevel.Error)
        {
            return;
        }
        string strError = "[Error]\t";
        strError += format;
        PrintLog(strError);
    }
    public void SetLevel(int level)
    {
        m_logLevel = level;
    }
}
