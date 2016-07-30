using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public Vector2 mapSize;
	public Transform squarePrefab;
	
	[Range(0,1)]
	public float outlinePercent;
	
	void Start() {
		GenerateMap();
	}
	
	public void GenerateMap() {
		
		string holderName = "Generated Map";
		if (transform.FindChild(holderName)) {
			DestroyImmediate(transform.FindChild(holderName).gameObject);
		}
		
		Transform mapHolder = new GameObject(holderName).transform;
		mapHolder.parent = transform;

		for (int x = 0; x < mapSize.x; ++x) {
			for (int y = 0; y < mapSize.y; ++y) {

				Vector3 squarePosition = CoordToPos(x, y);

				Transform newSquare = (Transform)Instantiate(squarePrefab, 
				                                           squarePosition, 
				                                           Quaternion.Euler(Vector3.right * 90));
				newSquare.localScale = Vector3.one * (1 - outlinePercent);
				newSquare.parent = mapHolder;
			
			}
		}
		
	}

	Vector3 CoordToPos(int x, int y) {
		return new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
	}
}