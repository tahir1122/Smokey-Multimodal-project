using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarGraph : Graphs {

	public  float pillarHeight = 30f;

	public void BuildGraph (Transform[] transforms, string color, Transform nodePrefab){

		Connection conn = new Connection();

		foreach (Transform dp in transforms){

			Transform nodeTrf = GameObject.Instantiate (nodePrefab) as Transform;
			nodeTrf.parent = dp;

			nodeTrf.localPosition = new Vector3 (0f, pillarHeight, 0f);
			nodeTrf.localRotation = Quaternion.identity;
			nodeTrf.localScale = new Vector3 (1f, 1f, 1f);
			
			ConnectionManager.CreateConnection(dp, nodeTrf);
			conn = ConnectionManager.FindConnection(dp, nodeTrf);

			conn.points[0].color = SetColor(color);
			conn.points[1].color = SetColor(color);
			
			conn.points[0].weight = .0f;
			conn.points[1].weight = .0f;

			nodes.Add(nodeTrf);
			connections.Add(conn);

		}
		
	}

	public static Color SetColor(string c) 
	{
		Color color = Color.white;

		switch (c) {
			case "red":
				color = Color.red;
				break;
			case "blue":
				color = Color.blue;
				break;
			case "green":
				color = Color.green;
				break;
			case "magenta":
				color = Color.magenta;
				break;
			case "yellow":
				color = Color.yellow;
				break;
			case "cyan":
				color = Color.cyan;
				break;
			case "unavailable":
				color = Color.white;;
				break;
			default:
				break;
		}
		return color;
	}
}
