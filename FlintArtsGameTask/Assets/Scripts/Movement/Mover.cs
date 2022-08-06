using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    /// <summary>
    /// Manages player movement.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] float maxSpeed = 6f;

        private static readonly int ForwardSpeed = Animator.StringToHash("forwardSpeed");
        
        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            UpdateAnimator();
        }

        /// <summary>
        /// Moves player to passed location with provided speedFraction using the NavMeshAgent class.
        /// </summary>
        /// <param name="destination">Destination point.</param>
        /// <param name="speedFraction">Controls the speed of the player (with animation speed).</param>
        public void MoveTo(Vector3 destination, float speedFraction)
        {
            _navMeshAgent.destination = destination;
            _navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = _navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat(ForwardSpeed, speed);
        }
    }
}
