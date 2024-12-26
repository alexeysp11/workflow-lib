using System;
using System.Collections.Concurrent;
using System.IO;
using FileMqBroker.MqLibrary.KeyCalculations;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.KeyCalculations.FileNameGeneration;

/// <summary>
/// Generates a filename using MD5 hash calculation functionality.
/// </summary>
public class FileNameGenerationMD5 : IFileNameGeneration
{
    private Random m_random;
    private ConcurrentDictionary<string, string> m_fullpathHashDictionary;
    private IKeyCalculation m_keyCalculation;
    private readonly string m_reqExtension = "req";
    private readonly string m_respExtension = "resp";

    /// <summary>
    /// Default constructor.
    /// </summary>
    public FileNameGenerationMD5(KeyCalculationMD5 keyCalculation)
    {
        m_random = new Random();
        m_fullpathHashDictionary = new ConcurrentDictionary<string, string>();
        m_keyCalculation = keyCalculation;
    }

    /// <summary>
    /// Generates a filename using MD5 hash.
    /// </summary>
    public string GetFileName(string method, string path, MessageFileType direction)
    {
        var hash = CalculateHash(method, path);
        var randomPostfix = m_random.Next().ToString("D10");
        return $"{System.DateTime.Now.ToString("yyyyMMddHHmmssfff")}.{hash}.{randomPostfix}.{GetMessageFileExtension(direction)}";
    }

    /// <summary>
    /// Calculates the MD5 hash based on the method and path.
    /// </summary>
    public string CalculateHash(string method, string path)
    {
        var fullpath = Path.Combine(method, path);
        
        if (m_fullpathHashDictionary.ContainsKey(fullpath))
        {
            return m_fullpathHashDictionary[fullpath];
        }

        var hash = m_keyCalculation.CalculateHash(fullpath);
        m_fullpathHashDictionary.TryAdd(fullpath, hash);
        return hash;
    }

    /// <summary>
    /// Returns the file extension depending on the writing direction.
    /// </summary>
    private string GetMessageFileExtension(MessageFileType direction)
    {
        return direction == MessageFileType.Request ? m_reqExtension : m_respExtension;
    }
}