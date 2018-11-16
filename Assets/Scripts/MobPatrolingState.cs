﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPatrolingState: MobState {

    private float speed;
    private List<GameObject> waypoints;
    private int currentWaypoint = 0;

    public MobPatrolingState(Transform transform, List<GameObject> waypoints, float speed, MobData mobData) {
        this.OnEnter();
        this.waypoints = waypoints;
        this.transform = transform;
        this.speed = speed;
    }

    protected override void OnEnter() {
        Debug.Log("Entering patrolling state");
    }

    public override MobStates OnUpdate(MobData mobData) {
        if (mobData.isPlayerDetected) {
            return MobStates.Follow;
        }

        goToWaypoint();

        if (checkIfReachedWaypoint()) {
            setNextWaypoint();
        }

        return MobStates.Patrol;
    }

    private void goToWaypoint() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, step);
    }

    private bool checkIfReachedWaypoint() {
        return Vector2.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) < 0.3f;
    }

    private void setNextWaypoint() {
        currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
    }

    private float checkDistanceFromWaypoint() {
        return 1f;
    }

    protected override void OnLeave() {
        Debug.Log("Leaving patrolling state");
    }


}