using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class DissolvingController : MonoBehaviour
{

    public SkinnedMeshRenderer skinnedMesh;
    public VisualEffect VFXGraph;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;
    public Animator animator;
    private Material[] skinnedMaterials;
    public float dieDelay = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        

        //if(animator == null )
        //{
        //    animator = gameObject.AddComponent<Animator>();
        //}

      if (skinnedMesh !=null)
        {
            skinnedMaterials = skinnedMesh.materials;
        }  
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyUp(KeyCode.Q))
        {
            StartCoroutine(DissolveCo());
        }
    }

    public IEnumerator DissolveCo()
    {
        
        if(VFXGraph!= null)
        {
           
            VFXGraph.Play();
        }

        if (animator != null)
       animator.SetTrigger("Die");
        yield return new WaitForSeconds(dieDelay);

        if(skinnedMaterials.Length > 0)
        {
            float counter = 0;
            while (skinnedMaterials[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for(int i=0; i<skinnedMaterials.Length; i++)
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }

    public void StartDissolveCo()
    {
        StartCoroutine(DissolveCo());
    }
}


