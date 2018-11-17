using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobFollowingState: MobState {

    float playerFollowTime = 2f;
    float timeSinceHit = 0f;
    private AudioSource audioSource;
    private List<AudioClip> clips;

    public MobFollowingState(MobData mobData, Transform transform, AudioSource audioS, List<AudioClip> clips) {
        mobData.isPlayerDetected = false;
        this.transform = transform;
        this.audioSource = audioS;
        this.clips = clips;
        OnEnter();
    }

    protected override void OnEnter() {
        Debug.Log("Entering following state");
        int index = Random.Range(0, 5);
        audioSource.clip = clips[index];
        audioSource.Play();
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
        float step = 3f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    protected override void OnLeave() {
        Debug.Log("Leaving following state");
    }
}