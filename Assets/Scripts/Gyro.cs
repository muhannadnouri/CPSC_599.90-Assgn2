using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // make sure you enable input
        Input.gyro.enabled = false;
        Input.gyro.enabled = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate on y-axis using gyroscope
        Quaternion deviceRotation = GyroToUnity(Input.gyro.attitude);
        Vector3 deviceEulerAngles = deviceRotation.eulerAngles;
        Vector3 transformEulerAngles = transform.rotation.eulerAngles;
        //transform.Rotate((new Vector3(transformEulerAngles.x, deviceEulerAngles.x, transformEulerAngles.z)) * (0.9f * Time.deltaTime));
        transform.Rotate((new Vector3(0, deviceEulerAngles.x, 0)) * (0.9f * Time.deltaTime));
    }
}
