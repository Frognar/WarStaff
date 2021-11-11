using System.Collections;
using UnityEngine;

namespace Frognar {
  public class MeleeAttacker : MonoBehaviour {
    Transform target;
    TargetFinder targetFinder;
    [SerializeField] int damage;
    [SerializeField] float attackDistance;
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] float attackSpeed;
    float attackTime;

    void Awake() {
      targetFinder = GetComponent<TargetFinder>();
    }

    void Start() {
      target = targetFinder.FindTarget();
    }

    void Update() {
      if (target != null) {
        if (Vector3.Distance(transform.position, target.position) <= attackDistance) {
          if (Time.time >= attackTime) {
            StartCoroutine(Attack());
            attackTime = Time.time + timeBetweenAttacks;
          }
        }
      }
    }

    IEnumerator Attack() {
      target.GetComponent<Damageable>()?.TakeDamage(damage);
      Vector2 originalPosition = transform.position;
      Vector2 targetPosition = target.position;

      float percent = 0;
      while (percent <= 1) {
        percent += Time.deltaTime * attackSpeed;
        float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
        transform.position = Vector3.Lerp(originalPosition, targetPosition, formula);
        yield return null;
      }
    }
  }
}