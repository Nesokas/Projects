using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class VerColeccao : MonoBehaviour {

	public Manager manager;

	public int coleccao_id;
	public GameObject pacote_prefab;

	public Text name_text;
	public Text pacotes_total;
	public Image todos_btn;
	public Image em_falta_btn;
	public Image adquiridos_btn;

	public GameObject todos;
	public GameObject confirmation_screen;

	Color selected = Color.gray;
	Color unselected = Color.white;

	IEnumerable<Pacote> pacotes;

	void OnEnable()
	{
		Colection c = manager.ds.GetColection(coleccao_id);

		name_text.text = c.name;

		if(c.pacotes_in_collection < c.total_pacotes)
			pacotes_total.text = c.pacotes_in_collection + "/" + c.total_pacotes;

		foreach(Transform child in todos.transform) {
			Destroy(child.gameObject);
		}

		pacotes = manager.ds.GetPacotesInColection(coleccao_id);

		foreach(Pacote p in pacotes){
			GameObject pacote = (GameObject)Instantiate(pacote_prefab, pacote_prefab.transform.position, pacote_prefab.transform.rotation);
			pacote.transform.SetParent(todos.transform, false);

			PacotePrefab pa = pacote.GetComponent<PacotePrefab>();
			pa.toggle.isOn = p.in_collection;
			pa.num_pacote.text = "" + p.number;
			pa.collection_id = p.collection_id;
			pa.pacote_id = p.Id;

		}

		todos_btn.color = selected;
		em_falta_btn.color = unselected;
		adquiridos_btn.color = unselected;

	}

	public void Todos()
	{
		if(todos_btn.color != selected){
			foreach(Transform child in todos.transform) {
				Destroy(child.gameObject);
			}

			foreach(Pacote p in pacotes){
				GameObject pacote = (GameObject)Instantiate(pacote_prefab, pacote_prefab.transform.position, pacote_prefab.transform.rotation);
				pacote.transform.SetParent(todos.transform, false);
				
				PacotePrefab pa = pacote.GetComponent<PacotePrefab>();
				pa.toggle.isOn = p.in_collection;
				pa.num_pacote.text = "" + p.number;
				pa.collection_id = p.collection_id;
				pa.pacote_id = p.Id;
				
			}
			
			todos_btn.color = selected;
			em_falta_btn.color = unselected;
			adquiridos_btn.color = unselected;
		}
	}

	public void EmFalta()
	{
		if(em_falta_btn.color != selected){
			foreach(Transform child in todos.transform) {
				Destroy(child.gameObject);
			}

			foreach(Pacote p in pacotes){
				if(!p.in_collection){
					GameObject pacote = (GameObject)Instantiate(pacote_prefab, pacote_prefab.transform.position, pacote_prefab.transform.rotation);
					pacote.transform.SetParent(todos.transform, false);
					
					PacotePrefab pa = pacote.GetComponent<PacotePrefab>();
					pa.collection_id = p.collection_id;
					pa.pacote_id = p.Id;
					pa.toggle.isOn = p.in_collection;
					pa.num_pacote.text = "" + p.number;
				}
			}
			
			todos_btn.color = unselected;
			em_falta_btn.color = selected;
			adquiridos_btn.color = unselected;
		}
	}

	public void Adquiridos()
	{
		if(adquiridos_btn.color != selected){
			foreach(Transform child in todos.transform) {
				Destroy(child.gameObject);
			}

			foreach(Pacote p in pacotes){
				if(p.in_collection){
					GameObject pacote = (GameObject)Instantiate(pacote_prefab, pacote_prefab.transform.position, pacote_prefab.transform.rotation);
					pacote.transform.SetParent(todos.transform, false);
					
					PacotePrefab pa = pacote.GetComponent<PacotePrefab>();
					pa.toggle.isOn = p.in_collection;
					pa.num_pacote.text = "" + p.number;
					pa.collection_id = p.collection_id;
					pa.pacote_id = p.Id;
				}
				
			}
			
			todos_btn.color = unselected;
			em_falta_btn.color = unselected;
			adquiridos_btn.color = selected;
		}
	}

	public void ConfirmarApagar()
	{
		confirmation_screen.SetActive(true);
	}

	public void Apagar()
	{
		manager.ds.DeleteColection(coleccao_id);
		confirmation_screen.SetActive(false);
		manager.GotoColeccoes();
	}

	public void NaoApagar()
	{
		confirmation_screen.SetActive(false);
	}

	public void Voltar()
	{
		manager.GotoColeccoes();
	}

}
