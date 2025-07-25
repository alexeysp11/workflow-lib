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
    private Random _random;
    private ConcurrentDictionary<string, string> _fullpathHashDictionary;
    private IKeyCalculation _keyCalculation;
    private readonly string _reqExtension = "req";
    private readonly string _respExtension = "resp";

    /// <summary>
    /// Default constructor.
    /// </summary>
    public FileNameGenerationMD5(KeyCalculationMD5 keyCalculation)
    {
        _random = new Random();
        _fullpathHashDictionary = new ConcurrentDictionary<string, string>();
        _keyCalculation = keyCalculation;
    }

    /// <summary>
    /// Generates a filename using MD5 hash.
    /// </summary>
    public string GetFileName(string method, string path, MessageFileType direction)
    {
        var hash = CalculateHash(method, path);
        var randomPostfix = _random.Next().ToString("D10");
        return $"{System.DateTime.Now.ToString("yyyyMMddHHmmssfff")}.{hash}.{randomPostfix}.{GetMessageFileExtension(direction)}";
    }

    /// <summary>
    /// Calculates the MD5 hash based on the method and path.
    /// </summary>
    public string CalculateHash(string method, string path)
    {
        var fullpath = Path.Combine(method, path);
        
        if (_fullpathHashDictionary.ContainsKey(fullpath))
        {
            return _fullpathHashDictionary[fullpath];
        }

        var hash = _keyCalculation.CalculateHash(fullpath);
        _fullpathHashDictionary.TryAdd(fullpath, hash);
        return hash;
    }

    /// <summary>
    /// Returns the file extension depending on the writing direction.
    /// </summary>
    private string GetMessageFileExtension(MessageFileType direction)
    {
        return direction == MessageFileType.Request ? _reqExtension : _respExtension;
    }
}