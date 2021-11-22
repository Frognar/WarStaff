using System.Collections;
using UnityEngine;

namespace Frognar {
  public class MeleeEnemy : Enemy {
    HitAndRun hitAndRun;

    protected override void Start() {
      base.Start();
      hitAndRun = GetComponent<HitAndRun>();
      hitAndRun.SetTarget(target);
    }

    protected override void DoAttack() {
      hitAndRun.Attack();
    }
  }
}
