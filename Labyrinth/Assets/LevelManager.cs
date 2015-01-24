using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetupCamera();
		SetupLevel();
		SetupLight();
	}

	void SetupCamera() {
		GameObject cameraPrefab = Resources.Load("Prefabs/Camera") as GameObject;

		GameObject camera = GameObject.Instantiate(cameraPrefab) as GameObject;
		camera.transform.position = new Vector3(10.0f, 10.0f, 10.0f);
		camera.transform.LookAt(gameObject.transform);
	}

	void SetupLevel() {
		GameObject cubePrefab = Resources.Load("Prefabs/Cube") as GameObject;

		GameObject cubeContainer = new GameObject();
		cubeContainer.name = "Cube Container";
		Texture2D testLevel = Resources.Load ("TestLevel") as Texture2D;
		for (int i = 0; i < testLevel.width; i++) {
			for (int j = 0; j < testLevel.height; j++) {
				Color color = testLevel.GetPixel(i, j);
				if (color == Color.black) {
					GameObject cube = GameObject.Instantiate(cubePrefab, new Vector3(i, 0.0f, j), new Quaternion()) as GameObject;
					cube.transform.parent = cubeContainer.transform;
					cube.name = "Cube";
				}
			}
		}

		GameObject floor = GameObject.Instantiate(cubePrefab) as GameObject;
		floor.name = "Floor";
		floor.transform.localScale = new Vector3(testLevel.width, 1.0f, testLevel.height);
		floor.transform.position = new Vector3(testLevel.width / 2.0f - 0.5f, -1.0f, testLevel.height / 2.0f - 0.5f);
	}

	void SetupLight() {
		//GameObject lightGameObject = new GameObject();
		//lightGameObject.name = "Light";
		//lightGameObject.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
		//lightGameObject.AddComponent(light);
		//lightGameObject.light.type = LightType.Directional;
	}
}
