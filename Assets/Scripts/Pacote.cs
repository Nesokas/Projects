using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

public class Pacote {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int number { get; set; }
	public int collection_id { get; set; }
	public bool in_collection { get; set; }
}
