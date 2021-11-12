using UnityEngine;

namespace Frognar {
    public class RandomPointFinder : MonoBehaviour, MoveDirection {
        public Vector2 Direction { get; private set; }
        Vector2 targetPosition;
        [SerializeField] float boundMaxX;
        [SerializeField] float boundMinX;
        [SerializeField] float boundMaxY;
        [SerializeField] float boundMinY;
        bool targetReached;

        void Awake() {
            float randomX = Random.Range(boundMinX, boundMaxX);
            float randomY = Random.Range(boundMinY, boundMaxY);
            targetPosition = new Vector2(randomX, randomY);
        }

        void Update() {
            if (targetReached) {
                return;
            }
            if (Vector2.Distance(transform.position, targetPosition) > .5f) {
                Direction = (targetPosition - (Vector2)transform.position).normalized;
            }
            else
            {
                targetReached = true;
                Direction = Vector2.zero;
            }
        }
    }
}