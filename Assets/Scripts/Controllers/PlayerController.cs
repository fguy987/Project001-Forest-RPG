using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class for controlling player Movement
/// </summary>
public class PlayerController : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Animator m_animator;

    private Vector2 moveInput;
    private float horizontalInput,verticalInput,speed;

    

    //Initialization
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>(); 
    }

    void Start()
    {
        speed = 3f;


        PlayerInputManager.SwitchActiveActionMap(PlayerInputManager.GameControls.Freeroam);
        PlayerInputManager.GameControls.Freeroam.Attack.performed += Attack_performed;
    }
    //Input Reading
    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Attack();
    }


    // MOvement
    private void Update()
    {
        moveInput = PlayerInputManager.GameControls.Freeroam.Movement.ReadValue<Vector2>();
        horizontalInput = moveInput.x;
        verticalInput = moveInput.y;
    }

    private void FixedUpdate()
    {
        //Debug.Log($"{horizontalInput} {verticalInput}");
        m_rigidbody.velocity = transform.InverseTransformDirection(new Vector3(horizontalInput* speed, m_rigidbody.velocity.y, verticalInput* speed));
        m_animator.SetFloat("speed_f", m_rigidbody.velocity.magnitude);
    }

    //Methods
    private void Attack()
    {
        m_animator.SetBool("isAttacking_b",true);
        StartCoroutine(TriggerTimer(0.2f));
    }

    private IEnumerator TriggerTimer(float v)
    {
        yield return new WaitForSeconds(v);
        m_animator.SetBool("isAttacking_b",false);
    }
}
