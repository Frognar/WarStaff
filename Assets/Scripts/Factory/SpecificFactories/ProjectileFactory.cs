using UnityEngine;

namespace Frognar {
  [CreateAssetMenu(fileName = "Projectile Factory", menuName = "Factory/Projectile Factory")]
  public class ProjectileFactory : Factory<Projectile> {
    ProjectileData data;

    public void SetProjectileData(ProjectileData data) {
      this.data = data;
    }

    public override Projectile GetProduct(Vector3 position, Quaternion rotation) {
      var product = base.GetProduct(position, rotation);
      if (data != null) {
        product.SetProjectileData(data);
      }
      return product;
    }
  }
}
