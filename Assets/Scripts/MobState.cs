using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobState: IState {
    protected Transform transform;

    protected abstract void OnEnter();
    public abstract MobStates OnUpdate(MobData mobData);
    protected abstract void OnLeave();
}