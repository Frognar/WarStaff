using UnityEngine;

namespace Frognar {
  public class ToPointRotator : MonoBehaviour {
    PointInWorld pointInWorld;

    void Awake() {
      pointInWorld = GetComponent<PointInWorld>();
    }

    void Update() {
      Vector3 direction = pointInWorld.Point - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
      transform.rotation = rotation;
    }
  }
}