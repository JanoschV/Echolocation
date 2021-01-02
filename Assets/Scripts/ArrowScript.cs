using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody dest;
    private Vector3 direction;
    private float dX;
    private float dY;
    Rigidbody arrow;
    Quaternion rotate;
    Vector3 rote;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  
        dX = dest.position.x - rb.position.x;
        dY = dest.position.z - rb.position.z;
       
        rote = new Vector3(dX,0, dY);
        angle =Vector3.Angle(Vector3.forward, rote);
        rotate = Quaternion.AngleAxis(angle, Vector3.left);
      
        this.transform.position = new Vector3(rb.position.x + 1, rb.position.y + 3, rb.position.z);
        this.transform.rotation = Quaternion.FromToRotation(Vector3.left, rote);
        
    }
}
