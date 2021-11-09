using UnityEngine;

public class Projectile : MonoBehaviour {
  [SerializeField] float speed;
  [SerializeField] int damageAmount;
  [SerializeField] float lifeTime;
  [TagSelector] [SerializeField] string targetTag;
  [SerializeField] GameObject explosion;

  void Start() {
    Invoke("DestroyProjectile", lifeTime);
  }

  void Update() {
    transform.Translate(Vector2.up * (speed * Time.deltaTime));
  }

  void DestroyProjectile() {
    Destroy(gameObject);
    Instantiate(explosion, transform.position, Quaternion.identity);
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(targetTag)) {
      Damageable damageable = other.GetComponent<Damageable>();
      if (damageable != null) {
        damageable.TakeDamage(damageAmount);
        DestroyProjectile();
      }
    }
  }
}
