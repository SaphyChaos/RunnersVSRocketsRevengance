using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicStart : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject myProtag;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 300;
        myProtag = GameObject.Find("protag");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(myProtag.GetComponent<charControl>().protag.transform.position.x, myProtag.GetComponent<charControl>().protag.transform.position.y, -10f);
    }
}
