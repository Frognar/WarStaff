using UnityEngine;

namespace Frognar {
  public class Factorable : MonoBehaviour {
    Factory factory;

    public void SetFactory(Factory factory) {
      this.factory = factory;
    }

    public void ReturnToFactory() {
      factory.ReturnProduct(this);
    }
  }
}
