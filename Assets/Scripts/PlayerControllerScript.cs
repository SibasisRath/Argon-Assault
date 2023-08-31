using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField] float controlSpeed;
    [SerializeField] float LeftLimit;
    [SerializeField] float RightLimit;
    [SerializeField] float UpLimit;
    [SerializeField] float DownLimit;

    float horizontalInput;
    float verticalInput;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controllPitchFactor = -10f;
    [SerializeField] float positionYawFactor = -2f;
    [SerializeField] float controllRollFactor = -10f;


    [SerializeField] ParticleSystem leftFire;
    [SerializeField] ParticleSystem rightFire;
    //[SerializeField] InputAction fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessLocaleRotation();
        ProcessFire();
    }

    void ProcessTranslation()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float offsetX = horizontalInput * Time.deltaTime * controlSpeed;
        float offsetY = verticalInput * Time.deltaTime * controlSpeed;

        float newPosX = transform.localPosition.x + offsetX;
        float newPosY = transform.localPosition.y + offsetY;

        float clampedPosX = Mathf.Clamp(newPosX, LeftLimit, RightLimit);
        float clampedPosY = Mathf.Clamp(newPosY, DownLimit, UpLimit);

        transform.localPosition = new Vector3(clampedPosX, clampedPosY, transform.localPosition.z);
    }


    void ProcessLocaleRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = verticalInput * controllPitchFactor;
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float rolldueToControl = horizontalInput * controllRollFactor;


        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = yawDueToPosition;
        float roll = rolldueToControl;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }



    void ProcessFire()
    {
        if (Input.GetButton("Jump"))
        {
            leftFire.Play();
            rightFire.Play();
        }
        else
        {
            leftFire.Stop();
            rightFire.Stop();
        }
        
       
    }


}
