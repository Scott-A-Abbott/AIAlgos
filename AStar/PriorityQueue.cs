using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;
        public PriorityQueue()
        {
            this.data = new List<T>();
        }
        public void Add(T item)
        {
            data.Add(item);
            int ci = data.Count - 1;
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;
                if (data[ci].CompareTo(data[pi]) >= 0)
                    break;
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }
        public bool IsEmpty()
        {
            if (data.Count > 0)
            {
                return false;
            }
            return true;
        }
        public T Shift()
        {
            if (data.Count > 0)
            {
                T head = data[0];
                data.RemoveAt(0);
                return head;
            }
            return default(T);
        }
        public void Remove(T target){
            data.Remove(target);
        }
        public bool Contains(T item){
            return data.Contains(item);
        }
    }
}