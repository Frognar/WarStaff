using System.Collections;
using UnityEngine;

namespace Frognar {
  public class HitAndRun : MonoBehaviour {
    [SerializeField] FloatVariable attackSpeed;
    [SerializeField] IntVariable damage;
    Transform targetTransform;
    Damageable target;

    public void SetTarget(Transform target) {
      targetTransform = target;
      this.target = target.GetComponent<Damageable>();
    }

    public void Attack() {
      target.TakeDamage(damage.Value);
      StartCoroutine(RunAttackAnimation(transform.position, targetTransform.position));
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
