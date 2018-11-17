using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialScript: MonoBehaviour {

    public bool AssembleState;
    public Light light;
    // Use this for initialization

    private void Awake() {
        GameManager.Instance.AddAerial(this.gameObject);
    }

    void Start() {
        AssembleState = false;
    }

    // Update is called once per frame
    void Update() {
        if (AssembleState) {
            light.range = Mathf.Cos(Time.time) * 4;
        }
        
    }

    public void SetAssembled() {
        Events.Instance.aerialAssembled_Event.Invoke(this.gameObject);
    }
}
