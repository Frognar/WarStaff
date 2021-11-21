using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Frognar {
  [CreateAssetMenu(fileName = "Enemy Factories", menuName = "Factory/Enemy Factories")]
  public class EnemyFactories : SerializedScriptableObject {
    public Dictionary<EnemyType, EnemyFactory> factories = new Dictionary<EnemyType, EnemyFactory>();
  }
}
