using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChara : MonoBehaviour
{
    public Transform rayPosition;

    private Rigidbody m_rigidbody;
    private bool isGround;
    private bool isMoving;
    public bool IsGround { get => isGround; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }


    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        isGround = true;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(rayPosition.position, transform.position + (Vector3.down * 0.01f)))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        //　接地確認用にレイを視覚化
        Debug.DrawLine(rayPosition.position, transform.position + (Vector3.down * 0.01f), Color.red);
    }

    private void LateUpdate()
    {
        if (isGround&&!IsMoving)
        {
            m_rigidbody.velocity = Vector3.zero;
        }
        isMoving = false;
    }

    public void Move(Vector3 moveVec)
    {
        isMoving = true;
        m_rigidbody.velocity = moveVec;
    }
}
