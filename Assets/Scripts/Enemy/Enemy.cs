using UnityEngine;

namespace Frognar {
  public abstract class Enemy : MonoBehaviour, Factorable {
    [SerializeField] EnemyFactory enemyFactory;
    [SerializeField] FloatVariable attackDistance;
    [SerializeField] FloatVariable timeBetweenAttacks;
    Health health;
    TargetFinder targetFinder;
    float attackTime;
    protected Transform target;

    protected bool HasTarget => target != null;
    bool InRange => Vector3.Distance(transform.position, target.position) <= attackDistance.Value;
    bool TimeToAttack => Time.time >= attackTime;
    protected virtual bool CanAttack => HasTarget && InRange && TimeToAttack;

    protected virtual void Awake() {
      health = GetComponent<Health>();
      targetFinder = GetComponent<TargetFinder>();
    }

    protected virtual void Start() {
      target = targetFinder.FindTarget();
      health.RegisterOnDie(ReturnToFactory);
    }

    protected virtual void Update() {
      if (CanAttack) {
        Attack();
      }
    }

    void Attack() {
      DoAttack();
      attackTime = Time.time + timeBetweenAttacks.Value;
    }

    protected abstract void DoAttack();

    public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, Factorable {
      enemyFactory = factory as EnemyFactory;
    }

    public void ReturnToFactory() {
      enemyFactory.ReturnProduct(this);
    }
  }
}
