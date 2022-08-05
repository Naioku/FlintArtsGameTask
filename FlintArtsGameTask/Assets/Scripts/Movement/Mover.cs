using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform target;
        void Start()
        {
        
        }

        void Update()
        {
            GetComponent<NavMeshAgent>().SetDestination(target.position);
        }
    }
}
