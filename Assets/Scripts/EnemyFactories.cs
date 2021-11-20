using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Frognar{
  [CreateAssetMenu()]
  public class EnemyFactories : SerializedScriptableObject {
    public Dictionary<EnemyType, Factory> factories = new Dictionary<EnemyType, Factory>();
  }
}
