using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileHandle
{
    /// <summary>
    /// 创建一个文本文件    
    /// </summary>
    /// <param name="fileName">文件路径</param>
    /// <param name="content">文件内容</param>
    public static void CreateFile(string fileName, string content)
    {
        StreamWriter streamWriter = File.CreateText(fileName);
        streamWriter.Write(content);
        streamWriter.Close();
    }

    /// <summary>
    /// 创建一个文件夹
    /// </summary>
    public static void CreateDirectory(string fileName)
    {
        //文件夹存在则返回
        if (Directory.Exists(fileName))
            return;
        Directory.CreateDirectory(fileName);
    }
}
