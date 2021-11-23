using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Frognar {
  public class FactorableParticleSystem : MonoBehaviour, Factorable {
    ParticleSystemFactory factory;
    ParticleSystem particles;
    ParticleSystem.MainModule mainModule;
    Light2D light;

    void Awake() {
      particles = GetComponent<ParticleSystem>();
      mainModule = particles.main;
      light = GetComponentInChildren<Light2D>();
    }

    public void SetParticleSystemColors(ParticleSystem.MinMaxGradient startColor, Color color) {
      mainModule.startColor = startColor;
      light.color = color;
    }

    public void ReturnToFactory() {
      factory.ReturnProduct(this);
    }

    public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, Factorable {
      this.factory = factory as ParticleSystemFactory;
    }

    void OnParticleSystemStopped() {
      ReturnToFactory();
    }

    public void Play() {
      particles.Play();
    }
  }
}
