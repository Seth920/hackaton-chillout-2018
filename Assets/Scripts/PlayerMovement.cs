using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1;
	public enum faceDirection { Up, Down, Left, Right}
	public faceDirection currentDir = faceDirection.Up;

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(this.transform.position,new Vector3(1,1,1));
    }
    
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Aerial")
        {
            col.gameObject.GetComponent<AerialScript>().AssembleState = true;

        }
    }  

    void Update ()
	{
		if (Input.GetKey(KeyCode.A)) // left
		{

            transform.position += Vector3.left * speed * Time.deltaTime;
            currentDir = faceDirection.Left;
           


        }
		if (Input.GetKey(KeyCode.D)) // right
		{
            transform.position += Vector3.right * speed * Time.deltaTime;
            currentDir = faceDirection.Right;
			
			
		}
		if (Input.GetKey(KeyCode.W)) // forward
		{
            transform.position += Vector3.up * speed * Time.deltaTime;
            currentDir = faceDirection.Up;
                
        }
			
		
		if (Input.GetKey(KeyCode.S)) // backward
		{
            transform.position += Vector3.down * speed * Time.deltaTime;
            currentDir = faceDirection.Down;
			
			
			
		}
		if (Input.GetKey(KeyCode.KeypadEnter)) // assemble
		{
            
            
		}
		if (Input.GetKey(KeyCode.Space)) // boost
		{
			// tutaj bedzie uzywanie boosta
		}

	}
}
