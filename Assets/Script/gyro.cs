using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyro : MonoBehaviour {

    bool gyinfo;
    Gyroscope gyroscope;

    void Start () {
        gyinfo = SystemInfo.supportsGyroscope;
        gyroscope = Input.gyro;
        gyroscope.enabled = true;
	}

	void Update () {
        if (gyinfo)
        {
            Vector3 a = gyroscope.attitude.eulerAngles;
            a = new Vector3(-a.x, -a.y, a.z);
            this.transform.eulerAngles = a;
            this.transform.Rotate(Vector3.right * 90, Space.World);
        }
	}
}
