using UnityEngine;

namespace Frognar {
  public class PlayerMovementKeys : MonoBehaviour {
    MoveVelocity moveVelocity;

    void Awake() {
      moveVelocity = GetComponent<MoveVelocity>();  
    }

    void Update() {
      var velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
      moveVelocity.SetVelocity(velocity);
    }
  }
}
