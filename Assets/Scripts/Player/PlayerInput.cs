using UnityEngine;

namespace Frognar {
  public class PlayerInput : MonoBehaviour, MoveDirection {
    public Vector2 Direction { get; private set; }

    void Update() {
      Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
  }
}
