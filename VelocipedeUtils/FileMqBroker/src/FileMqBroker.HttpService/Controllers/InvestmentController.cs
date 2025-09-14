using System.Threading;
using Microsoft.AspNetCore.Mvc;
using FileMqBroker.MqLibrary.Adapters.WriteAdapters;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.HttpService.Controllers;

[ApiController]
[Route("[controller]")]
public class InvestmentController : ControllerBase
{
    private readonly ILogger<InvestmentController> m_logger;
    private IWriteAdapter m_writeAdapter;

    public InvestmentController(
        ILogger<InvestmentController> logger,
        IWriteAdapter writeAdapter)
    {
        m_logger = logger;
        m_writeAdapter = writeAdapter;
    }

    [HttpGet(Name = "GetInvestmentStats")]
    public int GetInvestmentStats()
    {
        ThreadPool.QueueUserWorkItem(state =>
        {
            m_writeAdapter.WriteMessage("HttpGet", "GetInvestmentStats", string.Empty, MessageFileType.Request);
        });
        return 200;
    }

    [HttpPost(Name = "RequestInvestment")]
    public int RequestInvestment(string content)
    {
        ThreadPool.QueueUserWorkItem(state =>
        {
            m_writeAdapter.WriteMessage("HttpPost", "RequestInvestment", content, MessageFileType.Request);
        });
        return 200;
    }
}
