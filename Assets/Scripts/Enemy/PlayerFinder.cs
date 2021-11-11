using UnityEngine;

namespace Frognar {
    public class PlayerFinder : MonoBehaviour, TargetFinder {
        Transform player;

        void Awake() {
            player = GameObject.FindGameObjectWithTag("Player").transform;    
        }

        public Transform FindTarget() {
            return player;
        }
    }
}