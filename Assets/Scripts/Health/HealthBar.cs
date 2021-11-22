using UnityEngine;

namespace Frognar {
  public class HealthBar : MonoBehaviour {
    [SerializeField] Transform barHandler;
    HealthSystem healthSystem;

    public void SetHealthSystem(HealthSystem healthSystem) {
      this.healthSystem = healthSystem;
      healthSystem.OnTakeDamage += UpdateHealthBar;
      healthSystem.OnHeal += UpdateHealthBar;
    }

    void UpdateHealthBar() {
      barHandler.localScale = new Vector3(healthSystem.GetHealthPercentage(), 1);
    }
  }
}
