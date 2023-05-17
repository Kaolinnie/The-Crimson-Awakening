using UnityEngine;

public class SwordHitEnemy : MonoBehaviour {
    private void OnTriggerEnter(Collider collider) {
        Debug.Log($"collision occurred: {collider.gameObject.tag}");
        
        if (collider.gameObject.CompareTag("Enemy")) {
            Enemy enemyScript = collider.gameObject.GetComponent<Enemy>();
            enemyScript.health -= 20.0f;
        }
    }
}
