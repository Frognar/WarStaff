using UnityEngine;

namespace Frognar {
  public class Projectile : MonoBehaviour, Factorable {
    ProjectileFactory projectileFactory;
    [SerializeField] ProjectileData data;

    public void ReturnToFactory() {
      projectileFactory.ReturnProduct(this);
    }

    public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, Factorable {
      this.projectileFactory = factory as ProjectileFactory;
    }

    void Awake() {
      var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
      spriteRenderer.sprite = data.Sprite;
    }

    void Update() {
      transform.Translate(Vector2.up * (data.Speed * Time.deltaTime));
    }

    void OnEnable() {
      Invoke("DestroyProjectile", data.LiveTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag(data.TargetTag)) {
        var damageable = other.GetComponent<Damageable>();
        if (damageable != null) {
          damageable.TakeDamage(data.Damage);
          DestroyProjectile();
        }
      }
    }

    void DestroyProjectile() {
      CancelInvoke("DestroyProjectile");
      var particleSystem = data.ParticleSystemFactory.GetProduct(transform.position, Quaternion.identity);
      particleSystem.Play();
      ReturnToFactory();
    }
  }
}
