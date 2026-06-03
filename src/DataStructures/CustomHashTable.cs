using System;
using System.Collections.Generic;

namespace SmartTransitNavigation.DataStructures;

public sealed class CustomHashTable<TKey, TValue>
    where TKey : notnull
{
    private const int DefaultCapacity = 16;
    private const double MaxLoadFactor = 0.75;

    private readonly IEqualityComparer<TKey> _comparer;
    private List<Entry>?[] _buckets;

    public CustomHashTable()
        : this(DefaultCapacity)
    {
    }

    public CustomHashTable(int capacity, IEqualityComparer<TKey>? comparer = null)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
        }

        _buckets = new List<Entry>?[capacity];
        _comparer = comparer ?? EqualityComparer<TKey>.Default;
    }

    public int Count { get; private set; }

    public void Add(TKey key, TValue value)
    {
        EnsureKey(key);

        if ((Count + 1.0) / _buckets.Length > MaxLoadFactor)
        {
            Resize(_buckets.Length * 2);
        }

        var bucket = GetOrCreateBucket(key);
        foreach (var entry in bucket)
        {
            if (_comparer.Equals(entry.Key, key))
            {
                entry.Value = value;
                return;
            }
        }

        bucket.Add(new Entry(key, value));
        Count++;
    }

    public bool TryGetValue(TKey key, out TValue? value)
    {
        EnsureKey(key);

        var index = GetBucketIndex(key);
        var bucket = _buckets[index];

        if (bucket is not null)
        {
            foreach (var entry in bucket)
            {
                if (_comparer.Equals(entry.Key, key))
                {
                    value = entry.Value;
                    return true;
                }
            }
        }

        value = default;
        return false;
    }

    public bool ContainsKey(TKey key)
    {
        return TryGetValue(key, out _);
    }

    private static void EnsureKey(TKey key)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }
    }

    private List<Entry> GetOrCreateBucket(TKey key)
    {
        var index = GetBucketIndex(key);
        return _buckets[index] ??= new List<Entry>();
    }

    private int GetBucketIndex(TKey key)
    {
        var hash = _comparer.GetHashCode(key) & 0x7fffffff;
        return hash % _buckets.Length;
    }

    private void Resize(int newCapacity)
    {
        var oldBuckets = _buckets;
        _buckets = new List<Entry>?[newCapacity];
        Count = 0;

        foreach (var bucket in oldBuckets)
        {
            if (bucket is null)
            {
                continue;
            }

            foreach (var entry in bucket)
            {
                Add(entry.Key, entry.Value);
            }
        }
    }

    private sealed class Entry
    {
        public Entry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; }

        public TValue Value { get; set; }
    }
}
