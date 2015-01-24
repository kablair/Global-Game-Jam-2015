using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetupCamera();
		SetupLevel();
		SetupLight();
		SetupPlayer();
	}

	void SetupCamera() {
		GameObject cameraPrefab = Resources.Load("Prefabs/Camera") as GameObject;

		GameObject camera = GameObject.Instantiate(cameraPrefab) as GameObject;
		camera.transform.position = new Vector3(5.0f, 10.0f, 5.0f);
		camera.transform.Rotate(90.0f, 0.0f, 0.0f);
		camera.name = "Main Camera";
		//camera.transform.LookAt(gameObject.transform);
	}

	void SetupLevel() {
		GameObject wallPrefab = Resources.Load("Prefabs/Wall") as GameObject;
		GameObject floorPrefab = Resources.Load("Prefabs/Floor") as GameObject;

		GameObject wallContainer = new GameObject();
		wallContainer.name = "Wall Container";
		Texture2D testLevel = Resources.Load ("TestLevel") as Texture2D;
		for (int i = 0; i < testLevel.width; i++) {
			for (int j = 0; j < testLevel.height; j++) {
				Color color = testLevel.GetPixel(i, j);
				if (color == Color.black) {
					GameObject wall = GameObject.Instantiate(wallPrefab, new Vector3(i, 0.0f, j), new Quaternion()) as GameObject;
					wall.transform.parent = wallContainer.transform;
					wall.name = "Cube";
				}
			}
		}

		GameObject floor = GameObject.Instantiate(floorPrefab) as GameObject;
		floor.name = "Floor";
		floor.transform.localScale = new Vector3(testLevel.width, 1.0f, testLevel.height);
		floor.transform.position = new Vector3(testLevel.width / 2.0f - 0.5f, -1.0f, testLevel.height / 2.0f - 0.5f);
	}

	void SetupPlayer(){
		GameObject playerPrefab = Resources.Load("Prefabs/Player") as GameObject;
		GameObject player = GameObject.Instantiate (playerPrefab, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ()) as GameObject;
	}
	void SetupLight() {
		//GameObject lightGameObject = new GameObject();
		//lightGameObject.name = "Light";
		//lightGameObject.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
		//lightGameObject.AddComponent(light);
		//lightGameObject.light.type = LightType.Directional;
	}
}
