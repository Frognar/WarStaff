using System.Collections.Generic;
using UnityEngine;

namespace Frognar {
  public class Pool<T> where T : MonoBehaviour {
    Stack<T> pool;

    public delegate T OnCreate();
    OnCreate create;

    public delegate T OnGet(T instance);
    OnGet get;

    public delegate void OnRelease(T instance);
    OnRelease release;

    public Pool(OnCreate create, OnGet get, OnRelease release) {
      this.create = create;
      this.get = get;
      this.release = release;
      pool = new Stack<T>();
    }

    public T Get() {
      return pool.Count > 0 ? get(pool.Pop()) : create();
    }

    public void Release(T obj) {
      release(obj);
      pool.Push(obj);
    }
  }
}
