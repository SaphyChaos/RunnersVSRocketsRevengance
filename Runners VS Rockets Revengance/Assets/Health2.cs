using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2 : MonoBehaviour
{
    public int myhealth;
    public bool hitting;
    public bool dead;
    public GameObject myProtag;
    public int stunTime;
    public int iFrames;
    public float counter;
    public GameObject center;
    public Vector3 start;
    public bool invincible;
    private SpriteRenderer m_SpriteRenderer;
    private Color startColor;
    private AudioSource launch;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        startColor = m_SpriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitting && !dead)
        {
            if (start.y == 0 && start.x == 0)
                start = transform.position;
            myProtag.GetComponent<charControl2>().canControl = false;
            counter += 1f;
            //transform.Rotate(0.0f, 0.0f, counter);
            transform.RotateAround(center.transform.position, Vector3.forward, 720 * Time.deltaTime);
            if (counter >= stunTime)
            {
                transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                transform.position = start;
                start = Vector3.zero;
                hitting = false;
                counter = 0;
                myProtag.GetComponent<charControl2>().canControl = true;
                invincible = true;
            }
        }
        if (invincible && !dead)
        {
            counter += 1;
            gameObject.layer = 0;
            if (counter % 3 == 0 || counter % 4 == 0 || counter % 5 == 0 || counter % 7 == 0)
                m_SpriteRenderer.color = new Vector4(startColor.r, startColor.g, startColor.b, .5f);
            else
                m_SpriteRenderer.color = new Vector4(startColor.r, startColor.g, startColor.b, 1f);
            if (counter >= iFrames)
            {
                invincible = false;
                counter = 0;
                gameObject.layer = 9;
                m_SpriteRenderer.color = new Vector4(startColor.r, startColor.g, startColor.b, 1f);
            }
        }
        if (myhealth <= 0)
        {
            dead = true;
            myProtag.GetComponent<charControl2>().canControl = false;
            transform.RotateAround(center.transform.position, Vector3.forward, 720 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - .05f);
        }

    }
}
