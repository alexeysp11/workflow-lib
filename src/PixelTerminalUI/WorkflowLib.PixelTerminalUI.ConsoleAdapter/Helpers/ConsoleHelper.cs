﻿using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace WorkflowLib.PixelTerminalUI.ConsoleAdapter.Helpers;

public static class ConsoleHelper
{
    public static void ClearDisplayedInfo()
    {
        // 
    }

    /// <summary>
    /// Usage: ConsoleHelper.WriteStringInColor("[String to be inverted]");
    /// </summary>
    public static void WriteStringInColor(string message)
    {
        var pieces = Regex.Split(message, @"(\[[^\]]*\])");

        for (int i = 0; i < pieces.Length; i++)
        {
            string piece = pieces[i];
            if (piece.StartsWith("[") && piece.EndsWith("]"))
            {
                piece = piece.Substring(1, piece.Length - 2);
                InvertString(piece);
                continue;
            }
            Console.Write(piece);
        }
        Console.WriteLine();
    }

    public static void InvertString(string message)
    {
        var foregroundColor = Console.BackgroundColor;
        var backgroundColor = Console.ForegroundColor;

        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = foregroundColor;

        Console.Write(message);

        Console.ResetColor();
    }

    public static void PrintDisplayedInfo(string[,] displayedInfo, bool displayBorders = false)
    {
        if (displayedInfo == null)
        {
            throw new Exception($"Parameter '{nameof(displayedInfo)}' could not be null");
        }

        string result = GetDisplayedInfoString(displayedInfo, displayBorders);
        Console.WriteLine(result);
    }

    public static string GetDisplayedInfoString(string[,] displayedInfo, bool displayBorders = false)
    {
        string result = string.Empty;

        int qtyRows = displayedInfo.GetLength(0);
        int qtyColumns = displayedInfo.GetLength(1);

        if (displayBorders)
        {
            result += new String('-', qtyColumns);
            result += "\n";
        }

        for (int i = 0; i < qtyRows; i++)
        {
            for (int j = 0; j < qtyColumns; j++)
            {
                result += displayedInfo[i, j];
            }
            if (displayBorders)
            {
                result += "|";
            }
            result += "\n";
        }

        if (displayBorders)
        {
            result += new String('-', qtyColumns);
        }

        return result;
    }

    public static string EnterLine(
        string? hint = null,
        bool allowEmptyString = false,
        string? emptyStringReplacement = null,
        ConsoleColor? hintForegroundColor = null,
        string? beforeInputString = null,
        int? maxInputCharNumber = null)
    {
        string result = string.Empty;
        while (true)
        {
            // Write hint.
            ClearPreviousInput();
            if (!string.IsNullOrEmpty(hint))
            {
                ConsoleColor currentForeground = Console.ForegroundColor;
                if (hintForegroundColor != null)
                {
                    Console.ForegroundColor = hintForegroundColor.Value;
                }
                Console.WriteLine(hint);
                Console.ForegroundColor = currentForeground;
            }

            if (!string.IsNullOrEmpty(beforeInputString))
            {
                Console.Write($"{beforeInputString} ");
            }

            ClearPreviousInput();

            // Read input.
            string input = Console.ReadLine() ?? "";
            
            // Process user input.
            if (!string.IsNullOrEmpty(emptyStringReplacement) && string.IsNullOrEmpty(input))
            {
                input = emptyStringReplacement;
            }
            if (!string.IsNullOrEmpty(input))
            {
                result = input;
                break;
            }
            else
            {
                if (allowEmptyString)
                {
                    result = input ?? "";
                    break;
                }
            }
        }
        return result;
    }

    /// <summary>
    /// Get password from console.
    /// </summary>
    /// <returns>Entered password</returns>
    public static string GetPassword(string? hint = null, string? beforeInputString = null)
    {
        ClearPreviousInput();
        if (!string.IsNullOrEmpty(hint))
        {
            Console.WriteLine(hint);
        }
        if (!string.IsNullOrEmpty(beforeInputString))
        {
            Console.Write(beforeInputString + " ");
        }
        ClearPreviousInput();

        var pwd = new SecureString();
        while (true)
        {
            ConsoleKeyInfo i = Console.ReadKey(true);
            if (i.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (i.Key == ConsoleKey.Backspace)
            {
                if (pwd.Length > 0)
                {
                    pwd.RemoveAt(pwd.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(i.KeyChar))
            {
                pwd.AppendChar(i.KeyChar);
                Console.Write("*");
            }
        }
        return MarshalToString(pwd);
    }

    private static void ClearPreviousInput()
    {
        int startCursorLeft = Console.CursorLeft;
        int startCursorTop = Console.CursorTop;
        Console.Write(new string(' ', Console.WindowWidth));
        Console.CursorLeft = startCursorLeft;
        Console.CursorTop = startCursorTop;
    }

    private static string MarshalToString(SecureString sstr)
    {
        if (sstr == null || sstr.Length == 0)
        {
            return string.Empty;
        }
        IntPtr intPtr = IntPtr.Zero;
        string empty = string.Empty;
        try
        {
            intPtr = Marshal.SecureStringToGlobalAllocUnicode(sstr);
            return Marshal.PtrToStringUni(intPtr);
        }
        finally
        {
            if (intPtr != IntPtr.Zero)
            {
                Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
            }
        }
    }
}