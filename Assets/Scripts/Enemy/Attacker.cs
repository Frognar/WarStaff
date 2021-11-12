using UnityEngine;

namespace Frognar {
  public abstract class Attacker : MonoBehaviour {
    protected Transform target;
    [SerializeField] FloatVariable attackDistance;
    [SerializeField] protected FloatVariable timeBetweenAttacks;
    protected float attackTime;
    bool canAttack = true;

    public void SetTarget(Transform target) {
      this.target = target;
    }

    public void DisableAttacks() {
      canAttack = false;
    }

    public void EnableAttacks() {
      canAttack = true;
    }

    void Update() {
      if (CanAttack()) {
        Attack();
      }
    }

    bool CanAttack() {
      if (canAttack == false || target == null) {
        return false;
      }
      float distanceToTarger = Vector3.Distance(transform.position, target.position);
      bool inRange = distanceToTarger <= attackDistance.Value;
      bool timeToAttack = Time.time >= attackTime;
      return inRange && timeToAttack;
    }

    protected abstract void Attack();
  }
}
