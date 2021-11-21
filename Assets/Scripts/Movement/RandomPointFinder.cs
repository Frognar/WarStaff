using UnityEngine;

namespace Frognar {
  public class RandomPointFinder : MonoBehaviour {
    MoveVelocity moveVelocity;
    Vector2 targetPosition;
    [SerializeField] float boundMaxX;
    [SerializeField] float boundMinX;
    [SerializeField] float boundMaxY;
    [SerializeField] float boundMinY;
    bool targetReached;
    public bool TargetReached => targetReached;

    void Awake() {
      moveVelocity = GetComponent<MoveVelocity>();
      float randomX = Random.Range(boundMinX, boundMaxX);
      float randomY = Random.Range(boundMinY, boundMaxY);
      targetPosition = new Vector2(randomX, randomY);
    }

    void Update() {
      targetReached = Vector2.Distance(transform.position, targetPosition) < .5f;
      if (targetReached) {
        moveVelocity.SetVelocity((targetPosition - (Vector2)transform.position).normalized);
      }
      else {
        moveVelocity.SetVelocity(Vector2.zero);
      }
    }
  }
}