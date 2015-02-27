using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Coleccoes : MonoBehaviour {

	public GameObject collection_prefab;
	public GameObject colecoes_incompletas;
	public Manager manager;

	public Image incompletas;
	public Image completas;
	public Image todas;

	Color selected = Color.gray;
	Color unselected = Color.white;

	IEnumerable<Colection> collections;
	
	void OnEnable()
	{
		incompletas.color = selected;
		completas.color = unselected;
		todas.color = unselected;

		collections = manager.ds.GetAllCollections();
		foreach(Transform child in colecoes_incompletas.transform) {
			Destroy(child.gameObject);
		}

		if(collections != null){
			foreach(Colection c in collections){
				if(c.pacotes_in_collection < c.total_pacotes){
					GameObject collection = (GameObject)Instantiate(collection_prefab, collection_prefab.transform.position, collection_prefab.transform.rotation);
					collection.transform.SetParent(colecoes_incompletas.transform, false);
					
					CollectionPrefab cp = collection.GetComponent<CollectionPrefab>();
					cp.name_text.text = c.name;
					cp.id = c.Id;
					cp.completion.text = c.pacotes_in_collection + "/" + c.total_pacotes;
				}
			}
		}

	}

	public void Incompletas()
	{
		if(incompletas.color != selected){

			foreach(Transform child in colecoes_incompletas.transform) {
				Destroy(child.gameObject);
			}

			foreach(Colection c in collections){
				if(c.pacotes_in_collection < c.total_pacotes){
					GameObject collection = (GameObject)Instantiate(collection_prefab, collection_prefab.transform.position, collection_prefab.transform.rotation);
					collection.transform.SetParent(colecoes_incompletas.transform, false);
					
					CollectionPrefab cp = collection.GetComponent<CollectionPrefab>();
					cp.name_text.text = c.name;
					cp.id = c.Id;
					cp.completion.text = c.pacotes_in_collection + "/" + c.total_pacotes;
				}
			}
			
			incompletas.color = selected;
			completas.color = unselected;
			todas.color = unselected;
		}
	}

	public void Completas()
	{
		if(completas.color != selected){
			foreach(Transform child in colecoes_incompletas.transform) {
				Destroy(child.gameObject);
			}

			foreach(Colection c in collections){
				if(c.pacotes_in_collection == c.total_pacotes){
					GameObject collection = (GameObject)Instantiate(collection_prefab, collection_prefab.transform.position, collection_prefab.transform.rotation);
					collection.transform.SetParent(colecoes_incompletas.transform, false);
					
					CollectionPrefab cp = collection.GetComponent<CollectionPrefab>();
					cp.name_text.text = c.name;
					cp.id = c.Id;
					cp.completion.text = "Completa";
				}
			}
			
			incompletas.color = unselected;
			completas.color = selected;
			todas.color = unselected;
		}
	}

	public void Todas()
	{
		if(todas.color != selected){
			foreach(Transform child in colecoes_incompletas.transform) {
				Destroy(child.gameObject);
			}

			foreach(Colection c in collections){
				GameObject collection = (GameObject)Instantiate(collection_prefab, collection_prefab.transform.position, collection_prefab.transform.rotation);
				collection.transform.SetParent(colecoes_incompletas.transform, false);
				
				CollectionPrefab cp = collection.GetComponent<CollectionPrefab>();
				cp.name_text.text = c.name;
				cp.id = c.Id;
				if(c.pacotes_in_collection < c.total_pacotes)
					cp.completion.text = c.pacotes_in_collection + "/" + c.total_pacotes;
				else
					cp.completion.text = "Completa";
			}
			
			incompletas.color = unselected;
			completas.color = unselected;
			todas.color = selected;
		}
	}

	public void AdicionarColeccao()
	{
		manager.GotoNewColection();
	}
}
