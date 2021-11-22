using UnityEngine;

namespace Frognar {
  public class Player : MonoBehaviour {
    Health health;

    void Awake() {
      health = GetComponent<Health>();
      health.RegisterOnDie(() => Destroy(gameObject));
    }
  }
}