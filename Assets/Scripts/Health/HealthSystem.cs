using System;

namespace Frognar {
  public class HealthSystem : Damageable, Healable {
    public event EventHandler OnTakeDamage;
    public event EventHandler OnHeal;
    public event EventHandler OnDie;
    int health;
    int maxHealth;
    bool dead;

    public HealthSystem(int maxHealth) {
      this.maxHealth = maxHealth;
      health = maxHealth;
    }

    public void Reset() {
      Heal(maxHealth);
      dead = false;
    }

    public int GetHealth() => health;
    public float GetHealthPercentage() => health / (float)maxHealth;

    public void TakeDamage(int amount) {
      health -= amount;
      if (!dead && health <= 0) {
        Die();
      }
      else {
        OnTakeDamage?.Invoke(this, EventArgs.Empty);
      }
    }

    void Die() {
      dead = true;
      health = 0;
      OnDie?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(int amount) {
      health += amount;
      if (health > maxHealth) {
        health = maxHealth;
      }
      OnHeal?.Invoke(this, EventArgs.Empty);
    }
  }
}
