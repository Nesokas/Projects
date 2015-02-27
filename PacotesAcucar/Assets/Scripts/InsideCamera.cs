using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class InsideCamera : MonoBehaviour {

	WebCamTexture webCamTexture;
	public NovaColeccao nova_coleccao;
	public Renderer cube;
	public GameObject background;
	public GameObject nova_coleccao_screen;

	void OnEnable() 
	{
		webCamTexture = new WebCamTexture();
		cube.material.mainTexture = webCamTexture;
		webCamTexture.Play();
	}
	
	public void TakePhoto()
	{
		Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
		photo.SetPixels(webCamTexture.GetPixels());
		photo.Apply();
		
		//Encode to a PNG
		byte[] bytes = photo.EncodeToPNG();

#if UNITY_EDITOR
		string dataPath = Application.dataPath + "/StreamingAssets/Images/";
#else
		string dataPath = "jar:file://" + Application.dataPath + "!/assets/";
#endif

		//Write out the PNG. Of course you have to substitute your_path for something sensible
		string today_date = DateTime.Today.ToString();
		today_date = today_date.Replace('/', '_');
		today_date = today_date.Replace(' ', '_');

		string filename = dataPath + today_date + ".png";
		Debug.Log(filename);
		File.WriteAllBytes(filename, bytes);

		nova_coleccao.AdicionarImagem(filename);
		gameObject.SetActive(false);
		background.SetActive(true);
		nova_coleccao_screen.SetActive(true);
	}
}
