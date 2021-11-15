using UnityEngine;

namespace Frognar {
  public class Projectile : MonoBehaviour {
    [SerializeField] ProjectileData data;
    Pool<Projectile> pool;

    public void SetPool(Pool<Projectile> pool) {
      this.pool = pool;
    }

    void Awake() {
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
      pool.Release(this);
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