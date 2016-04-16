using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 m_position;
	private Vector3 m_velocity = Vector3.zero;
	private float m_smoothTime = .3f;

	void Start () 
	{
		m_position = transform.position;
	}

	void Update () 
	{
		if (Input.GetKeyDown("z"))
		{
			m_position = new Vector3(m_position.x,m_position.y + 5f,m_position.z);
			transform.position = Vector3.SmoothDamp(transform.position,m_position, ref m_velocity, m_smoothTime);
		}

		if (Input.GetKeyDown("q"))
		{
			m_position = new Vector3(m_position.x - 5f,m_position.y,m_position.z);
			transform.position = Vector3.SmoothDamp(transform.position,m_position, ref m_velocity, m_smoothTime);
		}

		if (Input.GetKeyDown("s"))
		{
			m_position = new Vector3(m_position.x,m_position.y - 5f,m_position.z);
			transform.position = Vector3.SmoothDamp(transform.position,m_position, ref m_velocity, m_smoothTime);
		}

		if (Input.GetKeyDown("d"))
		{
			m_position = new Vector3(m_position.x +5f,m_position.y,m_position.z);
			transform.position = Vector3.SmoothDamp(transform.position,m_position, ref m_velocity, m_smoothTime);
		}
	}
}
