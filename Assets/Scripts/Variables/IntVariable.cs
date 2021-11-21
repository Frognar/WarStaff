using UnityEngine;

namespace Frognar {
  [CreateAssetMenu(fileName = "intVariable", menuName = "Variables/IntVariable")]
  public class IntVariable : ScriptableObject {
    [SerializeField] int value;
    public int Value => value;
  }
}
