using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectionPrefab : MonoBehaviour {

	public Text name_text;
	public Image image;
	public Text completion;

	public int id;

	public void VerColeccao()
	{
		GameObject manager_object = GameObject.FindGameObjectWithTag("Manager");
		Manager manager = manager_object.GetComponent<Manager>();

		manager.GotoVerColeccao(id);
	}
}

