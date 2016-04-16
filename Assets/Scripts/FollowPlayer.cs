using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public float FollowSpeed;

    private bool m_Activated = true;
    private Transform m_Player;

    public void SetActivated(bool activated)
    {
        m_Activated = activated;
    }

    private void Start()
    {
        m_Player = GameObject.FindWithTag("Ship").transform;
    }

    private void LateUpdate()
    {
        if(m_Activated)
        {
            float speed = FollowSpeed * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0.0f, 1.0f);
            Vector3 distance = m_Player.position - transform.position;
            transform.position += distance * speed;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
        }
    }
}
