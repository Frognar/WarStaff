using System;
using UnityEngine;

namespace Frognar {
  public class ProjectileShooter : MonoBehaviour {
    [SerializeField] Transform shotPoint;
    [SerializeField] float timeBetwenShots;
    [SerializeField] ProjectileFactory projectileFactory;
    float shotTime;
    ActionTrigger actionTrigger;

    void Awake() {
      actionTrigger = GetComponent<ActionTrigger>();
    }

    void OnEnable() {
      actionTrigger.ShotTrigger += Shot;
    }

    void OnDisable() {
      actionTrigger.ShotTrigger -= Shot;
    }

    void Shot(object sender, EventArgs e) {
      if (Time.time >= shotTime) {
        projectileFactory.GetProduct(shotPoint.position, transform.rotation);
        shotTime = Time.time + timeBetwenShots;
      }
    }
  }
}