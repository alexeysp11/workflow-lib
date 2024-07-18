using System.Collections.Concurrent;
using WorkflowLib.Examples.EmployeesMvc.Core.Models;
using WorkflowLib.Examples.EmployeesMvc.Helpers;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Repositories;

/// <summary>
/// Allows to interact with the filtered collections.
/// </summary>
public class FilteredRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Filtered dataset.
    /// </summary>
    private ConcurrentDictionary<string, FilteredRecord<TEntity>> filteredDbSet;
    
    /// <summary>
    /// Timer for deleting old objects.
    /// </summary>
    private System.Timers.Timer aTimer;

    /// <summary>
    /// Basic constructor.
    /// </summary>
    public FilteredRepository()
    {
        this.filteredDbSet = new ConcurrentDictionary<string, FilteredRecord<TEntity>>();
        SetTimer();
    }

    /// <summary>
    /// Retrieves a collection of the filtered objects using its UID.
    /// </summary>
    public virtual IEnumerable<TEntity> GetFiltered(string uid)
    {
        if (string.IsNullOrEmpty(uid)) throw new System.Exception("UID could not be null or empty");

        IEnumerable<TEntity> list = new List<TEntity>();
        if (filteredDbSet.ContainsKey(uid))
        {
            if (filteredDbSet[uid] != null)
                list = filteredDbSet[uid].Value.ToList();
            filteredDbSet[uid].IsReadyForDeleting = true;
        }
        return list;
    }
    /// <summary>
    /// Saves a collection of filtered objects.
    /// </summary>
    public virtual string InsertFiltered(IEnumerable<TEntity> entities)
    {
        if (entities == null) throw new System.Exception("List of entities could not be null");

        string uid = string.Empty;
        do 
        {
            uid = System.Guid.NewGuid().ToString();
        } while (filteredDbSet.ContainsKey(uid));
        var record = new FilteredRecord<TEntity> 
        {
            Value = entities.ToList(), 
            DateTimeCreated = System.DateTime.Now 
        };
        filteredDbSet.TryAdd(uid, record);
        return uid;
    }

    /// <summary>
    /// Registers a timer.
    /// </summary>
    private void SetTimer()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(ConfigHelper.DbSetCollectorInterval);

        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }
    /// <summary>
    /// Deletes olde values.
    /// </summary>
    private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
    {
        if (filteredDbSet.Count == 0) 
            return;
        List<string> keysToDelete = new List<string>();
        foreach (var item in filteredDbSet)
        {
            // Delete unnecessary elements from dataset and datetime set 
            var timeDiff = System.DateTime.Now - item.Value.DateTimeCreated;
            if (item.Value.IsReadyForDeleting || timeDiff.Milliseconds >= ConfigHelper.DbSetCollectorInterval)
                keysToDelete.Add(item.Key);
        }
        foreach (var key in keysToDelete)
        {
            var element = new FilteredRecord<TEntity>();
            filteredDbSet.TryRemove(key, out element);
        }
    }
}
