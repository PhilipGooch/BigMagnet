using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetize : MonoBehaviour
{
    public List<Rigidbody> target;
    //void OnTriggerEnter
    void Start()
    {
        target = new List<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 forward = transform.forward;
            for (int i = 0; i < target.Count; i++)
            {
                Vector3 other = target[i].transform.position - transform.position;

                if (Mathf.Abs(Vector3.Angle(forward, other)) > 15)
                {
                    continue;
                }
                target[i].AddForce((target[i].transform.position - transform.position) * 10000);
            }
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 forward = transform.forward;
            for (int i = 0; i < target.Count; i++)
            {
                Vector3 other = target[i].transform.position - transform.position;

                if (Mathf.Abs(Vector3.Angle(forward, other)) > 15)
                {
                    continue;
                }
                target[i].AddForce((transform.position - target[i].transform.position) * 10000);
            }
        }
    }
}
