using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public class GameIte
    {
        public string Name { get; }

        public GameIte(string name)
        {
            Name = name;
        }
    }

    public class Inventory
    {
        private List<GameIte> items = new List<GameIte>();

        public void AddItem(GameIte item)
        {
            items.Add(item);
        }

        public bool Contains(GameIte item)
        {
            return items.Contains(item);
        }

        public void RemoveItem(GameIte item)
        {
            items.Remove(item);
        }

        public int ItemCount()
        {
            return items.Count;
        }
    }
}
