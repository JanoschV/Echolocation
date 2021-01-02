using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocksc : MonoBehaviour
{
   public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
      //  rb.position = new Vector3(0, 0, 0);


    }
}
