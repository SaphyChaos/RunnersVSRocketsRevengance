using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFocus2 : MonoBehaviour
{
    public bool visable;
    public Camera myCamera;
    private float frame = 0.016666666666666666666666666666666666666666666666667f;
    private float timething;
    private float thresh;
    public cameraFocus2 otherFocus;
    public float interpolationFactor;
    public int buffer;
    public bool zoomingIn;
    public float move;
    public float max;
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
    private void Awake()
    {
        myCamera = Camera.main;
    }
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
            //print(myCamera.WorldToScreenPoint(transform.position).x);
            timething = 0;
            if (myCamera.WorldToScreenPoint(transform.position).x <= 0)
            {
                visable = false;
            }
            else if (myCamera.WorldToScreenPoint(transform.position).x >= myCamera.pixelWidth)
            {
                visable = false;
            }
            else { visable = true;}
            move += .001f;
            move *= 1.1f;
            if ( move >= max)
            {
                move = max;
            }
            //print(timething);
            if (!visable || !otherFocus.visable)// && !zoomingIn)
            {
                if (zoomingIn == true)
                {
                    move = 0f;
                }
                myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z - move), interpolationFactor);
                zoomingIn = false;
            }
            else if (visable && otherFocus.visable)
            {
                if (zoomingIn == false)
                {
                    move = 0f;
                }
                myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z + move), interpolationFactor);
                zoomingIn = true;
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
