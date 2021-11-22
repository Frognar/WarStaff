using UnityEngine;

namespace Frognar {
  public class Health : MonoBehaviour, Damageable {
    [SerializeField] IntVariable maxHealth;
    HealthSystem healthSystem;
    HealthBar healthBar;

    void Awake() {
      healthSystem = new HealthSystem(maxHealth.Value);
      healthBar = GetComponentInChildren<HealthBar>();
      healthBar.SetHealthSystem(healthSystem);
    }

    public void TakeDamage(int amount) {
      healthSystem.TakeDamage(amount);
    }

    public void RegisterOnDie(HealthSystem.onDie action) {
      healthSystem.OnDie += action;
    }

    void OnEnable() {
      healthSystem.Reset();
    }
  }
}
