using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PacotePrefab : MonoBehaviour {

	public Toggle toggle;
	public Text num_pacote;
	public int pacote_id;
	public int collection_id;

	public void AdicionarRemoverPacote()
	{
		GameObject manager_object = GameObject.FindGameObjectWithTag("Manager");
		Manager manager = manager_object.GetComponent<Manager>();

		if(toggle.isOn){
			manager.ds.AddPacoteToCollection(collection_id, pacote_id);
		} else {
			manager.ds.RemovePacoteFromCollection(collection_id, pacote_id);
		}

		GameObject vercoleccao_object = GameObject.Find("VerColeccao");
		VerColeccao ver_coleccao = vercoleccao_object.GetComponent<VerColeccao>();

		Colection c = manager.ds.GetColection(collection_id);
		if(c != null){
			if(c.pacotes_in_collection < c.total_pacotes)
				ver_coleccao.pacotes_total.text = c.pacotes_in_collection + "/" + c.total_pacotes;
			else
				ver_coleccao.pacotes_total.text = "Completa";
		}
	}

}
