
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerScript : MonoBehaviour
{
    public Transform magicSpawn;
    public GameObject magicAttackPrefab;
    public float magicMoveSpeed;
    private Animator player_Animator;
    public GameObject magicChargePrefab;
    public GameObject magicChargeClone;
    public VisualEffect powerUp;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        player_Animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            UseMagic();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            PowerUp();
        }

        if (magicChargeClone != null)
        {
            magicChargeClone.transform.eulerAngles = Vector3.zero;
        }
    }

    public void UseMagic()
    {
        player_Animator.SetTrigger("Attack");

        // Get the camera's forward direction
        Vector3 cameraForward = mainCamera.transform.forward;

        // Ignore the vertical component to prevent rotating up or down
        cameraForward.y = 0;

        // Rotate the player to face the camera's forward direction
        if (cameraForward != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(cameraForward);
            transform.rotation = newRotation;
        }

    }

    public void PowerUp()
    {
        player_Animator.SetTrigger("PowerUp");

        if (powerUp != null)
        {
            powerUp.Play();
        }
    }

    public void ShootMagic()
    {
        GameObject magicAttackClone = Instantiate(magicAttackPrefab, magicSpawn.transform.position, Quaternion.identity);
        Rigidbody rbody = magicAttackClone.GetComponent<Rigidbody>();

        // Get the camera's forward direction
        Vector3 cameraForward = mainCamera.transform.forward;

        // Ignore the vertical component to prevent shooting up or down
        cameraForward.y = 0;

        // Apply force in the direction the camera is looking
        rbody.AddForce(cameraForward.normalized * magicMoveSpeed, ForceMode.Impulse);
    }

    public void ChargeMagic()
    {
        magicChargeClone = Instantiate(magicChargePrefab, magicSpawn.transform.position, magicSpawn.transform.rotation, magicSpawn.transform);
        Rigidbody cbody = magicChargeClone.GetComponent<Rigidbody>();
    }
}