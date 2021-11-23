using UnityEngine;

namespace Frognar {
  [CreateAssetMenu(fileName = "Particle System Factory", menuName = "Factory/Particle System Factory")]
  public class ParticleSystemFactory : Factory<FactorableParticleSystem> {
    ParticleSystem.MinMaxGradient startColor;
    Color color;

    public void SetParticleSystemColors(ParticleSystem.MinMaxGradient startColor, Color color) {
      this.startColor = startColor;
      this.color = color;
    }

    public override FactorableParticleSystem GetProduct(Vector3 position, Quaternion rotation) {
      var product = base.GetProduct(position, rotation);
      product.SetParticleSystemColors(startColor, color);
      return product;
    }
  }
}
