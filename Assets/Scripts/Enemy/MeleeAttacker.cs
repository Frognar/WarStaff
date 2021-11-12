using System.Collections;
using UnityEngine;

namespace Frognar {
  public class MeleeAttacker : Attacker {
    [SerializeField] FloatVariable attackSpeed;
    [SerializeField] IntVariable damage;

    protected override void Attack() {
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