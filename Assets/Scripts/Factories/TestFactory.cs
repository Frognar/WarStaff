using System.Collections;
using UnityEngine;

namespace Frognar {
  public class TestFactory : MonoBehaviour {
    [SerializeField] Factory factory;
    Factorable product;
    bool spawning = false;

    void Start() {
      StartCoroutine(SpawnNext());
    }

    void Update() {
      if (product == null) {
        return;
      }

      if (!product.gameObject.activeSelf && !spawning) {
        spawning = true;
        StartCoroutine(SpawnNext());
      }
    }

    IEnumerator SpawnNext() {
      yield return new WaitForSeconds(2);
      product = factory.GetProduct(transform.position, transform.rotation);
      product.GetComponent<SimpleEnemy>().Reset();
      spawning = false;
    }
  }
}
