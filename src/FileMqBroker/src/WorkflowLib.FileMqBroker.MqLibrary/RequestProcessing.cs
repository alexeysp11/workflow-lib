namespace WorkflowLib.FileMqBroker.MqLibrary
{
    public static class RequestProcessing
    {
        /// <summary>
        /// Process message.
        /// </summary>
        public static string ProcessMessage(string request, string queueName)
        {
            if (string.IsNullOrEmpty(queueName))
            {
                throw new ArgumentNullException(nameof(queueName), "Queue name could not be null or empty");
            }
            return "";
        }
    }
}
