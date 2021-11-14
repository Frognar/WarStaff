using UnityEngine;

namespace Frognar {
  [CreateAssetMenu (fileName = "floatVariable", menuName = "FloatVariable")]
  public class FloatVariable : ScriptableObject {
    [SerializeField] private float value;
    public float Value => value;
  }
}
