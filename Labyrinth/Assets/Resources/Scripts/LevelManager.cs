using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	public string LevelRawDataFileName;
	public float CameraHeight;

	Texture2D m_levelRawData;

	GameObject m_wallPrefab;
	GameObject m_floorPrefab;
	GameObject m_lightsPrefab;
	public GameObject m_playerPrefab;
	GameObject m_cameraPrefab;
	GameObject m_applePrefab;
	
	public GameObject m_player;
	Vector3 m_playerStartPosition;

	GameObject m_level;
	bool[,] m_wallLocations;
	
	void Start () {
		if (LevelRawDataFileName == "") return;
		Debug.Log ("hi the quick red fox");
		LoadPrefabs();
		LevelDataPreProcess();
		ProcessLevelData();

		InstantiateWalls();
		InstantiateFloor();
		InstantiateItems ();
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
		m_applePrefab = Resources.Load ("Prefabs/Apple") as GameObject;
	}
	void LevelDataPreProcess() {
		m_levelRawData = Resources.Load ("LevelData/" + LevelRawDataFileName) as Texture2D;

		m_level = new GameObject();
		m_level.name = "Wall Container";

		m_wallLocations = new bool[m_levelRawData.width,m_levelRawData.height];
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
				else if (color == Color.red){
					InstantiateApple(i,j);
				}
				else if ((color.r == 0) && (color.g == 0) && (color.b == 255)) {
					//Door Horizontal Open
				}
				else if ((color.r == 100) && (color.g == 0) && (color.b == 255)) {
					//Door Horizontal Closed
				}
				else if ((color.r == 0) && (color.g == 100) && (color.b== 255)) {
					//Door Vertical Open
				}
				else if ((color.r == 100) && (color.g == 100) && (color.b == 255)) {
					//Door Vertical Closed
				}
			}
		}
	}
	void InstantiateApple(int x, int z){
		GameObject m_apple = GameObject.Instantiate(m_applePrefab, new Vector3 (x, 1.0f, z), new Quaternion ()) as GameObject;
		m_apple.name = "Apple";
	}

	void SetPlayerPosition(int x, int z) {
		m_playerStartPosition = new Vector3 (x, 1f, z);
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
		camera.transform.localPosition = new Vector3(0.0f, 7.0f, -5.0f);
		camera.transform.Rotate(55.0f, 0.0f, 0.0f);
	}

	void InstantiateItems(){
		GameObject m_apple = GameObject.Instantiate(m_applePrefab, new Vector3 (112, 1.0f, 116), new Quaternion ()) as GameObject;
		m_apple.name = "Apple";
		m_apple.tag = "Item";

	}

	void SetWallLocation(int x, int z, bool isWall) {
		m_wallLocations[x, z] = isWall;
	}
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
					Vector3 scale = new Vector3(scaleX, 2.5f, scaleY);
					GameObject wall = GameObject.Instantiate(m_wallPrefab, position, new Quaternion()) as GameObject;
					wall.name = "Wall";
					wall.transform.parent = m_level.transform;
					wall.transform.GetChild(0).localScale = scale;

					float sHeight = scale.y;
					float sWidth = scale.z;
					float sLength = scale.x;
					Vector2[] mesh_UVs = wall.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh.uv;

					//Front
					mesh_UVs[ 2 ] = new Vector2( 0 , sHeight );
					mesh_UVs[ 3 ] = new Vector2( sLength , sHeight );
					mesh_UVs[ 0 ] = new Vector2( 0 , 0 );
					mesh_UVs[ 1 ] = new Vector2( sLength , 0 );
					
					
					//Back
					mesh_UVs[ 6 ] = new Vector2( 0 , sHeight );
					mesh_UVs[ 7 ] = new Vector2( sLength , sHeight );
					mesh_UVs[ 10 ] = new Vector2( 0 , 0 );
					mesh_UVs[ 11 ] = new Vector2( sLength , 0 );
					
					
					//Left
					mesh_UVs[ 19 ] = new Vector2( 0 , sHeight );
					mesh_UVs[ 17 ] = new Vector2( sWidth , sHeight );
					mesh_UVs[ 16 ] = new Vector2( 0 , 0 );
					mesh_UVs[ 18 ] = new Vector2( sWidth , 0 );
					
					
					//Right
					mesh_UVs[ 23 ] = new Vector2( 0 , sHeight );
					mesh_UVs[ 21 ] = new Vector2( sWidth , sHeight );
					mesh_UVs[ 20 ] = new Vector2( 0 , 0 );
					mesh_UVs[ 22 ] = new Vector2( sWidth , 0 );
					
					
					//Top
					mesh_UVs[ 4 ] = new Vector2( 0 , sWidth );
					mesh_UVs[ 5 ] = new Vector2( sLength , sWidth );
					mesh_UVs[ 8 ] = new Vector2( 0 , 0 );
					mesh_UVs[ 9 ] = new Vector2( sLength , 0 );
					
					
					//Bottom
					mesh_UVs[ 15 ] = new Vector2( 0 , sWidth );
					mesh_UVs[ 13 ] = new Vector2( sLength , sWidth );
					mesh_UVs[ 12 ] = new Vector2( 0 , 0 );
					mesh_UVs[ 14 ] = new Vector2( sLength , 0 );

					wall.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh.uv = mesh_UVs;
				}
			}
		}
	}
	void InstantiateFloor() {
		GameObject floor = GameObject.Instantiate(m_floorPrefab) as GameObject;
		floor.name = "Floor";
		floor.transform.GetChild(0).transform.localScale = new Vector3(m_levelRawData.width, 1.0f, m_levelRawData.height);
		floor.transform.position = new Vector3(m_levelRawData.width / 2.0f - 0.5f, -1.0f, m_levelRawData.height / 2.0f - 0.5f);
		floor.transform.GetChild(0).GetComponent<MeshFilter>().renderer.material.mainTextureScale = new Vector3(m_levelRawData.width, m_levelRawData.height);
	}
	void InstantiateLight() {
		GameObject lights = GameObject.Instantiate(m_lightsPrefab) as GameObject;
		lights.name = "Lights";
	}

	void Update() {
		//Debug.Log(1/Time.deltaTime + " FPS");
	}
}
