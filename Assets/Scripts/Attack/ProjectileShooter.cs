using UnityEngine;

namespace Frognar {
  public class ProjectileShooter : MonoBehaviour, Attack {
    [SerializeField] Transform shotPoint;
    [SerializeField] ProjectileShooterData data;
    [SerializeField] ProjectileFactory projectileFactory;
    float shotTime;

    void Awake() {
      SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
      spriteRenderer.sprite = data.Sprite;
      projectileFactory.SetProjectileData(data.ProjectileData);
    }

    public void Attack() {
      if (Time.time >= shotTime) {
        projectileFactory.GetProduct(shotPoint.position, transform.rotation);
        shotTime = Time.time + data.TimeBetwenShots;
      }
    }
  }
}