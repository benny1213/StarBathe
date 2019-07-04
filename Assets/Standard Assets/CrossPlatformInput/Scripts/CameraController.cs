using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour
{
    public float moveforce = 0.1f;
    Camera camera;


	void Start ()
    {
        camera = this.GetComponent<Camera>();
	}
	
	void FixedUpdate ()
    {
        Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * moveforce * Time.deltaTime;
        transform.Translate(moveVec);
	}
}
