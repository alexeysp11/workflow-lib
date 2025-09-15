using System;
using System.IO;

namespace FileMqBroker.MqLibrary.DirectoryOperations;

/// <summary>
/// Class for working with files.
/// </summary>
public class FileHandler
{
    /// <summary>
    /// Creates a new file at the specified path.
    /// </summary>
    /// <param name="filePath">Path to the file.</param>
    public void CreateFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            throw new ArgumentException($"File {filePath} already exists.");
        }

        try
        {
            File.Create(filePath).Close();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while creating the file {filePath}: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Writes data to a file at the specified path.
    /// </summary>
    /// <param name="filePath">Path to the file.</param>
    /// <param name="data">Data to write.</param>
    public void WriteToFile(string filePath, string data)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File {filePath} not found.");
        }

        try
        {
            File.WriteAllText(filePath, data);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while writing to the file {filePath}: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Reads data from a file at the specified path.
    /// </summary>
    /// <param name="filePath">Path to the file.</param>
    /// <returns>Read data from the file.</returns>
    public string ReadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File {filePath} not found.");
        }

        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while reading the file {filePath}: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Deletes a file at the specified path.
    /// </summary>
    /// <param name="filePath">Path to the file.</param>
    public void DeleteFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File {filePath} not found.");
        }

        try
        {
            File.Delete(filePath);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while deleting the file {filePath}: {ex.Message}", ex);
        }
    }
}
