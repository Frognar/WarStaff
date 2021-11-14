using UnityEngine;

namespace Frognar {
  public class Health : MonoBehaviour, Damageable {
    [SerializeField] IntVariable maxHealth;
    int health;

    void Start() {
      health = maxHealth.Value;
    }

    public void TakeDamage(int amount) {
      health -= amount;
      if (health <= 0) {
        Die();
      }
    }

    void Die() {
      Destroy(gameObject);
    }
  }
}