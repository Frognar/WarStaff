using UnityEngine;

namespace Frognar {
  public class RangedAttacker : Attacker {
    [SerializeField] Transform shotPoint;
    [SerializeField] ProjectileFactory projectileFactory;
    Animator animator;

    void Awake() {
      animator = GetComponent<Animator>();
    }

    protected override void Attack() {
      animator.SetTrigger("attack");
      attackTime = Time.time + timeBetweenAttacks.Value;
    }

    public void Shot() {
      projectileFactory.GetProduct(shotPoint.position, shotPoint.rotation);
    }
  }
}
