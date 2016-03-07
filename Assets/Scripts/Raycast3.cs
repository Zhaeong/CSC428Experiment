using UnityEngine;
using System.Collections;

public class Raycast3 : MonoBehaviour
{

    public static float distance3 = 5;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            distance3 = hit.distance;
        }
    }
}