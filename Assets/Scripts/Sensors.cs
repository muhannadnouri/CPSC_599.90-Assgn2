using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using EasyAR;

public class Sensors : MonoBehaviour
{
    private AndroidJavaObject plugin;

    void Start()
    {
#if UNITY_ANDROID
        plugin = new AndroidJavaClass("jp.kshoji.unity.sensor.UnitySensorPlugin").CallStatic<AndroidJavaObject>("getInstance");
        plugin.Call("startSensorListening", "accelerometer");
        plugin.Call("startSensorListening", "light");
        plugin.Call("startSensorListening", "gyroscope");
        plugin.Call("startSensorListening", "proximity");
        plugin.Call("startSensorListening", "pressure");
#endif
    }

    void Update()
    {
#if UNITY_ANDROID
        if (plugin != null)
        {
            float[] gyroscopeValues = plugin.Call<float[]>("getSensorValues", "gyroscope");
            float[] proximityValues = plugin.Call<float[]>("getSensorValues", "proximity");

            var kyle = GameObject.Find("Root");

            if (gyroscopeValues != null)
            {
                if (gyroscopeValues[1] > 1.0f)
                {
                    kyle.transform.Rotate(0, 100 * Time.deltaTime, 0);
                }
            }

            if (proximityValues != null)
            {
                if (proximityValues[0] < 1.0f)
                {
                    kyle.transform.Rotate(100 * Time.deltaTime, 0, 0);
                }

            }
        }

#endif
    }

}