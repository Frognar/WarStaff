using UnityEngine;

namespace Frognar {
  public class Projectile : MonoBehaviour {
    [SerializeField] FloatVariable speed;
    [SerializeField] IntVariable damageAmount;
    [SerializeField] FloatVariable lifeTime;
    [TagSelector] [SerializeField] string targetTag;
    [SerializeField] GameObject explosion;

    void Start() {
      Invoke("DestroyProjectile", lifeTime.Value);
    }

    void Update() {
      transform.Translate(Vector2.up * (speed.Value * Time.deltaTime));
    }

    void DestroyProjectile() {
      Destroy(gameObject);
      Instantiate(explosion, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag(targetTag)) {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null) {
          damageable.TakeDamage(damageAmount.Value);
          DestroyProjectile();
        }
      }
    }
  }
}