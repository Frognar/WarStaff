using System;
using UnityEngine;

namespace Frognar {
  public class HealthBar : MonoBehaviour {
    HealthSystem healthSystem;
    Transform barHandler;

    void Awake() {
      barHandler = transform.Find("BarHandler");
    }

    public void SetHealthSystem(HealthSystem healthSystem) {
      this.healthSystem = healthSystem;
      healthSystem.OnTakeDamage += UpdateHealthBar;
      healthSystem.OnHeal += UpdateHealthBar;
    }

    void UpdateHealthBar(object sender, EventArgs e) {
      if (barHandler != null) {
        barHandler.localScale = new Vector3(healthSystem.GetHealthPercentage(), 1);
      }
    }
  }
}
