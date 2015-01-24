using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	public string LevelRawDataFileName;
	public Material WallMaterial;
	public float CameraHeight;

	Texture2D m_levelRawData;

	GameObject m_wallPrefab;
	GameObject m_floorPrefab;
	GameObject m_lightsPrefab;
	GameObject m_playerPrefab;
	GameObject m_cameraPrefab;
	GameObject m_itemPrefab;

	GameObject m_player;
	GameObject m_item1;
	Vector3 m_playerStartPosition;
	Vector3 m_item1StartPosition;
	GameObject m_level;
	bool[,] m_wallLocations;

	//bool[,] m_wallCorners;
	//Mesh m_wallMesh;

	
	void Start () {
		if (LevelRawDataFileName == "") return;

		LoadPrefabs();
		LevelDataPreProcess();
		ProcessLevelData();
		SetItemStartPosition (114, 20);
		//InstantiateWallMesh();
		InstantiateWalls();
		InstantiateFloor();

		InstantiateLight();

		InstantiatePlayer();
		InstantiateItems ();
		InstantiateCamera();
	}

	void LoadPrefabs() {
		m_wallPrefab = Resources.Load("Prefabs/Wall") as GameObject;
		m_floorPrefab = Resources.Load("Prefabs/Floor") as GameObject;
		m_lightsPrefab = Resources.Load("Prefabs/Lights") as GameObject;
		m_playerPrefab = Resources.Load("Prefabs/Player") as GameObject;
		m_cameraPrefab = Resources.Load("Prefabs/Camera") as GameObject;
		m_itemPrefab = Resources.Load("Prefabs/Item 1") as GameObject;
	}
	void LevelDataPreProcess() {
		m_levelRawData = Resources.Load ("LevelData/" + LevelRawDataFileName) as Texture2D;

		m_level = new GameObject();
		m_level.name = "Wall Container";

		m_wallLocations = new bool[m_levelRawData.width,m_levelRawData.height];
		//m_wallCorners = new bool[m_levelRawData.width + 1,m_levelRawData.height + 1];
	}
	void ProcessLevelData() {
		for (int i = 0; i < m_levelRawData.width; i++) {
			for (int j = 0; j < m_levelRawData.height; j++) {
				Color color = m_levelRawData.GetPixel(i, j);
				if (color == Color.black) {
					SetWallLocation(i, j, true);
				} else {
					SetWallLocation(i, j, false);
				}

				if (color == Color.green) {
					SetPlayerPosition(i, j);
				}
			}
		}
	}

	void SetPlayerPosition(int x, int z) {
		m_playerStartPosition = new Vector3 (x, 1f, z);
	}

	void SetItemStartPosition(int x, int z) {
		m_item1StartPosition = new Vector3 (x, 1f, z);
	}
	void InstantiatePlayer() {
		m_player = GameObject.Instantiate (m_playerPrefab, m_playerStartPosition, new Quaternion ()) as GameObject;
		m_player.name = "Player";
		m_player.tag = "Player";
	}
	void InstantiateCamera() {
		GameObject camera = GameObject.Instantiate(m_cameraPrefab) as GameObject;
		camera.name = "Main Camera";
		camera.transform.parent = m_player.transform;
		camera.transform.localPosition = new Vector3(0.0f, CameraHeight, 0.0f);
		camera.transform.Rotate(90.0f, 0.0f, 0.0f);
	}
	void InstantiateItems() {
		m_item1 = GameObject.Instantiate (m_itemPrefab, m_item1StartPosition, new Quaternion ()) as GameObject;
		m_item1.name = "Item1";

	}


	void SetWallLocation(int x, int z, bool isWall) {
		m_wallLocations[x, z] = isWall;

		//m_wallCorners[x,z] = true;
		//m_wallCorners[x+1,z+1] = true;
	}
	/*void InstantiateWallMesh() {
		m_wallMesh = new Mesh();
		m_wallMesh.name = "Prog Wall Mesh";

		int offset = 0;
		List<Vector3> vertices = new List<Vector3>();
		List<Vector2> uv = new List<Vector2>();
		List<int> triangles = new List<int>();

		foreach (Vector3 wallLocation in m_wallLocations) {
			vertices.Add(new Vector3(wallLocation.x - 0.5f, -0.5f, wallLocation.z - 0.5f));
			vertices.Add(new Vector3(wallLocation.x + 0.5f, -0.5f, wallLocation.z - 0.5f));
			vertices.Add(new Vector3(wallLocation.x - 0.5f, -0.5f, wallLocation.z + 0.5f));
			vertices.Add(new Vector3(wallLocation.x + 0.5f, -0.5f, wallLocation.z + 0.5f));

			uv.Add(new Vector2 (0, 0));
			uv.Add(new Vector2 (1, 0));
			uv.Add(new Vector2 (0, 1));
			uv.Add(new Vector2 (1, 1));

			triangles.Add(offset);
			triangles.Add(offset+3);
			triangles.Add(offset+1);
			triangles.Add(offset);
			triangles.Add(offset+2);
			triangles.Add(offset+3);

			offset += 4;
		}

		m_wallMesh.vertices = vertices.ToArray();
		m_wallMesh.uv = uv.ToArray();
		m_wallMesh.triangles = triangles.ToArray();
		m_wallMesh.RecalculateNormals();

		GameObject WallsObject = new GameObject();
		WallsObject.name = "Prog Wall Object";
		WallsObject.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
		WallsObject.AddComponent<MeshFilter>();
		WallsObject.GetComponent<MeshFilter>().mesh = m_wallMesh;
		WallsObject.AddComponent<MeshRenderer>();
		WallsObject.GetComponent<MeshRenderer>().material = WallMaterial;
		WallsObject.GetComponent<MeshRenderer>().castShadows = false;
		WallsObject.GetComponent<MeshRenderer>().receiveShadows = false;
		WallsObject.AddComponent<MeshCollider>();
	}*/
	void InstantiateWalls() {
		int width = m_levelRawData.width;
		int height = m_levelRawData.height;

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if (m_wallLocations[x,y]) {

					int dx = 0;
					while ((x + dx < width) && (m_wallLocations[x+dx,y])) {
						dx++;
					}
					int x2 = x+dx;

					int dx2 = 0;
					int dy = 1;
					while ((y + dy < height)) {
						if (!m_wallLocations[x,y+dy]) break;
						while ((x + dx2 < width) && (m_wallLocations[x+dx2,y+dy])) {
							dx2++;
						}
						dy++;
						if (dx2 < dx) break;
						dx2 = 0;
					}
					int y2 = y+dy;

					for (int x3 = x; x3 < x2; x3++) {
						for (int y3 = y; y3 < y2; y3++) {
							m_wallLocations[x3,y3] = false;
						}
					}

					int scaleX = x2-x;
					int scaleY = y2-y;

					Vector3 position = new Vector3(x+scaleX/2.0f-0.5f, 0.0f, y+scaleY/2.0f-0.5f);
					Vector3 scale = new Vector3(scaleX, 1.0f, scaleY);
					GameObject wall = GameObject.Instantiate(m_wallPrefab, position, new Quaternion()) as GameObject;
					wall.name = "Wall";
					wall.transform.parent = m_level.transform;
					wall.transform.localScale = scale;
				}
			}
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
