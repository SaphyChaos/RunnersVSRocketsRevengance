using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxScript : MonoBehaviour
{
    public int time;
    public bool completed;
    public BoxCollider2D boxy;
    public SpriteRenderer spritey;
    public GameObject myDoor;
    public GameObject door2;
    public int mode;
    // Start is called before the first frame update
    void Start()
    {
        door2.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (completed)
        {
            boxy.enabled = false;
            spritey.enabled = false;
            if (mode == 1)
            {
                myDoor.GetComponent<Animator>().Play("doorAnimate");
            }
            else if (mode == 2)
            {
                door2.active = true;
                myDoor.active = false;
                door2.GetComponent<Animator>().Play("doorAnimate2");
            }
            else if (mode == 3)
            {
                SceneManager.LoadScene("end");
            }
        }
    }
}
