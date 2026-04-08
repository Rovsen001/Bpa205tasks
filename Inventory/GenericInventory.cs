using System;
using System.Collections.Generic;
using System.Text;

namespace Invantory
{
    internal class GenericInventory<T>
    {
        private List<T> _items;
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Count) throw new IndexOutOfRangeException("Invalid Index!");
                else return _items[index];
            }
            set
            {
                if (index < 0 || index >= _items.Count) throw new IndexOutOfRangeException("Invalid Index!");
                 _items[index] = value;
            }
        }
        public GenericInventory()
        {
               _items = new List<T>();
        }

        public void AddItem(T item)
        {
            _items.Add(item);
        }
        public void RemoveItem(T item)
        {
            if (_items.Contains(item)) _items.Remove(item);
            else Console.WriteLine("Item tapilmadi");
        }
        public void GetAllItems()
        {
            foreach (T item in _items)
            {
                Console.WriteLine(item);
            }
        }
        public List<T> FindByIndex(int index)
        {
            return _items;
        }
    }
}
