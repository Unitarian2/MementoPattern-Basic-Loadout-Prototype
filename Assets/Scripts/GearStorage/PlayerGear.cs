using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGear : GearStorage
{
    public Memento CreateMemento() => new Memento(new List<Item>(items));
    public void SetMemento(Memento memento)
    {
        items = memento.GetItems();
        for (int i = 0;i < slots.Count;i++)
        {
            slots[i].UpdateUI(items[i]);
        }
    }
    public class Memento
    {
        List<Item> items { get; }

        public Memento(List<Item> items)
        {
            this.items = items;
        }

        public List<Item> GetItems() => items;
    }
}
