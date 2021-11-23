using System.Collections.Generic;
using UnityEngine;

namespace Frognar {
  public abstract class Factory<T> : ScriptableObject
    where T : MonoBehaviour, Factorable {
    [SerializeField] T productReceipt;
    readonly Stack<T> products = new Stack<T>();

    public void MakePdoructs(int count = 10) {
      for (int i = 0; i < count; i++) {
        MakeProduct();
      }
    }

    public void MakeProduct() {
      T product = CreateProduct(Vector3.zero, Quaternion.identity);
      StoreProduct(product);
    }

    T CreateProduct(Vector3 position, Quaternion rotation) {
      T product = Instantiate(productReceipt, position, rotation);
      product.SetFactory(this);
      return product;
    }

    void StoreProduct(T product) {
      product.gameObject.SetActive(false);
      products.Push(product);
    }

    public virtual T GetProduct(Vector3 position, Quaternion rotation) {
      if (products.Count > 0) {
        return ReuseProduct(position, rotation);
      }
      else {
        return CreateProduct(position, rotation);
      }
    }

    T ReuseProduct(Vector3 position, Quaternion rotation) {
      T product = products.Pop();
      product.transform.position = position;
      product.transform.rotation = rotation;
      product.gameObject.SetActive(true);
      return product;
    }

    public void ReturnProduct(T product) {
      StoreProduct(product);
    }
  }
}
