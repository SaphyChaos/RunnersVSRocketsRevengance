using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rocketInput : MonoBehaviour
{
    Vector2 movementInput;
    public Vector3 m_Movement;
    public float m_Fire;
    public float fire;
    // Start is called before the first frame update
    private void Move()
    {
        //var movementInput = controls.player1.Movement.ReadValue<Vector2>();
        var movement = new Vector3();
        {
            movement.x = movementInput.x;
            movement.y = movementInput.y;
        }
        movement.Normalize();
        m_Movement = movement;
        //movementInput.x = 0f; movementInput.y = 0f;
        //transform.Translate(movement * movementSpeed * Time.deltaTime);
    }
    private void Fire()
    {
        m_Fire = fire;
    }
    private void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
    public void OnFire(InputValue value)
    {
        fire = value.Get<float>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }
}
