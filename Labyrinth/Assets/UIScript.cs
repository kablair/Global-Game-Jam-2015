using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Texture texture = Resources.Load("Assets/apple") as Texture;
		UnityEngine.UI.RawImage rImage =transform.GetComponent<UnityEngine.UI.RawImage>();
		rImage.renderer.material.SetTexture ("_MainTex",texture);

	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent(SpriteRenderer) = new Sprite();
	}
}
