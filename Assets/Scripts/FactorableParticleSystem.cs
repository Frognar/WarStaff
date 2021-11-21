using UnityEngine;

namespace Frognar {
  public class FactorableParticleSystem : MonoBehaviour, Factorable {
    ParticleSystemFactory factory;
    ParticleSystem particles;

    void Awake() {
      particles = GetComponent<ParticleSystem>();  
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
