﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAshi : MonoBehaviour
{
    public GameObject kata;
    public GameObject te;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec3 = te.transform.position - kata.transform.position;
        this.transform.rotation = Quaternion.FromToRotation(Vector3.down, vec3);
    }
}
