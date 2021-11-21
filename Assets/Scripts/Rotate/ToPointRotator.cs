using UnityEngine;

namespace Frognar {
  public class ToPointRotator : MonoBehaviour, Rotate {
    Vector3 pointInWorld;

    public void SetPoint(Vector3 point) {
      pointInWorld = point;
    }

    void Update() {
      Vector3 direction = pointInWorld - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
      transform.rotation = rotation;
    }
  }
}