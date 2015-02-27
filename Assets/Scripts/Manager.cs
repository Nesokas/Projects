using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public DataService ds;

	public GameObject coleccoes;
	public GameObject ver_coleccao;
	public GameObject nova_colecao;

	// Use this for initialization
	void Awake () {
		ds = new DataService("test.db");
		ds.CreateDB();
	}

	public void GotoNewColection()
	{
		coleccoes.SetActive(false);
		ver_coleccao.SetActive(false);
		nova_colecao.SetActive(true);
	}

	public void GotoVerColeccao(int id)
	{
		coleccoes.SetActive(false);

		VerColeccao vc = ver_coleccao.GetComponent<VerColeccao>();
		vc.coleccao_id = id;

		ver_coleccao.SetActive(true);
		nova_colecao.SetActive(false);
	}

	public void GotoColeccoes()
	{
		coleccoes.SetActive(true);
		ver_coleccao.SetActive(false);
		nova_colecao.SetActive(false);
	}
}
