using System;
using System.Collections.Generic;
using System.Net.Http;
#if NET6_0_OR_GREATER
using System.Net.Http.Json;
#endif
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Models.Performance;

namespace Cims.WorkflowLib.NetworkApis
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpSender 
    {
        /// <summary>
        /// 
        /// </summary>
        public async Task<List<ApiOperation>> SendMultipleAsync(string url, List<object> parameters, string methodName = "")
        {
            if (string.IsNullOrEmpty(url))
                throw new System.Exception("URL could not be null or empty");
            if (parameters == null || parameters.Count == 0)
                throw new System.Exception("The list of parameters could not be null or empty");
            // 
            var httpClient = new HttpClient();
            var tasks = new Task<System.Net.Http.HttpResponseMessage>[parameters.Count];
            var requestStrings = new string[parameters.Count];
            for (int i = 0; i < parameters.Count; i++)
            {
                var requestStr = JsonSerializer.Serialize(parameters[i]);
                requestStrings[i] = requestStr;
#if NET6_0_OR_GREATER
                tasks[i] = httpClient.PostAsJsonAsync(url, parameters[i]);
#else
                tasks[i] = httpClient.PostAsync(url, new StringContent(requestStr));
#endif
            }
            var dt1 = System.DateTime.Now;
            await Task.WhenAll(tasks);
            var dt2 = System.DateTime.Now;
            // 
            var result = new List<ApiOperation>();
            for (int i = 0; i < parameters.Count; i++)
            {
                result.Add(new ApiOperation 
                {
                    MethodName = methodName,
                    Request = requestStrings[i],
                    Response = await tasks[i].Result.Content.ReadAsStringAsync(),
                    ExecutionTime = new ExecutionTime
                    {
                        DateTimeBegin = dt1,
                        DateTimeEnd = dt2
                    }
                });
            }
            return result;
        }
    }
}