using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class DefaultCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Creating;
    private Animator anim;
    public GameObject another;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Creating)
        {
            anim.SetBool("Creating", true);
        }

        if (Creating == false)
        {
            anim.SetBool("Creating", false);
        }
    }

    public void DestroyIt()
    {
        Creating = false;
    }
    
}
