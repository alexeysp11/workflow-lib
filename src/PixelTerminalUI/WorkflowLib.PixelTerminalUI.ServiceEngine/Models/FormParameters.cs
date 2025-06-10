namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Models
{
    /// <summary>
    /// Parameters and variables stored on the form at runtime.
    /// </summary>
    public class FormParameters
    {
        /// <summary>
        /// Values ​​of the saved parameters.
        /// </summary>
        public Dictionary<string, object?> Values { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FormParameters()
        {
            Values = new Dictionary<string, object?>();
        }

        /// <summary>
        /// Indexer to get the value of an element by the specified key.
        /// </summary>
        /// <param name="key">Specified key</param>
        /// <returns>Value of the element if it exists in the collection; otherwise, null</returns>
        public object? this[string key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Set(key, value);
            }
        }

        /// <summary>
        /// Determines whether an element with the specified key is in the collection.
        /// </summary>
        /// <param name="key">Specified key</param>
        /// <returns>true if the collection contains an element with the specified key; otherwise, false</returns>
        public bool Exists(string key)
        {
            return Values.ContainsKey(key);
        }

        /// <summary>
        /// Get the value of an element by the specified key.
        /// </summary>
        /// <param name="key">Specified key</param>
        /// <returns>Value of the element if it exists in the collection; otherwise, null</returns>
        public object? Get(string key)
        {
            return Exists(key) ? Values[key] : null;
        }

        /// <summary>
        /// Set a new value to the element with the specified key.
        /// </summary>
        /// <param name="key">Specified key</param>
        /// <param name="value">New value for the element</param>
        public void Set(string key, object? value)
        {
            if (Values.ContainsKey(key))
            {
                Values[key] = value;
            }
            else
            {
                Values.Add(key, value);
            }
        }

        /// <summary>
        /// Clear entire collection.
        /// </summary>
        public void Clear()
        {
            Values.Clear();
        }

        /// <summary>
        /// Remove an element with the specified key from the collection.
        /// </summary>
        /// <param name="key">Specified key</param>
        public void Remove(string key)
        {
            if (Values.ContainsKey(key))
            {
                Values.Remove(key);
            }
        }
    }
}
