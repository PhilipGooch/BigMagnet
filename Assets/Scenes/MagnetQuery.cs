using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetQuery : MonoBehaviour
{
    [SerializeField] private GameObject source;
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target == source)
        {
            return;
        }
        if (target.tag == "Player")
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();
            //does list contain rb?
            for (int i = 0; i < source.GetComponent<Magnetize>().target.Count; i++)
            {
                if (rb == source.GetComponent<Magnetize>().target[i])
                {
                    return;
                }
            }
            //if no, add to list
            source.GetComponent<Magnetize>().target.Add(rb);
        }
    }
}
