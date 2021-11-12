using UnityEngine;

namespace Frognar {
  public class TargetAsPoint : MonoBehaviour, PointInWorld {
    public Vector3 Point { get; private set; }
    TargetFinder targetFinder;
    
    void Awake() {
      targetFinder = GetComponentInParent<TargetFinder>();
    }

    void Update() {
      if (targetFinder.HasTarget()){
        Point = targetFinder.FindTarget().position;
      }
      else {
        Point = Vector3.zero;
      }
    }
  }
}
