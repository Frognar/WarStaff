using UnityEngine;

namespace Frognar {
  [CreateAssetMenu (fileName = "floatVariable", menuName = "FloatVariable")]
  public class FloatVariable : ScriptableObject {
    [SerializeField] private float value = 5f;
    public float Value => value;
  }
}
