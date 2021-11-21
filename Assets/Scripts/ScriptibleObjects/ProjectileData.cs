using Sirenix.OdinInspector;
using UnityEngine;

namespace Frognar {
  [CreateAssetMenu()]
  public class ProjectileData : ScriptableObject {
    [PreviewField(60), HideLabel]
    [HorizontalGroup("Split", 60)]
    [SerializeField] Sprite sprite;
    public Sprite Sprite => sprite;

    [VerticalGroup("Split/Right"), LabelWidth(80)]
    [SerializeField] int damage;
    public int Damage => damage;

    [VerticalGroup("Split/Right"), LabelWidth(80)]
    [SerializeField] float liveTime;
    public float LiveTime => liveTime;

    [VerticalGroup("Split/Right"), LabelWidth(80)]
    [SerializeField] float speed;
    public float Speed => speed;

    [LabelWidth(140)]
    [SerializeField] ParticleSystemFactory particleSystemFactory;
    public ParticleSystemFactory ParticleSystemFactory => particleSystemFactory;


    [LabelWidth(140)]
    [TagSelector]
    [SerializeField] string targetTag;
    public string TargetTag => targetTag;
  }
}