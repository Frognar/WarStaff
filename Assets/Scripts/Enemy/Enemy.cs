using UnityEngine;

namespace Frognar {
  public class Enemy : Movement, Damageable, Factorable {
    HealthSystem healthSystem;
    [SerializeField] IntVariable maxHealth;
    [SerializeField] EnemyFactory enemyFactory;
    HealthBar healthBar;

    public void TakeDamage(int amount) {
      healthSystem.TakeDamage(amount);
    }

    public void Reset() {
      healthSystem.Reset();
    }

    protected override void Awake() {
      base.Awake();
      healthSystem = new HealthSystem(maxHealth.Value);
      healthBar = GetComponentInChildren<HealthBar>();
      healthBar.SetHealthSystem(healthSystem);
      healthSystem.OnDie += (s, e) => ReturnToFactory();
    }

    public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, Factorable {
      enemyFactory = factory as EnemyFactory;
    }

    public void ReturnToFactory() {
      enemyFactory.ReturnProduct(this);
    }
  }
}
