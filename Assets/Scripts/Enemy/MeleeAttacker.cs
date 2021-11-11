using System.Collections;
using UnityEngine;

namespace Frognar {
  public class MeleeAttacker : MonoBehaviour {
    Transform target;
    [SerializeField] IntVariable damage;
    [SerializeField] FloatVariable attackDistance;
    [SerializeField] FloatVariable timeBetweenAttacks;
    [SerializeField] FloatVariable attackSpeed;
    float attackTime;
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

    void Attack() {
      target.GetComponent<Damageable>()?.TakeDamage(damage.Value);
      StartCoroutine(RunAttackAnimation(transform.position, target.position));
      attackTime = Time.time + timeBetweenAttacks.Value;
    }

    IEnumerator RunAttackAnimation(Vector2 originalPosition, Vector2 targetPosition) {
      float percent = 0;
      while (percent <= 1) {
        percent += Time.deltaTime * attackSpeed.Value;
        float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
        transform.position = Vector3.Lerp(originalPosition, targetPosition, formula);
        yield return null;
      }
    }
  }
}