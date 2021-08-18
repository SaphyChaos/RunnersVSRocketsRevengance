using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript2 : MonoBehaviour
{
    public int time;
    public bool completed;
    public BoxCollider2D boxy;
    public SpriteRenderer spritey;
    public GameObject myDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (completed)
        {
            boxy.enabled = false;
            spritey.enabled = false;
            myDoor.GetComponent<Animator>().Play("doorAnimate2");
        }
    }
}
