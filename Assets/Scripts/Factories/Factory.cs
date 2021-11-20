using System.Collections.Generic;
using UnityEngine;

namespace Frognar {
  [CreateAssetMenu()]
  public class Factory : ScriptableObject {
    public Factorable productReceipt;
    readonly Stack<Factorable> products = new Stack<Factorable>();

    public void MakePdoructs(int count = 10) {
      for (int i = 0; i < count; i++) {
        MakeProduct();
      }
    }

    public void MakeProduct() {
      Factorable product = CreateProduct(Vector3.zero, Quaternion.identity);
      StoreProduct(product);
    }

    public Factorable GetProduct(Vector3 position, Quaternion rotation) {
      if (products.Count > 0) {
        return ReuseProduct(position, rotation);
      }
      else {
        return CreateProduct(position, rotation);
      }
    }

    Factorable ReuseProduct(Vector3 position, Quaternion rotation) {
      Factorable product = products.Pop();
      product.transform.position = position;
      product.transform.rotation = rotation;
      product.gameObject.SetActive(true);
      return product;
    }

    Factorable CreateProduct(Vector3 position, Quaternion rotation) {
      Factorable product = Instantiate(productReceipt, position, rotation);
      product.SetFactory(this);
      return product;
    }

    public void ReturnProduct(Factorable product) {
      StoreProduct(product);
    }

    void StoreProduct(Factorable product) {
      product.gameObject.SetActive(false);
      products.Push(product);
    }
  }
}
