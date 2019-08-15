using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAshi : MonoBehaviour
{
    public GameObject kata;
    public GameObject te;
    public GameObject jointPoint;

    public MoveChara moveChara;//手で移動するオブジェクト

    public float teLength = 1.0f;

    [SerializeField]
    private LayerMask layerMask = 0;

    private bool hitting = false;
    private Vector3 preHitPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 kataTote = te.transform.position - kata.transform.position;
        float teLen = teLength + kataTote.sqrMagnitude * 4.0f;
        if (hitting)
        {
            teLen += 0.1f;
        }
        //床の判定
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * teLen, Color.red);
        if (Physics.Raycast(ray, out hit ,teLen, layerMask))
        {
            Vector3 hitPos = hit.point;
            if (hitting)//初回でなければ
            {
                Vector3 moveVec =  preHitPos- hitPos;
                //moveVec.y = 0.0f;
                moveChara.Move(moveVec*50.0f);
            }
            //Debug.Log(transform.name + ":" + hitting);
            preHitPos = hitPos;
            hitting = true;
        }
        else{//条件によってOFF
            hitting = false;
            transform.rotation = jointPoint.transform.rotation;
            transform.position = jointPoint.transform.position;

        }
        
        this.transform.rotation = Quaternion.FromToRotation(Vector3.forward, kataTote);

        //腕のサイズ変更
        transform.localScale = new Vector3(1.0f, 1.0f, teLen);
    }
}
