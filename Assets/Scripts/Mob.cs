using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mob: MonoBehaviour {

    public List<GameObject> waypoints;
    IState mobState;

    void Start() {
        this.mobState = new MobPatrolingState(this.waypoints);
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
}
