using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 0f;
    [SerializeField] private float turnSpeed = 40.0f;

    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    
    [SerializeField] private GameObject centerOfMass;

    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;

    [SerializeField] private List<WheelCollider> allWheels;
    
    private float _horizontalInput;
    private float _forwardInput;

    private int _wheelsOnGround;

    private Rigidbody _playerRb;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerRb.centerOfMass = centerOfMass.transform.position;
    }

    private void FixedUpdate()
    {
        if (IsOnGround())
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _forwardInput = Input.GetAxis("Vertical");
            
            _playerRb.AddRelativeForce(Vector3.forward * _forwardInput * horsePower);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * _horizontalInput);

            speed = Mathf.RoundToInt(_playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + "km/h");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RMP: " + rpm);
        }
    }

    private bool IsOnGround()
    {
        _wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                _wheelsOnGround++;
            }
        }

        if (_wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
