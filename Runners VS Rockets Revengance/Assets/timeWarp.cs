using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeWarp : MonoBehaviour
{
    public GameObject myProtag;
    public inputScript myInputs;
    public List<Vector3> positions;
    public int warpFrames;
    private int timer;
    private float time;
    private bool warping;
    private Vector3 myVec;
    // Start is called before the first frame update
    void Start()
    {
        //myProtag = GameObject.Find("protag");
        //print(myProtag.GetComponent<charControl>().jumping);
        Stack<Vector3> positions = new Stack<Vector3>(warpFrames);
        warping = false;
    }

    // Update is called once per frame

    void Update()
    {
        if (!warping)
        {
            positions.Add(myProtag.GetComponent<charControl>().protag.transform.position);
            if(positions.Count > warpFrames)
            {
                positions.RemoveAt(0);
            }
        }
        else
        {
            if (positions.Count > 0) {
                myVec = positions[positions.Count - 1];
                myProtag.GetComponent<charControl>().protag.transform.position = new Vector3(myVec.x, myVec.y, myVec.z);
                positions.RemoveAt(positions.Count - 1);
            }
            else
            {
                warping = false;
                myProtag.GetComponent<charControl>().canControl = !myProtag.GetComponent<charControl>().canControl;
            }
        }
        /*
        timer += 1;
        time += Time.deltaTime;
        //print(time);
        if (time >= 1.0f)
        {
            //print(timer);
            timer = 0;
            time = 0.0f;
        }
        */
        //if (Input.GetAxisRaw("Fire4") == 0f) { canWarp = true; }
        if (myInputs.m_Warp > 0f)// > 0 && canWarp == true) ;
        {
            warping = !warping;
            myProtag.GetComponent<charControl>().canControl = !myProtag.GetComponent<charControl>().canControl;
        }
    }
}
