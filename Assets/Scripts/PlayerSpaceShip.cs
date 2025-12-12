using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpaceShip : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float maxSpeed = 2f;
    [SerializeField] float acceleration = 6f;

    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;
  
    [Header("Controls")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;

    private AudioSource basicShot;
    private void Awake()
    {
        basicShot = GetComponent<AudioSource>();
    }



    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();

        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        shoot.action.started += OnShoot;
    }

    Vector2 currentVelocity = Vector2.zero;
    const float rawMoveThresholdForBraking = 0.1f;
    void Update()
    {
      
        if (rawMove.magnitude < rawMoveThresholdForBraking)
        {
            currentVelocity *= 0.1f * Time.deltaTime; 
        }
        currentVelocity += rawMove * acceleration * Time.deltaTime;

        float linearVelocity = currentVelocity.magnitude;
        linearVelocity = Mathf.Clamp(linearVelocity, 0, maxSpeed);
        currentVelocity = currentVelocity.normalized * linearVelocity;

        transform.Translate(rawMove * maxSpeed*Time.deltaTime);
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        basicShot.Play();
    }

    Vector2 rawMove;
    private void OnMove(InputAction.CallbackContext obj)
    {
        rawMove = obj.ReadValue<Vector2>();
       
    }

    
    private void OnDisable()
    {
      move.action.Disable();
      shoot.action.Disable();

      move.action.started -= OnMove;
      move.action.performed -= OnMove;
      move.action.canceled -= OnMove;

      shoot.action.started += OnShoot;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

}
