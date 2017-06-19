using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    Rigidbody RB;

    [SerializeField]
    float Speed;

    float MovementX;
    float MovementZ;
    [SerializeField]
    bool TransformMovement;


    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        MovementX = Input.GetAxis("Vertical");
        MovementZ = Input.GetAxis("Horizontal");


        if (!TransformMovement)
        {
            Vector3 MovementHorizontal = transform.forward * MovementX;
            Vector3 MovementVertical = transform.right * MovementZ;
            Vector3 Movement = MovementHorizontal + MovementVertical;
            RB.velocity = Movement * Speed;
        } else
        {
            Vector3 POS =  transform.position;
            POS += transform.forward * Time.deltaTime * MovementX * Speed;
            POS += transform.right * Time.deltaTime * MovementZ * Speed;

            transform.position = POS;

        }


    }




}
