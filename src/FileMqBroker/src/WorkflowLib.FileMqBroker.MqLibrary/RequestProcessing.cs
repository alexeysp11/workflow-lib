using System.Collections.Concurrent;
using WorkflowLib.FileMqBroker.MqLibrary.KeyCalculations;
using WorkflowLib.FileMqBroker.MqLibrary.Models;

namespace WorkflowLib.FileMqBroker.MqLibrary
{
    public enum RequestProcessingState
    {
        RequestUnread = 0,
        RequestRead = 1
    }

    public static class RequestProcessing
    {
        public static ConcurrentDictionary<string, string> ConcurrentDictionary { get; private set; }

        static RequestProcessing()
        {
            ConcurrentDictionary = new ConcurrentDictionary<string, string>();
        }

        /// <summary>
        /// Process message.
        /// </summary>
        public static string ProcessMessage(
            string request,
            string queueName,
            string httpMethod,
            string controllerPath,
            AppSettings appSettings)
        {
            if (string.IsNullOrEmpty(queueName))
            {
                throw new ArgumentNullException(nameof(queueName), "Queue name could not be null or empty");
            }
            if (string.IsNullOrEmpty(httpMethod))
            {
                throw new ArgumentNullException(nameof(httpMethod), "HTTP method could not be null or empty");
            }
            if (string.IsNullOrEmpty(controllerPath))
            {
                throw new ArgumentNullException(nameof(controllerPath), "Controller path could not be null or empty");
            }

            // Write message into file.
            string requestKey = KeyCalculation.CalculateSha256(request);
            string fileSaveKey = KeyCalculation.CalculateMd5($"{httpMethod} {controllerPath} {requestKey}");
            string requestFileName = Path.Combine(appSettings?.RequestDirectoryName ?? "", $"{fileSaveKey}.req");
            string responseFileName = Path.Combine(appSettings?.RequestDirectoryName ?? "", $"{fileSaveKey}.resp");
            WriteFile(request, requestFileName);

            // Read response with the same name of the file.

            return "";
        }

        /// <summary>
        /// Write data into the specified file.
        /// </summary>
        private static void WriteFile(string request, string requestFileName)
        {
            if (!File.Exists(requestFileName))
            {
                File.Create(requestFileName);
                File.WriteAllText(requestFileName, request);
            }
        }
    }
}
