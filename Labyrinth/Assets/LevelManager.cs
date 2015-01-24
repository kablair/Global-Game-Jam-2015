using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetupCamera();
		SetupLevel();
	}

	void SetupCamera() {
		GameObject camera = Resources.Load("Prefabs/Camera") as GameObject;
		camera.transform.position = new Vector3(10.0f, 10.0f, 10.0f);
		camera.transform.LookAt(gameObject.transform);
		Instantiate(camera);
	}

	void SetupLevel() {
		Texture2D testLevel = Resources.Load ("TestLevel") as Texture2D;
		for (int i = 0; i < testLevel.width; i++) {
			for (int j = 0; j < testLevel.height; j++) {
				Color color = testLevel.GetPixel(i, j);
				if (color == Color.black) {
					Vector3 position = new Vector3(i, 0.0f, j);
					GameObject cube = Resources.Load("Prefabs/Cube") as GameObject;
					
					Instantiate(cube, position, new Quaternion());
				}
			}
		}

		GameObject floor = Resources.Load("Prefabs/Cube") as GameObject;
		floor.transform.position = new Vector3(0, -1, 0);
		floor.transform.localScale = new Vector3(testLevel.width, 0.0f, testLevel.height);
		Instantiate(floor);
	}
}
