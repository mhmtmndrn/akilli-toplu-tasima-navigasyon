using System;
using System.Collections.Generic;

namespace SmartTransitNavigation.DataStructures;

public sealed class MinHeap<TValue>
{
    private readonly List<HeapItem> _items = new();

    public int Count => _items.Count;

    public void Insert(TValue value, double priority)
    {
        var item = new HeapItem(value, priority);
        _items.Add(item);
        MoveUp(_items.Count - 1);
    }

    public bool TryExtractMin(out TValue? value, out double priority)
    {
        if (_items.Count == 0)
        {
            value = default;
            priority = 0;
            return false;
        }

        var min = _items[0];
        var last = _items[^1];
        _items.RemoveAt(_items.Count - 1);

        if (_items.Count > 0)
        {
            _items[0] = last;
            MoveDown(0);
        }

        value = min.Value;
        priority = min.Priority;
        return true;
    }

    private void MoveUp(int index)
    {
        while (index > 0)
        {
            var parentIndex = (index - 1) / 2;
            if (_items[parentIndex].Priority <= _items[index].Priority)
            {
                break;
            }

            Swap(parentIndex, index);
            index = parentIndex;
        }
    }

    private void MoveDown(int index)
    {
        while (true)
        {
            var leftIndex = (index * 2) + 1;
            var rightIndex = leftIndex + 1;
            var smallestIndex = index;

            if (leftIndex < _items.Count && _items[leftIndex].Priority < _items[smallestIndex].Priority)
            {
                smallestIndex = leftIndex;
            }

            if (rightIndex < _items.Count && _items[rightIndex].Priority < _items[smallestIndex].Priority)
            {
                smallestIndex = rightIndex;
            }

            if (smallestIndex == index)
            {
                break;
            }

            Swap(index, smallestIndex);
            index = smallestIndex;
        }
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        (_items[firstIndex], _items[secondIndex]) = (_items[secondIndex], _items[firstIndex]);
    }

    private sealed class HeapItem
    {
        public HeapItem(TValue value, double priority)
        {
            Value = value;
            Priority = priority;
        }

        public TValue Value { get; }

        public double Priority { get; }
    }
}
