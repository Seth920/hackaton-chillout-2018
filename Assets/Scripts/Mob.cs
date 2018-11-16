using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MobStates { Patrol, Follow };

public class Mob: MonoBehaviour {

    public float speed;
    private bool isPlayerDetected = false;
    public GameObject waypointsParent;
    MobData mobData = new MobData();
    IState mobState;
    MobStates mobStateEnum = MobStates.Patrol;

    void Awake() {
        var waypoints = this.getWaypoints();
        this.mobState = new MobPatrolingState(transform, waypoints, speed, mobData);
    }

    void Update() {
        MobStates newState = mobState.OnUpdate(mobData);
        handleStateUpdate(newState);
    }

    private void handleStateUpdate(MobStates newState) {
        if (newState == mobStateEnum) {
            return;
        }

        changeState(newState);
    }

    private void changeState(MobStates newState) {
        mobStateEnum = newState;
        switch (newState) {
            case MobStates.Patrol:
                this.mobState = new MobPatrolingState(transform, this.getWaypoints(), speed, mobData);
                break;
            case MobStates.Follow:
                this.mobState = new MobFollowingState(mobData, transform);
                break;
            default:
                break;
        }
    }

    public void onPlayerDetected(GameObject player) {
        if (mobStateEnum != MobStates.Patrol) {
            return;
        }
        mobData.isPlayerDetected = true;
        mobData.player = player;
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

public class MobData {
    public bool isPlayerDetected = false;
    public GameObject player;
}