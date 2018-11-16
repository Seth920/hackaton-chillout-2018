using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	
    private bool cooldown = false;
    public float cooldownTime = .5f;
    
    // Update is called once per frame
    void ResetCooldown()
    {
        cooldown = false;
    }


    void Update ()
    {
        if (Input.GetKey(KeyCode.A)) // left
        {
            if (cooldown == false)
            {
                transform.Translate(-1.0f, 0.0f, 0.0f);
                Invoke("ResetCooldown", cooldownTime);
                cooldown = true;
            }
                
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            if (cooldown == false)
            {
                transform.Translate(1.0f, 0.0f, 0.0f);
                Invoke("ResetCooldown", cooldownTime);
                cooldown = true;
            }
            
        }
        if (Input.GetKey(KeyCode.W)) // forward
        {
            if (cooldown == false)
            {
                transform.Translate(0.0f, 1.0f, 0.0f);
                Invoke("ResetCooldown", cooldownTime);
                cooldown = true;
            }
            
        }
        if (Input.GetKey(KeyCode.S)) // backward
        {
            if (cooldown == false)
            {
                transform.Translate(0.0f, -1.0f, 0.0f);
                Invoke("ResetCooldown", cooldownTime);
                cooldown = true;
            }
            
        }
        if (Input.GetKey(KeyCode.KeypadEnter)) // assemble
        {
            // tutaj bedzie montowanie
        }
        if (Input.GetKey(KeyCode.Space)) // boost
        {
            // tutaj bedzie uzywanie boosta
        }

    }
}
