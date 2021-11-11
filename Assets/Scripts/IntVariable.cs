using UnityEngine;

namespace Frognar {
  [CreateAssetMenu (fileName = "intVariable", menuName = "IntVariable")]
  public class IntVariable : ScriptableObject {
    [SerializeField] private int value;
    public int Value => value;
  }
}
