using UnityEngine;

namespace Frognar {
  public class Health : MonoBehaviour, Damageable {
    [SerializeField] int health;

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