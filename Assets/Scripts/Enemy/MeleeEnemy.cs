using UnityEngine;

namespace Frognar
{
  public class MeleeEnemy : Movement {
    TargetFinder targetFinder;
    MeleeAttacker meleeAttacker;

    protected override void Awake() {
      base.Awake();
      targetFinder = GetComponent<TargetFinder>();
      meleeAttacker = GetComponent<MeleeAttacker>();
    }

    void Start() {
      meleeAttacker.SetTarget(targetFinder.FindTarget());
    }
  }
}
