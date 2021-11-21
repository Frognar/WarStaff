using UnityEngine;

namespace Frognar {
  [CreateAssetMenu(fileName = "floatVariable", menuName = "Variables/FloatVariable")]
  public class FloatVariable : ScriptableObject {
    [SerializeField] float value;
    public float Value => value;
  }
}
