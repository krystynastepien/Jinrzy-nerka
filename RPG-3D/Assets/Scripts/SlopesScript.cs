using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopesScript : MonoBehaviour {

    public float hight;
    public float hightPadding = 0.02f;
    public LayerMask ground;
    public float maxGroundAngle = 120;
    public bool debug;

    public float groundAngle;

    public Vector3 forward;
    public RaycastHit hitinfo;
    public bool grounded;


	// Use this for initialization
	void Start () {
        hight = transform.localScale.y/2-3;
	}
	
	// Update is called once per frame
	void Update () {
        CalculateForward();
        CalculateGroundAngle();
        CheckGround();
        ApplyGravity();
        DrawDebugLines();
    }

    void CalculateForward()
    {
        if (!grounded)
        {
            forward = transform.forward;
            return;
        }

        forward = Vector3.Cross(hitinfo.normal, -transform.right);

    }

    void CalculateGroundAngle()
    {
        if (!grounded)
        {
            groundAngle = 90;
            return;
        }

        groundAngle = Vector3.Angle(hitinfo.normal, transform.forward);
    }

    void CheckGround()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out hitinfo, hightPadding + hight, ground))
        {
            if(Vector3.Distance(transform.position, hitinfo.point) < hight)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * hight, 5 * Time.deltaTime);
            }
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void ApplyGravity()
    {
        if (!grounded)
        {
            transform.position += Physics.gravity * Time.deltaTime ;
        }
    }

    void DrawDebugLines()
    {
        if (!debug) return;

        Debug.DrawLine(transform.position, transform.position + forward * 2 * hight);
        Debug.DrawLine(transform.position, transform.position - Vector3.up * hight, Color.green);
    }
}
