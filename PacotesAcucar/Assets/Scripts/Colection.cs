using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

public class Colection {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string name { get; set; }
	public int total_pacotes {get;set;}
	public int pacotes_in_collection {get;set;}

	public void AddPacoteEntry(int num_pacote, ISQLiteConnection c)
	{
		var pacote = new Pacote(){
			collection_id = Id,
			number = num_pacote,
			in_collection = false
		};
		c.Insert(pacote);
	}

	public void AddPacote(int pacote_id, ISQLiteConnection c)
	{
		var pa = from u in c.Table<Pacote>()
			     where u.collection_id == Id && u.Id == pacote_id
				 select u;

		Pacote p = pa.FirstOrDefault();

		p.in_collection = true;
		pacotes_in_collection++;

		c.Update(p);
		c.Update(this);
	}

	public void RemovePacote(int pacote_id, ISQLiteConnection c)
	{
		var pa = from u in c.Table<Pacote>()
			     where u.collection_id == Id && u.Id == pacote_id
			     select u;

		Pacote p = pa.FirstOrDefault();

		p.in_collection = false;
		pacotes_in_collection--;
		
		c.Update(p);
		c.Update(this);
	}

	public bool IsCollectionComplete()
	{
		return total_pacotes == pacotes_in_collection;
	}
}
