using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public charControl myChar;
    public bool floored;
    public GameObject[] groundCheckList;
    public int buffer;
    public bool raycastDetection;
    /* 
     void OnTriggerEnter2D(Collider2D groundBox)
     {
         //print(groundBox.otherCollider);
         if (groundBox.tag == "floor")
         {
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
    */
    private void OnTriggerStay2D(Collider2D groundBox)
    {
        if (groundBox.tag == "floor")
        {
            floored = true;
        }
    }
    private void OnTriggerExit2D(Collider2D groundBox)
    {
        if (groundBox.tag == "floor")
            floored = false;
    }
    
    private bool countFloored()
    {
        for (int i = 0; i < groundCheckList.Length; i++)
        {
            if(groundCheckList[i].GetComponent<groundCheck>().floored == true)
            {
                return false;
            }
        }
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        //groundCheckList = GameObject.FindGameObjectsWithTag("floorChecker");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }
    void Update()
    {
        if (raycastDetection)
        {
            floored = false;
            //print(myChar.speedY);
            int layerMask = 1 << 9;
            layerMask = ~layerMask;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), .02f, layerMask);
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), .02f, layerMask))
            {
                UnityEngine.Debug.Log(hit.collider.name);
                UnityEngine.Debug.Log(hit.collider.tag);
                UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * .02f, Color.yellow);
                if (hit.collider == true)
                {
                    floored = true;
                }
                else
                {
                    floored = false;
                }
            }
        }
        if (myChar.jumpSpeed > 0)
            floored = false;
        
        myChar.noneFloored = countFloored();
        if (floored)
        {
                myChar.grounded = true;
                myChar.jumping = false;
                myChar.accel = myChar.groundAccel;
                myChar.jumpSpeed = 0;
                myChar.jumpBuffer = 0;
        }
        else if (myChar.squat == true)
        {
            myChar.grounded = false;
            if (myChar.climbing == false)
            {
                myChar.jumping = true;
                myChar.accel = myChar.airAccel;
            }
        }
        else if (myChar.noneFloored)
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
}
