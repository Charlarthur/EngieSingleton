namespace EngieSingleton
{
    public enum Status { NotInitialized, Initialized};

    public sealed class DictionaryCache
    {
        private Dictionary<string, object> _cachedDictionary;
        private static Lazy<DictionaryCache> _cache = new(() => new());
        public static Status ClassStatus { get; set; } = Status.NotInitialized;

        public static DictionaryCache Instance => _cache.Value;

        private DictionaryCache() 
        {
            _cachedDictionary = new();
            ClassStatus = Status.Initialized;
        }

        public void Add(string key, object value) => _cachedDictionary[key] = value;

        public object? Get(string key) => _cachedDictionary.ContainsKey(key) ? _cachedDictionary[key]: String.Empty;

        
    }

}
