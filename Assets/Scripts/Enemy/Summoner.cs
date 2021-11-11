using UnityEngine;

namespace Frognar {
  public class Summoner : MonoBehaviour {
    [SerializeField] GameObject minion;
    [SerializeField] FloatVariable timeBetweenSummons;
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
      Instantiate(minion, transform.position, transform.rotation);
    }
  }
}
