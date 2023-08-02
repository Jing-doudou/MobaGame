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
    //游戏日志存放的目录
    private string m_FileLogPath = "";
    //日志文件写入流
    private FileStream m_LogFile = null;
    //文件写入器
    private BinaryWriter m_Writer = null;
    //当前文件的大小
    private int m_FileSize;
    //当前输出的Log等级
    private int m_logLevel = (int)LogLevel.Debug;
    /// <summary>
    /// 打开日志文件
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns></returns>
    public bool OpenFile(string filePath)
    {
        m_FileLogPath = filePath;
        try
        {
            //如果日志文件路径为空，则根据平台创建文件
            if (m_FileLogPath == "")
            {
                //判断当前游戏运行的平台是苹果
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {

                }
                //判断当前游戏运行的平台是安卓
                else if (Application.platform == RuntimePlatform.Android)
                {

                }
                //判断当前游戏运行的平台是winds
                else if (Application.platform == RuntimePlatform.WindowsPlayer)
                {

                }
                //判断当前游戏运行的平台是开发模式
                else if (Application.platform == RuntimePlatform.WindowsEditor ||
                    Application.platform == RuntimePlatform.OSXEditor)
                {
                    string path = Application.dataPath;
                    string name = string.Format("{0}_ClientLog.txt", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
                    //Substring 从第一个参数开始复制，长度为第二个参数
                    path = path.Substring(0, path.IndexOf("Assets"));
                    m_FileLogPath = Path.Combine(path, name);
                }
            }
            //if有过期文件，则删除//获取当前文件所在的目录
            string strDir = Path.GetDirectoryName(m_FileLogPath);
            if (Directory.Exists(strDir))
            {
                //获取当前文件下面所有txt文件后缀的问价
                string[] oldLogFiles = Directory.GetFiles(strDir, "*.txt");
                foreach (string fileName in oldLogFiles)
                {
                    //设置文件属性
                    File.SetAttributes(fileName, FileAttributes.Normal);
                    //删除
                    File.Delete(fileName);
                }
            }
            //FileAccess 文件访问权限，可读可写；FileShare 文件共享权限，文件可随后删除，文件可读
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
    /// 关闭文件句柄，写入流
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
    /// Log输出
    /// </summary>
    /// <param name="msg">msg</param>
    private void PrintLog(string msg)
    {
        string timeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff");
        timeStr += " " + msg + "\n";
        m_Writer.Write(timeStr);
        //刷新到缓冲区中
        m_Writer.Flush();

        m_FileSize += timeStr.Length;
        //如果当前的文件大于1M，则新建一个文件继续写入
        if (m_FileSize >= 1024 * 1024 * 1024)
        {
            //新建一个文件
            NewLogFile();
        }
    }
    private void NewLogFile()
    {
        CloseFile();
        //判断当前游戏运行的平台是苹果
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {

        }
        //判断当前游戏运行的平台是安卓
        else if (Application.platform == RuntimePlatform.Android)
        {

        }
        //判断当前游戏运行的平台是winds
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {

        }
        //判断当前游戏运行的平台是开发模式
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
