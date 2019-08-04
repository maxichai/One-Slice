using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterNSeconds : MonoBehaviour
{
    //Animator anim;
    public float secondsToKill = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log("Being annoying");
        //anim = GetComponent<Animator>();        
        Destroy(gameObject, secondsToKill);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
