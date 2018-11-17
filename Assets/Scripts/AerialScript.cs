using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialScript: MonoBehaviour {

    public bool AssembleState;
    // Use this for initialization

    private void Awake() {
        GameManager.Instance.AddAerial(this.gameObject);
    }

    void Start() {
        AssembleState = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void SetAssembled() {
        Events.Instance.aerialAssembled_Event.Invoke(this.gameObject);
    }
}
