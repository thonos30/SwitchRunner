using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float kecepatan = 150;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(Physics.gravity.y > 0)
        {
            Physics.gravity *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity *= -1;
        }

        rb.velocity = new Vector3(kecepatan, rb.velocity.y, rb.velocity.z);
    }

     void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="Rintangan")
        {
            Destroy(this.gameObject);
        }
    }
}
