using UnityEngine;

namespace Frognar {
  public class RangedAttacker : Attacker {
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shotPoint;
    Animator animator;

    void Awake() {
      animator = GetComponent<Animator>();
    }

    protected override void Attack() {
      Debug.Log("attack");
      animator.SetTrigger("attack");
      attackTime = Time.time + timeBetweenAttacks.Value;
    }

    public void Shot() {
      Instantiate(projectile, shotPoint.position, shotPoint.rotation);
    }
  }
}
