using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobFollowingState: MobState {

    float playerFollowTime = 2f;
    float timeSinceHit = 0f;

    public MobFollowingState(MobData mobData, Transform transform) {
        mobData.isPlayerDetected = false;
        this.transform = transform;
        OnEnter();
    }

    protected override void OnEnter() {
        Debug.Log("Entering following state");
    }

    public override MobStates OnUpdate(MobData mobData) {
        playerFollowTime -= Time.deltaTime;

        if (mobData.attacked) {
            timeSinceHit += Time.deltaTime;
        }

        if (playerFollowTime < 0f || timeSinceHit > 2f) {
            mobData.attacked = false;
            timeSinceHit = 0f;
            return MobStates.Patrol;
        }

        if (!mobData.attacked) {
            goToPlayer(mobData.player);
        }
        

        return MobStates.Follow;
    }

    private void goToPlayer(GameObject player) {
        float step = 10f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    protected override void OnLeave() {
        Debug.Log("Leaving following state");
    }
}