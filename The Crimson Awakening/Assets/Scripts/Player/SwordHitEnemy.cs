using System;
using UnityEngine;

public class SwordHitEnemy : MonoBehaviour {
    private Player _player;

    private void Start() {
        _player = Player.Instance;
    }


    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Enemy")) {
            Enemy enemyScript = collider.gameObject.GetComponent<Enemy>();
            enemyScript.health -= _player.damage;
        }
    }
}
