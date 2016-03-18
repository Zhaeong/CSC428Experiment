using UnityEngine;
using System.Collections;

public class RespawnController : MonoBehaviour {

    public Transform SpawnPointA;
    public Transform SpawnPointB;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = SpawnPointA.position;
        }
    }
}
