using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    [System.Serializable]
    public class CustomList<T> // specifing this class is going to be a generic class
    {
        public T[] list;
        public int capacity { get; }
        public int amount { get; private set; }
        //Default constructor
        public CustomList() { }
        // gameObjects[0]
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        // Adds item to the end of the CustomList<T>
        public void Add(T item)
        {
            // Create a new array of amount + 1
            T[] cache = new T[amount + 1];
            //Check if list has been initialised
            if (list != null)
            {
                // Copy all existing items to new array
                for (int i = 0; i < list.Length; i++)
                {
                    cache[i] = list[i];
                }
            }
            // Place new item at end index
            cache[amount] = item;
            // Replace old array with new array
            list = cache;
            //Increment amount
            amount++; 
        }

        //Add items of specified collection at the CustomList<>
        public void AddRange(IEnumerable<T> collection)
        {

        //public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T> source)
        //{
        //    List<T> list = destination as List<T>;

        //    if (list != null)
        //    {
        //        list.AddRange(source);
        //    }
        //}
        //List<int> numbers = new List<int>();
        //numbers.Add(10);
        //numbers.Add(20);
        // numbers.Add(30);

        //if (list != null)
        //{
        //     list.AddRange(numbers);
        //}

        //-----------------------------------------

        // Create a new array of amount
        //T[] cache = new T[amount];
        //Check if list has been initialised
        //if (list != null)
        //{
        // Copy all existing items to new array
        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        cache[i] = list[i];
        //    }
        //}
        // Place new item at end index
        //cache[amount] = collection;
        // Replace old array with new array
        //list = cache;
        //Increment amount
        //amount.AddRange();
    }

        //Sorts the items in CustomList<T>
        public void Sort(T item)
        {            
            //Sort amount
            //amount.Sort();
        }

        //Remove first occurence of the specified item
        public void Remove(T item)
        {
            // Find index of item and remove element from that index
            // Create a new array of amount - 1
            T[] cache = new T[amount - 1];
            //Check if list has been initialised
            if (list != null)
             {
             //Copy all existing items to new array
                for (int i = 0; i < list.Length; i++)
                {
                     cache[i] = list[i];
                 }
             }
             //Place new item at end index
             cache[amount] = item;
             //Replace old array with new array
             list = cache;
            //Remove amount
              amount--;

            // Create a new array of amount
            // T[] cache = new T[amount];
            //Check if list has been initialised
            // if (list != null)
            // {
            // Copy all existing items to new array
            //     for (int i = 0; i < list.Length; i++)
            //     {
            //         cache[i] = list[i];
            //     }
            // }
            // Place new item at end index
            //cache[amount] = item;
            // Replace old array with new array
            //list = cache;
            //Remove amount
            // amount.Remove(10);

            //list.Remove();

        }


    }
}
