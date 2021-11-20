using UnityEngine;

namespace Frognar {
  public class Summoner : MonoBehaviour {
    [SerializeField] FloatVariable timeBetweenSummons;
    [SerializeField] Factory minionFactory;
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
      Factorable product = minionFactory.GetProduct(transform.position, transform.rotation);
      Enemy minion = product.GetComponent<Enemy>();
      minion.Reset();
    }
  }
}
