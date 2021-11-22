using UnityEngine;

namespace Frognar {
  public class RangedEnemy : Enemy {
    [SerializeField] Transform shotPoint;
    [SerializeField] ProjectileFactory projectileFactory;
    Animator animator;

    protected override void Awake() {
      base.Awake();
      animator = GetComponent<Animator>();
    }

    protected override void DoAttack() {
      animator.SetTrigger("attack");
    }

    public void Shot() {
      projectileFactory.GetProduct(shotPoint.position, shotPoint.rotation);
    }
  }
}
