using Microsoft.Extensions.Hosting;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Resolvers;

namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Background
{
    /// <summary>
    /// Worker to check if the session is valid.
    /// </summary>
    public class SessionCheckWorker : BackgroundService
    {
        /// <summary>
        /// Default value of the maximum amount of minutes a session could be active.
        /// </summary>
        public const int DefaultMaxMinutesActiveSession = 10;

        /// <summary>
        /// Default value of the number of checks to be performed during the session's active period.
        /// </summary>
        public const int DefaultSessionCheckPeriodQty = 4;

        /// <summary>
        /// Seconds in minute.
        /// </summary>
        private const int _secondsInMinute = 60000;

        /// <summary>
        /// The maximum amount of minutes a session could be active.
        /// </summary>
        private readonly int _maxMinutesActiveSession;

        /// <summary>
        /// The number of checks to be performed during the session's active period.
        /// </summary>
        private readonly int _sessionCheckPeriodQty;

        public SessionCheckWorker(AppSettings? appSettings)
        {
            _maxMinutesActiveSession = appSettings?.MaxMinutesActiveSession ?? DefaultMaxMinutesActiveSession;
            _sessionCheckPeriodQty = appSettings?.SessionCheckPeriodQty ?? DefaultSessionCheckPeriodQty;
        }

        /// <summary>
        /// Method for executing worker functionality.
        /// </summary>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    DateTime lastAvailableEditDate = DateTime.UtcNow.AddMinutes(_maxMinutesActiveSession);
                    List<string> sessionUidsToDelete = MemoryResolver.GetInactiveSessionUidList(lastAvailableEditDate);
                    foreach (string sessionUid in sessionUidsToDelete)
                    {
                        MemoryResolver.DeleteSession(sessionUid);
                    }
                }
                catch (Exception)
                {
                    // Log the error.
                }
                await Task.Delay(_secondsInMinute * _maxMinutesActiveSession / _sessionCheckPeriodQty, stoppingToken);
            }
        }
    }
}
