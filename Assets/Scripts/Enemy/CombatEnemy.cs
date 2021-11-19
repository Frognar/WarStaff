namespace Frognar {
  public class CombatEnemy : Enemy {
    TargetFinder targetFinder;
    Attacker attacker;

    protected override void Awake() {
      base.Awake();
      targetFinder = GetComponent<TargetFinder>();
      attacker = GetComponent<Attacker>();
    }

    void Start() {
      attacker.SetTarget(targetFinder.FindTarget());
    }
  }
}
