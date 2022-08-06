using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(fileName = "DeliveryQuest", menuName = "CreateDeliveryQuest")]
    public class DeliveryQuests : ScriptableObject
    {
        [SerializeField] private string questName;
        [SerializeField] private string questDescription;
        [SerializeField] private GameObject deliveryItem;
        
        public string QuestName => questName;
        public string QuestDescription => questDescription;
        public GameObject DeliveryItem => deliveryItem;
    }
}
