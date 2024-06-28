using System.Threading;
using System.Text;
using System.Text.Json; 
using RabbitMQ.Client;
using WorkflowLib.Examples.PublicTransportDevices.Models.Data;

// namespace WorkflowLib.Examples.PublicTransportDevices.Examples.RabbitMQSender;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

string exchangeName = "ptd_exchange"; 

channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);

// Send asynchronously 
for (int i = 0; i < 100; i++)
{
    Thread thread = new Thread(() => 
    {
        var maxj = 1000; 
        var rnd = new System.Random(); 
        var dt1 = System.DateTime.Now; 
        for (int j = 0; j < maxj; j++)
        {
            string message = JsonSerializer.Serialize(new DeviceInfo 
                {
                    Uid = "3eb20d9f-3350-4bd3-b343-d903d2e51cfb", 
                    GeoCoordinate = new GeoCoordinate
                    {
                        Latitude = rnd.NextDouble(),
                        Longitude = rnd.NextDouble()
                    }, 
                    DateTimeCreated = System.DateTime.Now, 
                    SpecificData = new VehicleValidatorInfo { NumberSuccessful = 12 }
                }); 
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: exchangeName,
                                routingKey: "",
                                basicProperties: null,
                                body: body);
            Thread.Sleep(5); 
            if (j == maxj - 1)
            {
                var dt2 = System.DateTime.Now; 
                var dif = dt2 - dt1; 
                Console.WriteLine($"Thread '{Thread.CurrentThread.ManagedThreadId}' finished (Started: {dt1}, Executed: {dt2}, Executed in: {dif.Seconds}:{dif.Milliseconds})"); 
            }
        }
    }); 
    thread.Start(); 
}

// 
Console.ReadLine();
channel.Close(); 
connection.Close(); 
