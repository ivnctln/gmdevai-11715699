using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public Transform goal;
    public float speed = 3;
    public float rotSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                         this.transform.position.y,
                                         goal.position.z);

        Vector3 direction = lookAtGoal - transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   Time.deltaTime * rotSpeed);

        if (Vector3.Distance(lookAtGoal, transform.position) > 2)
        {
            transform.position = Vector3.Lerp(transform.position, 
                                              lookAtGoal, 
                                              speed * Time.deltaTime);
        }
    }
}
