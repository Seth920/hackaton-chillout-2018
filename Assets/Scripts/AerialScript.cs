using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialScript : MonoBehaviour {

    public bool AssembleState;
    // Use this for initialization

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(this.transform.position, new Vector3(1, 1, 1));
    }

    void Start () {
        AssembleState = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
