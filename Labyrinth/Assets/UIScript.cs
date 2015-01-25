using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	// Use this for initialization

	void Start () {
		Texture texture = Resources.Load("Assets/apple") as Texture2D;
		UnityEngine.UI.RawImage rImage =transform.GetComponent<UnityEngine.UI.RawImage>();
		rImage.texture = texture;

	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent(SpriteRenderer) = new Sprite();
	}
}
