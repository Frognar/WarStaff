using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Frognar{
  [CreateAssetMenu()]
  public class EnemyPoolData : SerializedScriptableObject {
    public Dictionary<EnemyType, Enemy> enemies = new Dictionary<EnemyType, Enemy>();
  }
}
