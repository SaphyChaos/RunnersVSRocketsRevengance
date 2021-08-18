using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class timer : MonoBehaviour
{
    public Text mytext;
    public float time;
    private int mytimer;
    private float timething;
    private float frame = 0.016666666666666666666666666666666666666666666666667f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timething += Time.deltaTime;
            mytimer += 1;
            if (timething >= 1f)
            {
                timething = 0f;
                mytimer = 0;
                time -= 1;
                mytext.text = time.ToString();
                if (time == 0)
                {
                    SceneManager.LoadScene("end");
                }
            }
        }
    }