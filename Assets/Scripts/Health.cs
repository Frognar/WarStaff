using System;
using UnityEngine;

namespace Frognar {
  public class Health : MonoBehaviour, Damageable {
    [SerializeField] IntVariable maxHealth;
    public EventHandler OnDeath;
    int health;

    void Start() {
      Reset();
    }

    public void Reset() {
      health = maxHealth.Value;
    }

    public void TakeDamage(int amount) {
      health -= amount;
      if (health <= 0) {
        OnDeath?.Invoke(this, EventArgs.Empty);
      }
    }
  }
}