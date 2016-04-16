using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour {

	public float m_scrollSpeed;
	public float m_xDir;
	public float m_yDir;

	private Vector2 m_savedOffset;


	void Start () {
		m_savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
	}

	void Update () {
		float x = m_savedOffset.x;
		float y = m_savedOffset.y;
		if (m_xDir == 1)
		{
			x = Mathf.Repeat (Time.time * m_scrollSpeed, 1);
		}
		if (m_yDir == 1)
		{
			y = Mathf.Repeat (Time.time * m_scrollSpeed, 1);
		}
		Vector2 offset = new Vector2 (x, y);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

	void OnDisable () {
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", m_savedOffset);
	}
}
