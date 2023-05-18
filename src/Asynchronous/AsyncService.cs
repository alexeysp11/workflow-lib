using System.Collections; 
using System.Collections.Generic; 
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cims.WorkflowLib.Asynchronous
{
    /// <summary>
    /// 
    /// </summary>
    public class AsyncService
    {
        /// <summary>
        /// Retrieves collection of records 
        /// </summary>
        public Task<ICollection<T>> GetCollectionAsync<T>(System.Func<ICollection<T>> function)
        {
            ICollection<T> result = new List<T>(); 
            Task task = Task.Run(async () => {
                result = function();
            });
            task.Wait();
            return Task.FromResult(result);
        }

        /// <summary>
        /// Retrieves a string 
        /// </summary>
        public Task<string> GetStringAsync(System.Func<string> function, string emptyResult)
        {
            string result = emptyResult; 
            Task task = Task.Run(async () => {
                result = function();
            });
            task.Wait();
            return Task.FromResult(result); 
        }

        /// <summary>
        /// Retrieves a string 
        /// </summary>
        public Task<string> GetStringAsync(System.Func<string, string> function, string input, string emptyInputMsg, string emptyResult)
        {
            if (string.IsNullOrEmpty(input)) return Task.FromResult(emptyInputMsg); 

            string result = emptyResult; 
            Task task = Task.Run(async () => {
                result = function(input);
            });
            task.Wait();
            return Task.FromResult(result); 
        }
    }
}
