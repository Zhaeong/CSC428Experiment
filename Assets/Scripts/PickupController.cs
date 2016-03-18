using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        if (other.tag == "Player")
        {
            GameController GC = other.GetComponent<GameController>();
            GC.numPickups += 1;
        }
    }
}
