using System.Collections;
using UnityEngine;

namespace Frognar {
  public class SummonerEnemy : Enemy {
    RandomPointFinder randomPointFinder;
    [SerializeField] FloatVariable timeBetweenSummons;
    [SerializeField] EnemyFactory minionFactory;
    Animator animator;
    HitAndRun hitAndRun;
    float summonTime;
    bool canAttack;

    protected override bool CanAttack => canAttack && base.CanAttack;
    bool TimeToSummon => Time.time > summonTime;
    bool DestinationPointReached => randomPointFinder.TargetReached;
    bool CanSummon => DestinationPointReached && HasTarget && TimeToSummon;

    protected override void Awake() {
      base.Awake();
      randomPointFinder = GetComponent<RandomPointFinder>();
      animator = GetComponent<Animator>();
    }

    protected override void Start() {
      base.Start();
      hitAndRun = GetComponent<HitAndRun>();
      hitAndRun.SetTarget(target);
    }

    void OnEnable() {
      canAttack = false;
    }

    protected override void Update() {
      base.Update();
      if (CanSummon) {
        StartSummoning();
      }
    }

    public void StartSummoning() {
      canAttack = false;
      animator.SetTrigger("summon");
      summonTime = Time.time + timeBetweenSummons.Value;
    }

    public void Summon() {
      Enemy minion = minionFactory.GetProduct(transform.position, transform.rotation);
      canAttack = true;
    }

    protected override void DoAttack() {
      hitAndRun.Attack();
    }
  }
}
