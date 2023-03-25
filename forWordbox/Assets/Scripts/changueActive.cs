using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changueActive : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField] Animator anim; 
    void Start()
    {
       
    }

   

    public void changue() {

        anim.SetTrigger("like");
    }
}
