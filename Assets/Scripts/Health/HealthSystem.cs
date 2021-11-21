namespace Frognar {
  public class HealthSystem : Damageable, Healable {
    public delegate void onTakeDamage();
    public event onTakeDamage OnTakeDamage;
    public delegate void onHeal();
    public event onHeal OnHeal;
    public delegate void onDie();
    public event onDie OnDie;
    readonly int maxHealth;
    int health;
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
        OnTakeDamage?.Invoke();
      }
    }

    void Die() {
      dead = true;
      health = 0;
      OnDie?.Invoke();
    }

    public void Heal(int amount) {
      health += amount;
      if (health > maxHealth) {
        health = maxHealth;
      }
      OnHeal?.Invoke();
    }
  }
}
