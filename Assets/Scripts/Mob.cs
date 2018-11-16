using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mob: MonoBehaviour {

    public float speed;
    public GameObject waypointsParent;
    IState mobState;

    void Awake() {
        var waypoints = this.getWaypoints();
        this.mobState = new MobPatrolingState(transform, waypoints, speed);
    }

    void Update() {
        this.handleStateUpdate(mobState.OnUpdate());
    }

    private void OnDrawGizmos() {
        Gizmos.DrawCube(this.transform.position, new Vector3(1, 1, 1));
    }

    private void handleStateUpdate(IState stateAfterFrame) {
        if (stateAfterFrame.GetType() == this.mobState.GetType()) {
            return;
        }
    }

    private List<GameObject> getWaypoints() {
        var waypointsList = new List<GameObject>();
        int childCount = waypointsParent.transform.childCount;
        for (int i = 0; i < childCount; i++) {
            waypointsList.Add(this.waypointsParent.transform.GetChild(i).gameObject);
        }

        return waypointsList;
    }
}
