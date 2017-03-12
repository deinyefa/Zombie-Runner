using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraFollow : MonoBehaviour {

    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;
    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
        follow = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        //- setting the target position to be the correct offset from the hovercraft
        targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
        Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.cyan);
        Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.green);
        Debug.DrawLine(follow.position, targetPosition, Color.red);

        //- making a smooth transition b/w its current position and the position it wants to be at
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        //- makes sure the camera is looking the right way
        transform.LookAt(follow);
    }
}
