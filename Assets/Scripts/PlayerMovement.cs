using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1;
	public enum faceDirection { Up, Down, Left, Right}
	public faceDirection currentDir = faceDirection.Up;
    public float Timer = 0f;
    public float AssemblyTimer = 3f;


    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(this.transform.position,new Vector3(1,1,1));
    }

    [Header("UI")]
    public Image Bar;
    public GameObject canvas;

    private void Start()
    {
        canvas.SetActive(false);
    }

   
    private void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Aerial" && col.gameObject.GetComponent<AerialScript>().AssembleState == false && Input.GetKey(KeyCode.E))
        {
            canvas.SetActive(true);
            Timer += Time.deltaTime;
            Bar.fillAmount = Timer / AssemblyTimer;
            
            if (Timer >= AssemblyTimer)
            {
                col.gameObject.GetComponent<AerialScript>().AssembleState = true;
                canvas.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Timer = 0;
            canvas.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Timer = 0;
        canvas.SetActive(false);
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
		
	}

    

}
