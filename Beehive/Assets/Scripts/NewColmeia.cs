using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;

public class NovaColeccao : MonoBehaviour {
	
	public InputField nome;
	
	public InteractionManager interaction_manager;
	public Image photo;
	public GameObject background;
	
	public GameObject inside_camera;
	
	void OnEnable()
	{
		nome.text = "";
	}
	
	public void Guardar()
	{
		if(nome.text.Length > 0){
			Colmeia c = interaction_manager.ds.InsertColmeia();
		//	manager.GotoVerColeccao(c.Id);
		}
	}
	/*
	public void Back()
	{
		manager.GotoColeccoes();
	}*/
	/*
	public void TakePicture()
	{
		inside_camera.SetActive(true);
		gameObject.SetActive(false);
		background.SetActive(false);
	}*/
	/*
	public void AdicionarImagem(string filename)
	{
		Texture2D image = new Texture2D(20, 20);
		image.LoadImage(File.ReadAllBytes(filename));
		
		photo.sprite = Sprite.Create(image, new Rect(), new Vector2(0.5f, 0.5f));
	}*/
}
