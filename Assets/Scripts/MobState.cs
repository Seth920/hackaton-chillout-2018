﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobState: IState {

    protected abstract void OnEnter();
    public abstract IState OnUpdate();
    protected abstract void OnLeave();
}