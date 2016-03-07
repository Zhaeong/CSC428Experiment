using UnityEngine;
using System.Collections;

public class WallScale : MonoBehaviour {
    public float scale;
    public float scaleFactor;
    public float interval;

    float timer;

    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update () {
        if (timer >= interval)
        {
            scaleFactor = -scaleFactor;
            timer = 0f;
        }

        scale += scaleFactor;
        transform.localScale = new Vector3(1, 1, scale);
        timer += Time.deltaTime;
    }
}
