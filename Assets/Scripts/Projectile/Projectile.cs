using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Frognar {
  public class Projectile : MonoBehaviour, Factorable {
    ProjectileFactory projectileFactory;
    SpriteRenderer spriteRenderer;
    Light2D light2d;
    [SerializeField] ProjectileData data;
    [SerializeField] ParticleSystemFactory particleSystemFactory;

    public void ReturnToFactory() {
      projectileFactory.ReturnProduct(this);
    }

    public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, Factorable {
      this.projectileFactory = factory as ProjectileFactory;
    }

    public void SetProjectileData(ProjectileData data) {
      this.data = data;
      spriteRenderer.sprite = data.Sprite;
      light2d.color = data.LightColor;
      light2d.intensity = data.LightIntensity;
      particleSystemFactory.SetParticleSystemColors(data.ExplosionColor, data.LightColor);
    }

    void Awake() {
      spriteRenderer = GetComponentInChildren<SpriteRenderer>();
      light2d = GetComponentInChildren<Light2D>();
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
      var particleSystem = particleSystemFactory.GetProduct(transform.position, Quaternion.identity);
      particleSystem.Play();
      ReturnToFactory();
    }
  }
}
