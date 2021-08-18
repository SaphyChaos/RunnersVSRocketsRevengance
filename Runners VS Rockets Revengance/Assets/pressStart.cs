using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressStart : MonoBehaviour
{
    //public void LoadA(string SampleScene)
    //{
    //    SceneManager.LoadScene(SampleScene);
    //}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Submit") == 1)
        {
           SceneManager.LoadScene("SampleScene");
        }
    }
}
