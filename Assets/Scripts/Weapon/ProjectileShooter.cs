using System;
using UnityEngine;

namespace Frognar {
  public class ProjectileShooter : MonoBehaviour {
    [SerializeField] Projectile projectile;
    [SerializeField] Transform shotPoint;
    [SerializeField] float timeBetwenShots;
    Pool<Projectile> pool;
    float shotTime;
    ActionTrigger actionTrigger;

    void Awake() {
      actionTrigger = GetComponent<ActionTrigger>();
      pool = new Pool<Projectile>(OnCreate, OnGet, OnRelease);
    }

    Projectile OnCreate() {
      var proj = Instantiate(projectile, shotPoint.position, transform.rotation);
      proj.SetPool(pool);
      return proj;
    }

    Projectile OnGet(Projectile projectile) {
      projectile.transform.position = shotPoint.position;
      projectile.transform.rotation = transform.rotation;
      projectile.gameObject.SetActive(true);
      return projectile;
    }

    void OnRelease(Projectile projectile) {
      projectile.gameObject.SetActive(false);
    }

    void OnEnable() {
      actionTrigger.ShotTrigger += Shot;
    }

    void OnDisable() {
      actionTrigger.ShotTrigger -= Shot;
    }

    void Shot(object sender, EventArgs e) {
      if (Time.time >= shotTime) {
        pool.Get();
        shotTime = Time.time + timeBetwenShots;
      }
    }
  }
}