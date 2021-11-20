using UnityEngine;

namespace Frognar {
  public class Enemy : Movement, Damageable {
    HealthSystem healthSystem;
    [SerializeField] IntVariable maxHealth;
    HealthBar healthBar;
    Pool<Enemy> pool;

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
      healthSystem.OnDie += (s, e) => pool.Release(this);
    }

    public void SetPool(Pool<Enemy> pool) {
      this.pool = pool;
    }
  }
}
