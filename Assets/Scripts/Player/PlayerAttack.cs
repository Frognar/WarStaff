using UnityEngine;

namespace Frognar {
  public class PlayerAttack : MonoBehaviour {
    Attack attack;

    void Awake() {
      attack = GetComponent<Attack>();
    }

    void Update() {
      if (Input.GetMouseButton(0)) {
        attack.Attack();
      }
    }
  }
}
