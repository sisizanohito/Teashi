using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnArea : MonoBehaviour
{
    public Transform returnPoint;

    private Vector3 vec3;
    // Start is called before the first frame update
    void Start()
    {
        if (returnPoint == null) {
            vec3 = new Vector3(0.0f, 1.0f, 0.0f);
        }
        else
        {
            vec3 = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.position = vec3;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        } 
    }
}
