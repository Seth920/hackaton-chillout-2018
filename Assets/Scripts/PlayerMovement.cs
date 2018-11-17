using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement: MonoBehaviour {

    public float speed = 1;
    public enum faceDirection { Up, Down, Left, Right }
    public faceDirection currentDir = faceDirection.Up;
    public float Timer = 0f;
    public float AssemblyTimer = 3f;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D playerRb;

    [Header("UI")]
    public Image Bar;
    public GameObject canvas;
    public GameObject hintButton;



    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        canvas.SetActive(false);
        hintButton.SetActive(false);
    }


    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Aerial" && col.gameObject.GetComponent<AerialScript>().AssembleState == false) {
            hintButton.SetActive(true);

        }

        if (col.gameObject.tag == "Aerial" && col.gameObject.GetComponent<AerialScript>().AssembleState == false && Input.GetKey(KeyCode.E)) {
            animator.SetBool("isHacking", true);
            canvas.SetActive(true);
            Timer += Time.deltaTime;
            Bar.fillAmount = Timer / AssemblyTimer;

            if (Timer >= AssemblyTimer) {
                AerialScript aerial = col.gameObject.GetComponent<AerialScript>();
                aerial.AssembleState = true;
                aerial.SetAssembled();
                canvas.SetActive(false);
                hintButton.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.E)) {
            Timer = 0;
            canvas.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Timer = 0;
        canvas.SetActive(false);
        hintButton.SetActive(false);
    }

    float GetAngle(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.E)) {
            animator.SetBool("isHacking", false);
        }

        if (Input.GetKey(KeyCode.E) && animator.GetBool("isHacking")) {
            return;
        }

        //float xInput = Input.GetAxis("Horizontal");
        //float yInput = Input.GetAxis("Vertical");
        //animator.SetFloat("Speed", Mathf.Abs(xInput+yInput));
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = GetAngle(positionOnScreen, mouseOnScreen);

        Vector3 direction = new Vector3();


        if (Input.GetKey(KeyCode.A)) // left
        {
            direction += Vector3.left * speed * Time.deltaTime;
            currentDir = faceDirection.Left;
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            direction += Vector3.right * speed * Time.deltaTime;
            currentDir = faceDirection.Right;


        }
        if (Input.GetKey(KeyCode.W)) // forward
        {
            var rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
            direction += rotation * Vector3.up * speed * Time.deltaTime;
            currentDir = faceDirection.Up;

        }


        if (Input.GetKey(KeyCode.S)) // backward
        {
            direction += Vector3.down * speed * Time.deltaTime;
            currentDir = faceDirection.Down;
        }
        direction.x = Mathf.Clamp(direction.x, -1 * speed * Time.deltaTime, 1 * speed * Time.deltaTime);
        direction.y = Mathf.Clamp(direction.y, -1 * speed * Time.deltaTime, 1 * speed * Time.deltaTime);
        Debug.Log(direction.y);
        transform.position += direction;

        if (direction.x != 0 || direction.y != 0) {
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
    }


}
