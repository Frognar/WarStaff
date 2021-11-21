using UnityEngine;

namespace Frognar {
  public class Summoner : MonoBehaviour {
    [SerializeField] FloatVariable timeBetweenSummons;
    [SerializeField] EnemyFactory enemyFactory;
    SummonAnimator summonAnimator;
    float summonTime;

    void Awake() {
      summonAnimator = GetComponent<SummonAnimator>();
    }

    public bool TimeToSummon() {
      return Time.time > summonTime;
    }

    public void StartSummoning() {
      summonAnimator.PlaySummonAnimation();
      summonTime = Time.time + timeBetweenSummons.Value;
    }

    public void Summon() {
      Enemy minion = enemyFactory.GetProduct(transform.position, transform.rotation);
      minion.Reset();
    }
  }
}
