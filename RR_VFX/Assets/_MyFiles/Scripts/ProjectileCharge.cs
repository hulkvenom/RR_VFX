using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ProjectileCharge : MonoBehaviour
{
    float delay = 1.12f;
    [SerializeField] VisualEffect effect;
    [SerializeField] float growSpeed;

    float size;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, delay);
        size += growSpeed * Time.deltaTime;
        effect.SetFloat("Size", size);
    }


}

