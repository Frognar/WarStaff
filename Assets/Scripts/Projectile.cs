using UnityEngine;

namespace Frognar {
  public class Projectile : MonoBehaviour {
    [SerializeField] ProjectileData data;

    void Awake() {
      SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
      spriteRenderer.sprite = data.Sprite;
    }

    void Start() {
      Invoke("DestroyProjectile", data.LiveTime);
    }

    void Update() {
      transform.Translate(Vector2.up * (data.Speed * Time.deltaTime));
    }

    void DestroyProjectile() {
      Destroy(gameObject);
      Instantiate(data.HitEffect, transform.position, Quaternion.identity);
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