using UnityEngine;

namespace Frognar {
  public class Summoner : MonoBehaviour {
    [SerializeField] Enemy minion;
    [SerializeField] FloatVariable timeBetweenSummons;
    SummonAnimator summonAnimator;
    float summonTime;
    Pool<Enemy> pool;

    void Awake() {
      summonAnimator = GetComponent<SummonAnimator>();
      pool = new Pool<Enemy>(OnCreate, OnGet, OnRelease);
    }

    Enemy OnCreate() {
      var enemy = Instantiate(minion, transform.position, transform.rotation);
      enemy.SetPool(pool);
      return enemy;
    }

    Enemy OnGet(Enemy enemy) {
      enemy.Reset();
      enemy.transform.position = transform.position;
      enemy.transform.rotation = transform.rotation;
      enemy.gameObject.SetActive(true);
      return enemy;
    }

    void OnRelease(Enemy enemy) {
      enemy.gameObject.SetActive(false);
    }

    public bool TimeToSummon() {
      return Time.time > summonTime;
    }

    public void StartSummoning() {
      summonAnimator.PlaySummonAnimation();
      summonTime = Time.time + timeBetweenSummons.Value;
    }

    public void Summon() {
      pool.Get();
    }
  }
}
