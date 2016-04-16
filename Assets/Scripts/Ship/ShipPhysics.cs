using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipPhysics : MonoBehaviour
{
    public float ThrustSpeed;

    private Rigidbody2D m_Rigidbody;
    private bool m_ThrustRequested;

    public void SetThrust(bool thrust)
    {
        m_ThrustRequested = thrust;
    }

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(m_ThrustRequested)
        {
            Vector2 thrustForce = Vector2.up * ThrustSpeed * Time.fixedDeltaTime;
            m_Rigidbody.AddForce(thrustForce, ForceMode2D.Force);
        }
    }
}
