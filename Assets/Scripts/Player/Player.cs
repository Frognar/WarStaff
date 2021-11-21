using UnityEngine;

namespace Frognar {
  public class Player : MonoBehaviour {
    Health health;

    void Awake() {
      health = GetComponent<Health>();
      health.OnDie += () => Destroy(gameObject);
    }
  }
}