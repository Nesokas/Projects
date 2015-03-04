using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

public class Colmeia {

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name{ get; set; }


	public void AddEventoEntry(Evento evento, ISQLiteConnection c)
	{
	//	var pa = from colmeia in c.Table<Colmeia>()
	//		where colmeia.id == id && colmeia.id == 
	}

	//public void SetAction(
}

