using UnityEngine;

public class Enemy : MonoBehaviour, Damageable {
  [SerializeField] int health;

  public void TakeDamage(int damageAmount) {
    health -= damageAmount;

    if (health <= 0) {
      Destroy(gameObject);
    }
  }
}
