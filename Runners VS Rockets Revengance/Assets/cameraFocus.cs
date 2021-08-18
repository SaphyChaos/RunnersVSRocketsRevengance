using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFocus : MonoBehaviour
{
    public bool visable;
    public Camera myCamera;
    private float frame = 0.016666666666666666666666666666666666666666666666667f;
    private float timething;
    private float thresh;
    public cameraFocus otherFocus;
    public float interpolationFactor;
    public int buffer;
    public bool zoomingIn;
    public float move;
    /*
    void OnBecameVisible()
    {
        visable = true;
    }
    void OnBecameInvisible()
    {
        visable = false;
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        thresh = myCamera.pixelWidth / 10f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timething += Time.deltaTime;
        if (timething >= frame)
        {
            timething = 0;
            if (myCamera.WorldToScreenPoint(transform.position).x <= 0)
            {
                visable = false;
            }
            else if (myCamera.WorldToScreenPoint(transform.position).x >= myCamera.pixelWidth)
            {
                visable = false;
            }
            else { visable = true; }
            move = Mathf.Abs(myCamera.WorldToScreenPoint(transform.position).x - myCamera.pixelWidth);
            //print(timething);
            if (!visable || !otherFocus.visable)// && !zoomingIn)
            {
                myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z - move), interpolationFactor);
            }
            else if (visable && otherFocus.visable)
            {
                myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z + move), interpolationFactor);
                //zoomingIn = true;
            }

            /*
            else if(zoomingIn)
                buffer += 1;
            if (buffer >= 30)
            {
                zoomingIn = false;
                buffer = 0;
            }
            */
        }
    }
}
