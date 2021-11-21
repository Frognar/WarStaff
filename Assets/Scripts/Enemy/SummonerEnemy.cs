using UnityEngine;

namespace Frognar {
  public class SummonerEnemy : Enemy {
    RandomPointFinder randomPointFinder;
    [SerializeField] FloatVariable timeBetweenSummons;
    [SerializeField] EnemyFactory minionFactory;
    SummonAnimator summonAnimator;
    float summonTime;

    protected override void Awake() {
      base.Awake();
      randomPointFinder = GetComponent<RandomPointFinder>();
      summonAnimator = GetComponent<SummonAnimator>();
    }

    void Start() {
      attacker.DisableAttacks();
    }

    void Update() {
      if (CanSummon()) {
        StartSummoning();
      }
    }

    bool CanSummon() {
      if (!randomPointFinder.TargetReached) {
        return false;
      }
      return targetFinder.HasTarget() && TimeToSummon();
    }

    public bool TimeToSummon() {
      return Time.time > summonTime;
    }

    public void StartSummoning() {
      summonAnimator.PlaySummonAnimation();
      summonTime = Time.time + timeBetweenSummons.Value;
    }

    public void Summon() {
      Enemy minion = minionFactory.GetProduct(transform.position, transform.rotation);
      minion.Reset();
    }
  }
}
