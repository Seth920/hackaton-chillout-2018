﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: Singleton<GameManager> {

    private Dictionary<GameObject, bool> aerials = new Dictionary<GameObject, bool>();

    public void AddAerial(GameObject aerial) {
        aerials.Add(aerial, false);
    }

    private void Awake() {
        Debug.Log("Manager awake");
    }

    // Use this for initialization
    void Start() {
        Debug.Log("Manager start");
    }

    // Update is called once per frame
    void Update() {

    }
}
