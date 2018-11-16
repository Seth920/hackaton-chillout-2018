using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPatrolingState: MobState {

    private List<GameObject> waypoints;

    public MobPatrolingState(List<GameObject> waypoints) {
        this.waypoints = waypoints;
    }

    protected override void OnEnter() {
        Debug.Log("Entering patrolling state");
    }

    public override IState OnUpdate() {
        return this;
    }

    protected override void OnLeave() {
        Debug.Log("Leaving patrolling state");
    }
}