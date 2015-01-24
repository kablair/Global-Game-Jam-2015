using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	Texture2D m_levelData;
	GameObject player;

	// Use this for initialization
	void Start () {
		m_levelData = Resources.Load ("LevelData/level1") as Texture2D;
		Debug.Log("Loading Level...");
		Debug.Log("Level Dimensions = " + m_levelData.width + " x " + m_levelData.height);

		SetupLevel();
		SetupLight();
		SetupCamera();
	}
	
	void SetupLevel() {
		GameObject wallPrefab = Resources.Load("Prefabs/Wall") as GameObject;
		GameObject floorPrefab = Resources.Load("Prefabs/Floor") as GameObject;

		GameObject wallContainer = new GameObject();
		wallContainer.name = "Wall Container";
		for (int i = 0; i < m_levelData.width; i++) {
			for (int j = 0; j < m_levelData.height; j++) {
				Color color = m_levelData.GetPixel(i, j);
				if (color == Color.black) {
					GameObject wall = GameObject.Instantiate(wallPrefab, new Vector3(i, 0.0f, j), new Quaternion()) as GameObject;
					wall.transform.parent = wallContainer.transform;
					wall.name = "Wall";
				} else if (color == Color.green) {
					if (player != null) {
						Destroy(player);
					}

					GameObject playerPrefab = Resources.Load("Prefabs/Player") as GameObject;
					player = GameObject.Instantiate (playerPrefab, new Vector3 (i, 0.0f, j), new Quaternion ()) as GameObject;
					player.name = "Player";
					break;
				}
			}
		}

		GameObject floor = GameObject.Instantiate(floorPrefab) as GameObject;
		floor.name = "Floor";
		floor.transform.localScale = new Vector3(m_levelData.width, 1.0f, m_levelData.height);
		floor.transform.position = new Vector3(m_levelData.width / 2.0f - 0.5f, -1.0f, m_levelData.height / 2.0f - 0.5f);
	}
	void SetupLight() {
		//GameObject lightGameObject = new GameObject();
		//lightGameObject.name = "Light";
		//lightGameObject.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
		//lightGameObject.AddComponent(light);
		//lightGameObject.light.type = LightType.Directional;
	}
	void SetupCamera() {
		GameObject cameraPrefab = Resources.Load("Prefabs/Camera") as GameObject;
		
		GameObject camera = GameObject.Instantiate(cameraPrefab) as GameObject;
		camera.transform.parent = player.transform;
		camera.transform.localPosition = new Vector3(0.0f, 15.0f, 0.0f);
		camera.transform.Rotate(90.0f, 0.0f, 0.0f);
		camera.name = "Main Camera";
		//camera.transform.LookAt(gameObject.transform);
	}
}
