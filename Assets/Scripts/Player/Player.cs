namespace Frognar {
  public class Player : Movement {
    Health health;

    protected override void Awake() {
      base.Awake();
      health = GetComponent<Health>();
      health.OnDeath += (s, e) => Destroy(gameObject);
    }
  }
}