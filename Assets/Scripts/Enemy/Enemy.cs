using UnityEngine;

namespace Frognar {
  public class Enemy : MonoBehaviour, Factorable {
    [SerializeField] EnemyFactory enemyFactory;
    Health health;
    protected TargetFinder targetFinder;
    protected Attacker attacker;

    protected virtual void Awake() {
      health = GetComponent<Health>();
      health.OnDie += ReturnToFactory;
      targetFinder = GetComponent<TargetFinder>();
      attacker = GetComponent<Attacker>();
    }

    void Start() {
      attacker.SetTarget(targetFinder.FindTarget());
    }

    public void Reset() {
      health.Reset();
    }

    public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, Factorable {
      enemyFactory = factory as EnemyFactory;
    }

    public void ReturnToFactory() {
      enemyFactory.ReturnProduct(this);
    }
  }
}
