using System.Collections.Generic;
using UnityEngine;

namespace UI.Inventory
{
    /// <summary>
    /// Inventory back-end class. Manages whole inventory back-end.
    /// </summary>
    public class Inventory
    {
        private readonly List<UIItem> _itemCollection = new();

        public Inventory(int maxSize)
        {
            MaxSize = maxSize;
        }
        
        public List<UIItem> GetAllItems => _itemCollection;
        public int MaxSize { get; }

        /// <summary>
        /// Adds item to inventory back-end.
        /// </summary>
        /// <param name="uiItem">Item which is added.</param>
        /// <returns>Returns a bool based on whether addition had been completed successfully or not.</returns>
        public bool AddItem(UIItem uiItem)
        {
            if (_itemCollection.Count >= MaxSize)
            {
                Object.FindObjectOfType<HUDInfoCanvas>().FadeInOutMessage(Messages.InventoryFull);
                return false;
            }
            
            _itemCollection.Add(uiItem);
            return true;
        }

        /// <summary>
        /// Removes item from inventory back-end.
        /// </summary>
        /// <param name="uiItem">Item which is removed.</param>
        public void RemoveItem(UIItem uiItem)
        {
            _itemCollection.Remove(uiItem);
        }
    }
}