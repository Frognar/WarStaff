using UnityEngine;

namespace Frognar {
  public class Projectile : MonoBehaviour {
    [SerializeField] ProjectileData data;
    [SerializeField] Factory factory;
    Factorable factorable;

    void Awake() {
      factorable = GetComponent<Factorable>();
      SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
      spriteRenderer.sprite = data.Sprite;
    }

    void OnEnable() {
      Invoke("DestroyProjectile", data.LiveTime);
    }

    void Update() {
      transform.Translate(Vector2.up * (data.Speed * Time.deltaTime));
    }

    void DestroyProjectile() {
      CancelInvoke("DestroyProjectile");
      factorable.ReturnToFactory();
      Factorable product = factory.GetProduct(transform.position, Quaternion.identity);
      ParticleSystem explosion = product.GetComponent<ParticleSystem>();
      explosion.Play();
    }

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag(data.TargetTag)) {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null) {
          damageable.TakeDamage(data.Damage);
          DestroyProjectile();
        }
      }
    }
  }
}