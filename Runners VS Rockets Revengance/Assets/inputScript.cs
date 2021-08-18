using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
//using System.Runtime.InteropServices;


public class inputScript : MonoBehaviour
{
    Vector2 movementInput;
    Vector2 smovementInput;
    public float m_Jump;
    private float jump;
    public float m_Climb;
    private float climb;
    public float m_Warp;
    private float warp;
    public Vector3 m_Movement;
    public Vector3 m_SwordMovement;
    private PlayerInput playerInput;
    private charControl myCharControl;
    private rocketInput myRocketInput;
    private rocketScript myRocketScript;
    Vector2 rocketMovementInput;
    public Vector3 m_MovementRocket;
    public float m_Fire;
    public float fire;
    public GameObject Rocket;
    public GameObject Player;
    // Start is called before
    //private Controls controls = null;
    //private void Awake() => controls = new Controls();
    //private void OnEnable() => controls.player1.Enable();
    //private void OnDisable() => controls.player1.Disable();

    private void Move()
    {
        //var movementInput = controls.player1.Movement.ReadValue<Vector2>();
        var movement = new Vector3();
        {
            movement.x = movementInput.x;
            movement.y = movementInput.y;
        }
        movement.Normalize();
        m_Movement.x = movement.x;
        m_Movement.y = movement.y;
        //print(m_Movement.x);
        //print(m_Movement.y);
        //movementInput.x = 0f; movementInput.y = 0f;
        //transform.Translate(movement * movementSpeed * Time.deltaTime);
    }
    private void MoveRocket()
    {
        //var movementInput = controls.player1.Movement.ReadValue<Vector2>();
        var movement = new Vector3();
        {
            movement.x = rocketMovementInput.x;
            movement.y = rocketMovementInput.y;
        }
        movement.Normalize();
        m_MovementRocket = movement;
        //movementInput.x = 0f; movementInput.y = 0f;
        //transform.Translate(movement * movementSpeed * Time.deltaTime);
    }
    private void Fire()
    {
        m_Fire = fire;
    }
    private void OnMoveRocket(InputValue value)
    {
        rocketMovementInput = value.Get<Vector2>();
    }
    public void OnFireRocket(InputValue value)
    {
        fire = value.Get<float>();
    }
    private void SMove()
    {
        //var movementInput = controls.player1.Movement.ReadValue<Vector2>();
        var smovement = new Vector3();
        {
            smovement.x = movementInput.x;
            smovement.y = movementInput.y;
        }
        smovement.Normalize();
        m_SwordMovement = smovement;
        //transform.Translate(movement * movementSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        //m_Jump = controls.player1.Jump.ReadValue<float>();
        m_Jump = jump;
        //transform.position = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);
    }
    public void Climb()
    {
        m_Climb = climb;
    }
    public void Warp()
    {
        m_Warp = warp;
    }
    private void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void OnSmovement(InputValue value)
    {
        smovementInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        jump = value.Get<float>();
    }
    public void OnClimb(InputValue value)
    {
        climb = value.Get<float>();
    }
    public void OnWarp(InputValue value)
    {
        warp = value.Get<float>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {

        if (GetComponent<PlayerInput>() != null)
        {
            //Rocket = GameObject.Find("rocketLauncher");
            //Player = GameObject.Find("protag 929");
            playerInput = GetComponent<PlayerInput>();
            //print(GetComponent<PlayerInput>());
            //print(playerInput.playerIndex);
            var index = playerInput.playerIndex;
            var controls = FindObjectsOfType<charControl>();
            var rocketControls = FindObjectOfType<rocketInput>();
            var rocketScript = FindObjectOfType<rocketScript>();
            if (playerInput.playerIndex == 1)
            {
                myRocketInput = rocketControls;
                myRocketScript = rocketScript;
                myRocketScript.myInputs = this;
                playerInput.SwitchCurrentActionMap("Rocket");
                //Player.SetActive(false);
                myRocketScript.activated = true;
                //myRocketScript = Rocket.GetComponent<rocketScript>();
                //myRocketInput = Rocket.GetComponent<rocketInput>();
                myRocketScript.myInputs = this;
            }
            else
            {
                playerInput.SwitchCurrentActionMap("Player");
                //Rocket.SetActive(false);
                myCharControl = controls.FirstOrDefault(m => m.GetPlayerIndex() == index);
                //myCharControl = Player.GetComponent<charControl>();
                myCharControl.myInputs = this;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        SMove();
        Jump();
        Climb();
        Warp();
        MoveRocket();
        Fire();
    }

}