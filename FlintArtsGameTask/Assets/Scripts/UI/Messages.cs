namespace UI
{
    public static class Messages
    {
        public static string InventoryFull = "You can't carry more items";
        
        public static string ItemCollected(string itemName)
        {
            return $"Collected item: {itemName}";
        }
        
        public static string ItemRemovedFromInventory(string itemName)
        {
            return $"Removed item from inventory: {itemName}";
        }
        
        public static string QuestCompleted(string questName)
        {
            return $"Mission {questName} completed!";
        }
    }
}
