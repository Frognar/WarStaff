using UnityEngine;

namespace Frognar {
  public class Player : Movement, Damageable {
    HealthSystem healthSystem;
    [SerializeField] IntVariable maxHealth;
    HealthBar healthBar;

    public void TakeDamage(int amount) {
      healthSystem.TakeDamage(amount);
    }

    protected override void Awake() {
      base.Awake();
      healthSystem = new HealthSystem(maxHealth.Value);
      healthBar = GetComponentInChildren<HealthBar>();
      healthBar.SetHealthSystem(healthSystem);
      healthSystem.OnDie += (s, e) => Destroy(gameObject);
    }
  }
}