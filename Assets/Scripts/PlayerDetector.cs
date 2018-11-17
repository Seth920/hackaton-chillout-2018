using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector: MonoBehaviour {

    Mob mobScript;

    public float playerDetectionRadius = 5f;
    public float timeSinceCaught = 0f;
    public bool isDetected = false;

    void Start() {
        GetComponent<CircleCollider2D>().radius = playerDetectionRadius;
        mobScript = transform.parent.gameObject.GetComponent<Mob>();
    }

    // Update is called once per frame
    void Update() {
        if (isDetected) {
            timeSinceCaught += Time.deltaTime;
        }

        if (timeSinceCaught > 5f) {
            GetComponent<CircleCollider2D>().enabled = true;
            timeSinceCaught = 0f;
            isDetected = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            mobScript.onPlayerDetected(collision.gameObject);
            isDetected = true;
            GetComponent<CircleCollider2D>().enabled = false;
        }        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, this.playerDetectionRadius);
    }
}
