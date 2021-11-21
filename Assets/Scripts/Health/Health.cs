using UnityEngine;

namespace Frognar {
  public class Health : MonoBehaviour, Damageable {
    public event HealthSystem.onDie OnDie;
    HealthSystem healthSystem;
    [SerializeField] IntVariable maxHealth;
    HealthBar healthBar;

    public void TakeDamage(int amount) {
      healthSystem.TakeDamage(amount);
    }

    public void Reset() {
      healthSystem.Reset();
    }

    void Awake() {
      healthSystem = new HealthSystem(maxHealth.Value);
      healthBar = GetComponentInChildren<HealthBar>();
      healthBar.SetHealthSystem(healthSystem);
      healthSystem.OnDie += OnDie;
    }
  }
}
