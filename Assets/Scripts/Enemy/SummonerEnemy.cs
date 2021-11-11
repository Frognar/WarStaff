using UnityEngine;

namespace Frognar {
  public class SummonerEnemy : Movement {
    Summoner summoner;
    TargetFinder targetFinder;
    MeleeAttacker meleeAttacker;

    protected override void Awake() {
      base.Awake();
      targetFinder = GetComponent<TargetFinder>();
      meleeAttacker = GetComponent<MeleeAttacker>();
      summoner = GetComponent<Summoner>();
    }

    void Start() {
      meleeAttacker.SetTarget(targetFinder.FindTarget());
      meleeAttacker.DisableAttacks();
    }

    protected override void Update() {
      base.Update();
      if (CanSummon()) {
        summoner.StartSummoning();
      }
    }

    bool CanSummon() {
      if (moveDirection.Direction != Vector2.zero){
        return false;
      }
      return targetFinder.HasTarget() && summoner.TimeToSummon();
    }
  }
}
