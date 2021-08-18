using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rocketScript : MonoBehaviour
{
    public inputScript myInputs;
    public bool activated;
    public bool timering;
    public int timer;
    public int timerTime;
    public Vector3 location;
    public GameObject self;
    public Vector3 inputs;
    public Vector3 axls;
    public float moveSpeed;
    public GameObject FoundObject;
    public health foundHealth;
    public Health2 foundHealth2;
    private GameObject explosion;
    public string RaycastReturn;
    private float xAxl;
    private float yAxl;
    public int damage;
    public AudioSource launch;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public Camera myCamera;
    float frame = 0.016666666666666666666666666666666666666666666666667f;
    /*
    void OnTriggerStay2D(Collider2D hitBox)
    {
        print(hitBox);
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        timering = false;
        explosion = GameObject.Find("explosion");
        activated = false;
    }
    float timething;
    // Update is called once per frame
    void FixedUpdate()
    {
        timething += Time.deltaTime;
        if (timething >= frame)
        {
            timething = 0f;
            if (activated)
            {
                if (myInputs.m_Fire > 0 && timering == false)
                {
                    timering = true;
                    location = self.transform.position;
                    launch.Play();
                }
                if (timering)
                {
                    timer += 1;
                }
                if (timer == timerTime)
                {
                    timer = 0;
                    timering = false;
                    Instantiate(explosion, new Vector3(location.x, location.y + .2f, location.z), transform.rotation);
                    int layerMask = 1 << 9;
                    RaycastHit2D hit = Physics2D.Raycast(location, transform.TransformDirection(Vector3.forward), Mathf.Infinity, layerMask);
                    // Does the ray intersect any objects excluding the player layer
                    if (Physics2D.Raycast(location, transform.TransformDirection(Vector3.forward), Mathf.Infinity, layerMask))
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                        print("Did Hit");
                        print(hit.transform.position);
                        RaycastReturn = hit.collider.gameObject.name;
                        FoundObject = GameObject.Find(RaycastReturn);
                        if (RaycastReturn == "protag")
                        {
                            foundHealth = FoundObject.GetComponent(typeof(health)) as health;
                            foundHealth.myhealth -= damage;
                            foundHealth.hitting = true;
                        }
                        else if (RaycastReturn == "protag2")
                        {
                            foundHealth = FoundObject.GetComponent(typeof(health)) as health;
                            foundHealth.myhealth -= damage;
                            foundHealth.hitting = true;
                        }
                        //Instantiate(explosion, transform.TransformPoint(new Vector3(hit.transform.position.x, hit.transform.position.y, 0f)), transform.rotation);
                        //print(hit.name);
                    }
                    else
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                        Debug.Log("Did not Hit");
                    }
                }
                inputs = Vector3.zero;
                inputs.x = myInputs.m_MovementRocket.x;
                inputs.y = myInputs.m_MovementRocket.y;
                axls = Vector3.zero;
                if (inputs.magnitude > 1)
                    inputs = inputs.normalized;
                if (Mathf.Abs(xAxl) < moveSpeed * 1.5f)
                    xAxl = xAxl + (inputs.x * (moveSpeed / 6));
                if (xAxl > .01f)
                {
                    xAxl = xAxl - (moveSpeed / 24);
                }
                else if (xAxl < -.01f)
                {
                    xAxl = xAxl + (moveSpeed / 24);
                }
                else
                    xAxl = 0f;
                if (Mathf.Abs(yAxl) < moveSpeed * 1.5f)
                    yAxl = yAxl + (inputs.y * (moveSpeed / 6));
                if (yAxl > .01f)
                {
                    yAxl = yAxl - (moveSpeed / 24);
                }
                else if (yAxl < -.01f)
                {
                    yAxl = yAxl + (moveSpeed / 24);
                }
                else
                    yAxl = 0f;
                axls.x = xAxl;
                axls.y = yAxl;
                if (axls.magnitude > 1)
                    axls = axls.normalized;
                transform.position = new Vector3(self.transform.position.x + xAxl, self.transform.position.y + yAxl, self.transform.position.z);
                while (myCamera.WorldToScreenPoint(transform.position).x > myCamera.pixelWidth)
                {
                    transform.position = new Vector3(self.transform.position.x - .01f, self.transform.position.y, self.transform.position.z);
                }
                while (myCamera.WorldToScreenPoint(transform.position).x < 0f)
                {
                    transform.position = new Vector3(self.transform.position.x + .01f, self.transform.position.y, self.transform.position.z);
                }
                while (myCamera.WorldToScreenPoint(transform.position).y > myCamera.pixelHeight)
                {
                    transform.position = new Vector3(self.transform.position.x, self.transform.position.y - .01f, self.transform.position.z);
                }
                while (myCamera.WorldToScreenPoint(transform.position).y < 0f)
                {
                    transform.position = new Vector3(self.transform.position.x, self.transform.position.y + .01f, self.transform.position.z);
                }
                //transform.position = new Vector3(self.transform.position.x, self.transform.position.y, myCamera.transform.position.z + .49f);
            }
        }
    }
}