using UnityEngine;

namespace Frognar {
  public class Explosion : MonoBehaviour {
    Factorable factorable;

    void Awake() {
      factorable = GetComponent<Factorable>();
    }

    void OnParticleSystemStopped() {
      factorable.ReturnToFactory();
    }
  }
}
