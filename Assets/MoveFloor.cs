using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour
{
    public float speed;

    bool movePos;
    Vector3 dir;
    float timer;

    void Start()
    {
        timer = 0f;

        if (gameObject.name == "Moving Floor")
        {
            dir = Vector3.forward;

        } else
        {
            dir = Vector3.up;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            dir = -dir;
            timer = 0f;
        }

        transform.Translate(-dir * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}