using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobFollowingState: MobState {    

    protected override void OnEnter() {
        Debug.Log("Entering following state");
    }

    public override IState OnUpdate() {
        return this;
    }

    protected override void OnLeave() {
        Debug.Log("Leaving following state");
    }
}