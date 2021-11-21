using UnityEngine;

namespace Frognar {
  public class PlayerMousePosition : MonoBehaviour {
    Camera mainCamera;
    Rotate rotate;

    void Awake() {
      mainCamera = Camera.main;
      rotate = GetComponent<Rotate>();
    }

    void Update() {
      Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z);
      rotate.SetPoint(mainCamera.ScreenToWorldPoint(mousePosition));
    }
  }
}
