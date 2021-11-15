using UnityEngine;

namespace Frognar {
  public class RangedAttacker : Attacker {
    [SerializeField] Projectile projectile;
    [SerializeField] Transform shotPoint;
    Pool<Projectile> pool;
    Animator animator;

    void Awake() {
      animator = GetComponent<Animator>();
      pool = new Pool<Projectile>(OnCreate, OnGet, OnRelease);
    }

    protected override void Attack() {
      animator.SetTrigger("attack");
      attackTime = Time.time + timeBetweenAttacks.Value;
    }

    public void Shot() {
      pool.Get();
    }

    Projectile OnCreate() {
      var proj = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
      proj.SetPool(pool);
      return proj;
    }

    Projectile OnGet(Projectile projectile) {
      projectile.transform.position = shotPoint.position;
      projectile.transform.rotation = shotPoint.rotation;
      projectile.gameObject.SetActive(true);
      return projectile;
    }

    void OnRelease(Projectile projectile) {
      projectile.gameObject.SetActive(false);
    }
  }
}
