using UnityEngine;
using System.Collections;

public class InteractionManager : MonoBehaviour {

	public DataService ds;

	public GameObject main_menu;
	public GameObject grelha_colmeias;

	void Awake()
	{
		ds = new DataService("test.db");
		ds.CreateDB();
	}

	public void PressScannearColmeia()
	{
		Debug.Log("SCANNEAR COLMEIA");
		main_menu.SetActive(false);
		grelha_colmeias.SetActive(true);

			Colmeia c = ds.InsertColmeia("whatevs", 29,09,87);
		
	}

	public void PressVerColmeias()
	{
		Debug.Log("VER COLMEIAS");
	}

}
