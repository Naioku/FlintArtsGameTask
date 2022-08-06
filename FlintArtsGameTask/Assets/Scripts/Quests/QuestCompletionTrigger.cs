using UI;
using UnityEngine;

namespace Quests
{
    public class QuestCompletionTrigger : MonoBehaviour
    {
        [SerializeField] private DeliveryQuests deliveryQuest;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.Equals(deliveryQuest.DeliveryItem))
            {
                FindObjectOfType<HUDInfoCanvas>().FadeInOutMessage(Messages.QuestCompleted(deliveryQuest.QuestName));
            }
        }
    }
}
