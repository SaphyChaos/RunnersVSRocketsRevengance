using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck2 : MonoBehaviour
{
    public charControl2 myChar;
    void OnTriggerEnter2D(Collider2D groundBox)
    {
        //print(groundBox.otherCollider);
        if (groundBox.tag == "floor")
        {
            print("boing");
            myChar.grounded = true;
            myChar.jumping = false;
            myChar.accel = myChar.groundAccel;
            myChar.jumpSpeed = 0;
        }
    }
    void OnTriggerExit2D(Collider2D groundBox)
    {
        if (groundBox.tag == "floor")
        {
            myChar.grounded = false;
            if (myChar.climbing == false)
            {
                myChar.jumping = true;
                myChar.accel = myChar.airAccel;
            }
        }
        //print(groundBox.collider);
        //print(groundBox.otherCollider);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
