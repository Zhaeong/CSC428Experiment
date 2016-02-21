//using UnityEngine;
//using System.Collections;

//public class CameraController : MonoBehaviour
//{

//    public GameObject PlayerChar;
//    public float cameraXval = 0;
//    public float cameraYval = 3;
//    public float cameraZval = -5;

//    // Use this for initialization
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//        Vector3 cameraPosit = transform.position;

//        float cameraX = ((PlayerChar.transform.position.x + cameraXval) * .05F) + (transform.position.x * .95F);
//        float cameraY = ((PlayerChar.transform.position.y + cameraYval) * .05F) + (transform.position.y * .95F);
//        float cameraZ = ((PlayerChar.transform.position.z + cameraZval) * .05F) + (transform.position.z * .95F);

//        transform.position = new Vector3(cameraX, cameraY, cameraZ);
//        cameraPosit = new Vector3(cameraX - cameraXval, cameraY - cameraYval, cameraZ - cameraZval);
//        transform.LookAt(cameraPosit);

//        //}

//    }

//}

using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CameraController : MonoBehaviour
{

    public Transform target;
    public float distance = 2.5f;
    public float xSpeed = 30.0f;
    public float ySpeed = 30.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    private new Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                distance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}