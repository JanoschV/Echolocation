using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ballMover : MonoBehaviour
{

    private float speed = 5f;
    float lockPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(speed*sx,speed* sy, 0);
    }

    // Update is called once per frame
    void Update()
    {

        // Update is called once per frame

            transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
      //  this.transform.position += new Vector3(speed,speed, 0);
        
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "Player")
           Time.timeScale = Random.Range(1.0f, 2.5f);
      
    }
}
