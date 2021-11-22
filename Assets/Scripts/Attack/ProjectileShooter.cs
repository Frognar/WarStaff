using UnityEngine;

namespace Frognar {
  public class ProjectileShooter : MonoBehaviour, Attack {
    [SerializeField] Transform shotPoint;
    [SerializeField] FloatVariable timeBetwenShots;
    [SerializeField] ProjectileFactory projectileFactory;
    float shotTime;

    public void Attack() {
      if (Time.time >= shotTime) {
        projectileFactory.GetProduct(shotPoint.position, transform.rotation);
        shotTime = Time.time + timeBetwenShots.Value;
      }
    }
  }
}