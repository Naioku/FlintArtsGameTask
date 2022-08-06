using System.Collections.Generic;
using UnityEngine;

namespace UI.Inventory
{
    public class Inventory
    {
        private readonly List<UIItem> _itemCollection = new();
        public List<UIItem> GetAllItems => _itemCollection;
        public int MaxSize => 2;

        public bool AddItem(UIItem uiItem)
        {
            if (_itemCollection.Count >= MaxSize)
            {
                Debug.Log("You can't carry more items.");
                return false;
            }
            
            _itemCollection.Add(uiItem);
            return true;
        }
    }
}