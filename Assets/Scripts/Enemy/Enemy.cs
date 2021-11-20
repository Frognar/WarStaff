using UnityEngine;

namespace Frognar {
  public class Enemy : Movement, Damageable {
    HealthSystem healthSystem;
    [SerializeField] IntVariable maxHealth;
    HealthBar healthBar;
    Factorable factorable;

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
      factorable = GetComponent<Factorable>();
      healthSystem.OnDie += (s, e) => factorable.ReturnToFactory();
    }
  }
}
