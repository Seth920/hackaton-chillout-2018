using UnityEngine;

public class WayPointGizmo: MonoBehaviour {

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(this.transform.position, 0.5f);
    }
}
