using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 0f;
    private Rigidbody rbody;
    public Vector3 moveDir;
    public LayerMask whatWall;
    public float maxDistFromWall = 0f;


    // Start is called before the first frame update
    void Start()
    {

        rbody = GetComponent<Rigidbody>();
        moveDir =  ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDir);
        
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = moveDir * moveSpeed;

        if(Physics.Raycast(transform.position, transform.forward, maxDistFromWall, whatWall))
        {
            moveDir = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDir);
             
        }

    }

    Vector3 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 3);
        Vector3 temp = new Vector3();

        if(i == 0){
            temp = transform.forward;

        }
        else if(i == 1){
            temp = -transform.forward;
        }
        else if(i == 2){
            temp = transform.right;
        }
        else if(i == 3){
            temp = -transform.right;
        }

        return temp;

    }

}
