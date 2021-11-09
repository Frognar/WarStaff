using System;
using UnityEngine;

public class MouseController : MonoBehaviour, PointInWorld, ActionTrigger {
  Camera mainCamera;
  public event EventHandler ShotTrigger;

  void Awake() {
    mainCamera = Camera.main;
  }

  public Vector3 Point { get; private set; }

  void Update() {
    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z);
    Point = mainCamera.ScreenToWorldPoint(mousePosition);

    if (Input.GetMouseButton(0)) {
      ShotTrigger?.Invoke(this, EventArgs.Empty);
    }
  }
}
