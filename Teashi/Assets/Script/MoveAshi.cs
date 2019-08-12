using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAshi : MonoBehaviour
{
    public GameObject kata;
    public GameObject te;
    public GameObject jointPoint;

    public float teLength = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {//条件によってOFF
            transform.rotation = jointPoint.transform.rotation;
            transform.position = jointPoint.transform.position;
        }
        Vector3 vec3 = te.transform.position - kata.transform.position;
        this.transform.rotation = Quaternion.FromToRotation(Vector3.down, vec3);

        transform.localScale = new Vector3(1.0f, teLength + vec3.sqrMagnitude * 4.0f, 1.0f);
    }
}
