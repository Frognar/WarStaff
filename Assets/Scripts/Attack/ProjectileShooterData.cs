using Sirenix.OdinInspector;
using UnityEngine;

namespace Frognar {
  [CreateAssetMenu(fileName = "Projectile Shooter Data", menuName = "Projectile/Projectile Shooter Data")]
  public class ProjectileShooterData : ScriptableObject {
    [PreviewField(60), HideLabel]
    [HorizontalGroup("Split", 60)]
    [SerializeField] Sprite sprite;
    public Sprite Sprite => sprite;

    [VerticalGroup("Split/Right"), LabelWidth(80)]
    [SerializeField] float timeBetwenShots;
    public float TimeBetwenShots => timeBetwenShots;

    [VerticalGroup("Split/Right"), LabelWidth(80)]
    [SerializeField] ProjectileData projectileData;
    public ProjectileData ProjectileData => projectileData;
  }
}
