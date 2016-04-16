using UnityEngine;
using System.Collections;

public class StripScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeY;

	private Vector2 savedOffset;
	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
		savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
	}

	void Update ()
	{
		float x = Mathf.Repeat (Time.time * scrollSpeed, tileSizeY * 4);
		x = x / tileSizeY;
		x = Mathf.Floor (x);
		x = x / 4;
		Vector2 offset = new Vector2 (x, savedOffset.y);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
		transform.position = startPosition + new Vector3 (-1,0,0) * newPosition;
	}

	void OnDisable () {
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}