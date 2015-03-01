using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;

public class InteractionManager : MonoBehaviour {

	public DataService ds;

	public GameObject main_menu;
	public GameObject adicionar_colmeia;
	public GameObject ver_colmeia;

	public InputField name_colmeia;

	void Awake()
	{
		ds = new DataService("test.db");
		ds.CreateDB();
	}

	public void PressScannearColmeia()
	{
		Debug.Log("SCANNEAR COLMEIA");
		main_menu.SetActive(false);
		adicionar_colmeia.SetActive(true);
		
	}

	public void GuardarColmeia()
	{
		if(name_colmeia.text.Length > 0 && !ds.IsRepeatedName(name_colmeia.text)){
			Colmeia c = ds.InsertColmeia(name_colmeia.text, 29,09,87);
		}
		adicionar_colmeia.SetActive(false);
		ver_colmeia.SetActive(true);
	}

	public void PressVerColmeias()
	{
		Debug.Log("VER COLMEIAS");
	}

	public void PressMenuInicial()
	{
		main_menu.SetActive(true);
		adicionar_colmeia.SetActive(false);
		ver_colmeia.SetActive(false);
	}

}
