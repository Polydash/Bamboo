using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipPhysics : MonoBehaviour
{
    public float ThrustSpeed;
    public float RotateSpeed;

    private Rigidbody2D m_Rigidbody;
    private bool m_ThrustRequested;
    private bool m_RotateRequested;
    private bool m_RotateInvertedRequested;

    public void SetThrust(bool thrust)
    {
        m_ThrustRequested = thrust;
    }

    public void SetRotate(bool rotate)
    {
        m_RotateRequested = rotate;
    }

    public void SetRotateInverted(bool rotate)
    {
        m_RotateInvertedRequested = rotate;
    }

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(m_ThrustRequested)
        {
            Vector2 thrustForce = transform.up * ThrustSpeed * Time.fixedDeltaTime;
            m_Rigidbody.AddForce(thrustForce, ForceMode2D.Force);
        }

        if(m_RotateRequested)
        {
            float rotateForce = RotateSpeed * Time.fixedDeltaTime;
            m_Rigidbody.AddTorque(rotateForce, ForceMode2D.Force);
        }

        if(m_RotateInvertedRequested)
        {
            float rotateForce = RotateSpeed * Time.fixedDeltaTime;
            m_Rigidbody.AddTorque(-rotateForce, ForceMode2D.Force);
        }
    }
}
