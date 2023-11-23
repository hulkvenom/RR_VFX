using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform magicSpawn;
    public GameObject magicAttackPrefab;
    public float magicMoveSpeed;
    private Animator player_Animator;
    

    // Start is called before the first frame update
    void Start()
    {
        player_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            
            UseMagic();
            
        }
    }

    public void UseMagic()
    {
        player_Animator.SetTrigger("Attack");
    }

    public void ShootMagic()
    {        
        GameObject magicAttackClone = Instantiate(magicAttackPrefab, magicSpawn.transform.position, magicSpawn.transform.rotation);
        Rigidbody rbody = magicAttackClone.GetComponent<Rigidbody>();
        rbody.AddForce(magicAttackClone.transform.forward * magicMoveSpeed, ForceMode.Impulse);
    }

}
