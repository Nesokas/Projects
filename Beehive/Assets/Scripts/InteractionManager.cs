using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class InteractionManager : MonoBehaviour {

	public DataService ds;

	public GameObject evento_prefab;

	public GameObject main_menu;
	public GameObject adicionar_colmeia;
	public GameObject ver_colmeia;
	public GameObject adicionar_evento;

	public GameObject events_panel;

	public InputField name_colmeia;

	private int current_colmeia_id;

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
			Colmeia c = ds.InsertColmeia();
			current_colmeia_id = c.id;
			//ShowEventos(c);
		}
		adicionar_colmeia.SetActive(false);
		ver_colmeia.SetActive(true);
	}

	public void PressAdicionarEvento()
	{
		ver_colmeia.SetActive(false);
		adicionar_evento.SetActive(true);

	}

	public void PressAdicionarEventoA()
	{
		Evento e = ds.InsertEvento(Evento.TipoEvento.ACCAO_A, current_colmeia_id);
		ver_colmeia.SetActive(true);
		adicionar_evento.SetActive(false);
		ShowEventos(current_colmeia_id);
	}

	public void ShowEventos(int colmeia_id)
	{
		IEnumerable<Evento> eventos = ds.GetEventosInColmeia(colmeia_id);

		foreach(Evento e in eventos) {
			GameObject evento = (GameObject)Instantiate(evento_prefab);
			evento.transform.SetParent(events_panel.transform,false);
			Transform data = evento.transform.GetChild(0); // Data
			Debug.Log(e.date.Day);
			data.GetComponent<Text>().text = e.date.ToString();

		}
		//date.te

	}

	public void PressMenuInicial()
	{
		main_menu.SetActive(true);
		adicionar_colmeia.SetActive(false);
		ver_colmeia.SetActive(false);
	}



}
