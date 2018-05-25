using UnityEngine;

[System.Serializable]
public class ConnectionPoint {
	public enum ConnectionDirection {
		North,
		East,
		South,
		West,
		Polar
	}

	//public RectTransform transform;
	public Color color = Color.white;
	public ConnectionDirection direction = ConnectionDirection.North;
	[Range(-1f, 1f)] public float position = 0f;
	public float weight = 1f;

	public Vector3 p {get; private set;}
	public Vector3 c {get; private set;}

	public void Reset() {
		color = Color.white;
		direction = ConnectionDirection.North;
		position = 0f;
		weight = 1f;
	}

	// POSTION used to adjust where end of line is, in reference to transform.  
	// They used it to render line origin at different points along the edges 
	// of rectangular transforms.  I changed the code include all transforms.
	// More modifications needed for commented out sections to work, if we need them.
	public void CalculateVectors(Transform transform) {         
		if (!transform) return;

		switch (direction) {
			case ConnectionDirection.North:
				// p = transform.TransformPoint(
				// 	transform.width/2f * position,
				// 	transform.height/2f,
				// 	0);
				p =transform.TransformPoint(0f,0f,0f);
				c = p + transform.up * weight;
				// c =transform.TransformPoint(1f,1f,1f);
			break;

			case ConnectionDirection.South:
				// p = transform.TransformPoint(
				// 	transform.sizeDelta.x/2f * position,
				// 	-transform.sizeDelta.y/2f,
				// 	0);
				p =transform.TransformPoint(0f,0f,0f);
				c = p - transform.up * weight;
				// c =transform.TransformPoint(1f,1f,1f);
			break;

			case ConnectionDirection.East:
				// p = transform.TransformPoint(
				// 	transform.sizeDelta.x/2f,
				// 	transform.sizeDelta.y/2f * position,
				// 	0);
				p =transform.TransformPoint(0f,0f,0f);
				c = p + transform.right * weight;
				// c =transform.TransformPoint(1f,1f,1f);
			break;

			case ConnectionDirection.West:
				// p = transform.TransformPoint(
				// 	-transform.sizeDelta.x/2f,
				// 	transform.sizeDelta.y/2f * position,
				// 	0);
				p =transform.TransformPoint(0f,0f,0f);
				c = p - transform.right * weight;
				// c =transform.TransformPoint(1f,1f,1f);
			break;

			default:
				float angle = Mathf.PI/2f - position*Mathf.PI;
				// p = transform.TransformPoint(
				// 	transform.sizeDelta.x/2f * Mathf.Cos(angle),
				// 	transform.sizeDelta.y/2f * Mathf.Sin(angle),
				// 	0);
				p =transform.TransformPoint(0f,0f,0f);
				c = p + transform.TransformDirection(Mathf.Cos(angle), Mathf.Sin(angle), 0) * weight;
				// c =transform.TransformPoint(1f,1f,1f);
			break;
		}
	}
}
