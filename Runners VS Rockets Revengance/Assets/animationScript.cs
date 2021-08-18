using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    public charControl myCharScript;
    public Animator myAnim;
    public Animator cameraAnim;
    /*
    public AnimationClip idle;
    public AnimationClip run;
    public AnimationClip squat;
    public AnimationClip jump;
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myCharScript.squat == true)
        {
            myAnim.Play("squat");
        }
        else if(myCharScript.noneFloored == true && !myCharScript.climbing)
        {
            myAnim.Play("jump");
        }
        else if(Mathf.Abs(myCharScript.speed) > 0 && myCharScript.climbing == false)
        {
            myAnim.Play("running");
        }
        else if (myCharScript.climbing)
        {
            myAnim.Play("climbing");
        }
        else
        {
            myAnim.Play("idle");
        }
        if (myCharScript.cameraJerk)
        {
            cameraAnim.Play("cameraLurch");
        }
        else if(myCharScript.cameraJerk == false)
        {
            cameraAnim.Play("cameraLurchBack");
        }
    }
}
