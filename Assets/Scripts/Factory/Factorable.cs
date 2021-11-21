using UnityEngine;

namespace Frognar {
  public interface Factorable {
    void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, Factorable;
    void ReturnToFactory();
  }
}
