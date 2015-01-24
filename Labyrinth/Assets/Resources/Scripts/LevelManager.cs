using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	Texture2D m_levelRawData;

	GameObject m_wallPrefab;
	GameObject m_floorPrefab;
	GameObject m_lightsPrefab;
	GameObject m_playerPrefab;
	GameObject m_cameraPrefab;

	GameObject m_player;
	Vector3 m_playerStartPosition;

	GameObject m_level;
	ArrayList m_wallLocations;
	
	void Start () {
		LoadPrefabs();
		LevelDataPreProcess();
		ProcessLevelData();

		InstantiateWalls();
		InstantiateFloor();
		InstantiateLight();

		InstantiatePlayer();
		InstantiateCamera();
	}

	void LoadPrefabs() {
		m_wallPrefab = Resources.Load("Prefabs/Wall") as GameObject;
		m_floorPrefab = Resources.Load("Prefabs/Floor") as GameObject;
		m_lightsPrefab = Resources.Load("Prefabs/Lights") as GameObject;
		m_playerPrefab = Resources.Load("Prefabs/Player") as GameObject;
		m_cameraPrefab = Resources.Load("Prefabs/Camera") as GameObject;
	}
	void LevelDataPreProcess() {
		m_levelRawData = Resources.Load ("LevelData/level1") as Texture2D;

		m_level = new GameObject();
		m_level.name = "Wall Container";

		m_wallLocations = new ArrayList();
	}
	void ProcessLevelData() {
		for (int i = 0; i < m_levelRawData.width; i++) {
			for (int j = 0; j < m_levelRawData.height; j++) {
				Color color = m_levelRawData.GetPixel(i, j);
				if (color == Color.black) {
					AddWallPosition(i, j);
				} else if (color == Color.green) {
					SetPlayerPosition(i, j);
					break;
				}
			}
		}
	}

	void SetPlayerPosition(int x, int z) {
		m_playerStartPosition = new Vector3 (x, 0.0f, z);
	}
	void InstantiatePlayer() {
		m_player = GameObject.Instantiate (m_playerPrefab, m_playerStartPosition, new Quaternion ()) as GameObject;
		m_player.name = "Player";
	}
	void InstantiateCamera() {
		GameObject camera = GameObject.Instantiate(m_cameraPrefab) as GameObject;
		camera.name = "Main Camera";
		camera.transform.parent = m_player.transform;
		camera.transform.localPosition = new Vector3(0.0f, 15.0f, 0.0f);
		camera.transform.Rotate(90.0f, 0.0f, 0.0f);
	}

	void AddWallPosition(int x, int z) {
		m_wallLocations.Add(new Vector3(x, 0.0f, z));
	}
	void InstantiateWalls() {
		foreach (Vector3 wallLocation in m_wallLocations) {
			GameObject wall = GameObject.Instantiate(m_wallPrefab, wallLocation, new Quaternion()) as GameObject;
			wall.name = "Wall";
			wall.transform.parent = m_level.transform;
		}
	}
	void InstantiateFloor() {
		GameObject floor = GameObject.Instantiate(m_floorPrefab) as GameObject;
		floor.name = "Floor";
		floor.transform.localScale = new Vector3(m_levelRawData.width, 1.0f, m_levelRawData.height);
		floor.transform.position = new Vector3(m_levelRawData.width / 2.0f - 0.5f, -1.0f, m_levelRawData.height / 2.0f - 0.5f);
	}
	void InstantiateLight() {
		GameObject lights = GameObject.Instantiate(m_lightsPrefab) as GameObject;
		lights.name = "Lights";
	}

	void Update() {
		//Debug.Log(1/Time.deltaTime + " FPS");
	}
}
