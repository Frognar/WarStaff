using UnityEngine;

namespace Frognar {
  public class SummonerEnemy : Movement {
    Summoner summoner;
    TargetFinder targetFinder;
    Attacker attacker;

    protected override void Awake() {
      base.Awake();
      targetFinder = GetComponent<TargetFinder>();
      attacker = GetComponent<Attacker>();
      summoner = GetComponent<Summoner>();
    }

    void Start() {
      attacker.SetTarget(targetFinder.FindTarget());
      attacker.DisableAttacks();
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
