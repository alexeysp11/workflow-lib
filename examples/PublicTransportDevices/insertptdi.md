# Registering a new event for a specific device and entering it into the database

[English](insertptdi.md) | [Русский](insertptdi.ru.md)

There are two ways to send an event for a specific device to the server:

- Via `RabbitMQ`;
- Directly (via `HttpClient` and WebAPI).

## Via RabbitMQ

```C#
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
        var maxj = 100; 
        var rnd = new System.Random(); 
        var dt1 = System.DateTime.Now; 
        for (int j = 0; j < maxj; j++)
        {
            // string message = "Hello World! thread: " + Thread.CurrentThread.ManagedThreadId; 
            string message = JsonSerializer.Serialize(new DeviceInfo 
                {
                    // Uid = Guid.NewGuid().ToString(), 
                    Uid = "3eb20d9f-3350-4bd3-b343-d903d2e51cfb", 
                    GeoCoordinate = new GeoCoordinate
                    {
                        Latitude = rnd.NextDouble(),
                        Longitude = rnd.NextDouble()
                    }, 
                    DateTimeCreated = System.DateTime.Now
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
```

## Directly (via HttpClient and WebAPI)

```C#
class Program
{
    static async Task Main(string[] args)
    {
        // Inserting: 
        // 1000 - total: 5:363
        // so we can make 166 to 200 insert requests per second. 

        // 
        var httpClient = new HttpClient(); 
        var requestCount = 1000; 
        var url = "https://localhost:7010/DeviceInfo"; 
        var tasks = new Task[requestCount]; 
        var rnd = new System.Random(); 
        for (int i = 0; i < requestCount; i++)
        {
            var deviceInfo = new DeviceInfo 
                {
                    Uid = "3eb20d9f-3350-4bd3-b343-d903d2e51cfb", 
                    GeoCoordinate = new GeoCoordinate
                    {
                        Latitude = rnd.NextDouble(),
                        Longitude = rnd.NextDouble()
                    }
                };
            tasks[i] = httpClient.PostAsJsonAsync(url, deviceInfo); 
        }
        
        // 
        var dt1 = System.DateTime.Now; 
        await Task.WhenAll(tasks); 

        // 
        var dt2 = System.DateTime.Now; 
        var dif = dt2 - dt1; 
        Console.WriteLine($"Started: {dt1}");
        Console.WriteLine($"Executed: {dt2}");
        Console.WriteLine($"Executed in: {dif.Seconds}:{dif.Milliseconds}");
    }
}
```

## Optimizing the query for adding data to the database

In the present implementation, a normal insert is used, which has a duration of approximately 135-145 ms.

```C#
                var uid = device.Uid; 
                var latitude = device.GeoCoordinate.Latitude; 
                var longitude = device.GeoCoordinate.Longitude; 
                var dtCreated = device.DateTimeCreated.ToString(); 
                var specificData = System.Text.Json.JsonSerializer.Serialize(device.SpecificData); 
                string sql = @$"
insert into public.pt_device_info (device_uid, latitude, longitude, datetime_created, specific_data)
values('{uid}', {latitude}, {longitude}, '{dtCreated}', '{specificData}')"; 
                _dbConnection.ExecuteSqlCommand(sql); 
```

There is also an alternative way - using the following function. 
Its main advantage is quite a lot of flexibility in terms of functionality, however, it takes 195-200 ms, which is quite slow compared to a regular insert (thus, one insert will execute about 50 ms faster than this function, and 100 inserts will already be 5 seconds faster):

```SQL
create or replace function insert_into_pt_device_info(
    a_device_uid text,
    a_latitude double precision, 
    a_longitude double precision, 
    a_datetime_created varchar(100), 
    a_specific_data text)
returns void as 
$$
declare
   l_pt_device_id integer;
begin
    select d.pt_device_id
    into l_pt_device_id
    from public.pt_device d
    where d.device_uid = a_device_uid; 

    if l_pt_device_id = null then 
        return; 
    end if; 

    insert into public.pt_device_info (pt_device_id, latitude, longitude, datetime_created, specific_data)
    values (l_pt_device_id, a_latitude, a_longitude, a_datetime_created, a_specific_data); 
end
$$ language plpgsql;
```

For such a function, you need to redefine the `public.pt_device_info` table:

```SQL
create table if not exists public.pt_device_info
(
    pt_device_info_id serial primary key, 
    pt_device_id integer references public.pt_device (pt_device_id), 
    latitude float8,
    longitude float8, 
    datetime_created varchar(100),
    specific_data text
);
```
