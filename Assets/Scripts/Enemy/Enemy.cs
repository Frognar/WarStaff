namespace Frognar {
  public class Enemy : Movement {
    Health health;
    Pool<Enemy> pool;

    protected override void Awake() {
      base.Awake();
      health = GetComponent<Health>();
      health.OnDeath += (s, e) => pool.Release(this);
    }

    public void SetPool(Pool<Enemy> pool) {
      this.pool = pool;
    }

    public void Reset() {
      health.Reset();
    }
  }
}
