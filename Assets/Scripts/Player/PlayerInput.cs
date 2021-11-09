using UnityEngine;

public class PlayerInput : MonoBehaviour, MoveDirection {
  public Vector2 MoveDirection { get; private set; }

  void Update() {
    MoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
  }
}
