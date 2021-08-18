using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCheck : MonoBehaviour
{
    public charControl myChar;
    public GameObject[] innerWalls;
    public GameObject[] outerWalls;
    public bool inWall;
    public bool canCling;
    public bool wallCling;

    /*
    void OnTriggerEnter2D(Collider2D wallBox)
    {
        print(wallBox.tag);
        if(wallBox.tag == "wallInner" || wallBox.tag == "wall")
        {
            if (myChar.jumping == false)
                inWall = true;
        }
    }
    void OnTriggerExit2D(Collider2D wallBox)
    {
        if (wallBox.tag == "wallInner" || wallBox.tag == "wall")
        {
            if (myChar.jumping == false)
                inWall = false;
        }
        //print(groundBox.collider);
        //print(groundBox.otherCollider);
    }
    */
    void OnTriggerStay2D(Collider2D wallBox)
    {
        if (wallBox.tag == "wallInner")
        {
            inWall = true;
            print("inWall");
        }
        else
        {
            inWall = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        innerWalls = GameObject.FindGameObjectsWithTag("wallInner");
        outerWalls = GameObject.FindGameObjectsWithTag("wall");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inWall == false && myChar.squat == true && canCling)//inWall is triggering too soon fix pls
        {
            for (int i = 0; i < innerWalls.Length; i++)
            {
                innerWalls[i].GetComponent<BoxCollider2D>().isTrigger = false;
            }
            for (int i = 0; i < outerWalls.Length; i++)
            {
                outerWalls[i].SetActive(true);
            }
        }
        else if (myChar.climbing == true || inWall == true || myChar.grounded)
        {
            for (int i = 0; i < innerWalls.Length; i++)
            {
                innerWalls[i].GetComponent<BoxCollider2D>().isTrigger = true;
            }
            for (int i = 0; i < outerWalls.Length; i++)
            {
                outerWalls[i].SetActive(false);
            }
        }
    }
}
