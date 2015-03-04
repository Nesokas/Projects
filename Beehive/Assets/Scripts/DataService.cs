using UnityEngine;
using System.Collections;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using SQLite4Unity3d;
using System.Collections.Generic;

public class DataService {

	private ISQLiteConnection _connection;

	public DataService(string DatabaseName)
	{
		var factory = new Factory();

#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
		// check if file exists in Application.persistentDataPath
		var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);
		if (!File.Exists(filepath))
		{
			Debug.Log("Database not in Persistent path");
			// if it doesn't ->
			// open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
			var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
			while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
			// then save to Application.persistentDataPath
			File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
			var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
#elif UNITY_WP8
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			
#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
#endif
			
			Debug.Log("Database written");
		}
		
		var dbPath = filepath;
#endif
		Debug.Log(dbPath);
		_connection = factory.Create(dbPath);
		Debug.Log("Final PATH: " + dbPath);
	}

	public void CreateDB()
	{
#if UNITY_EDITOR
		_connection.DropTable<Colmeia>();
		_connection.DropTable<Evento>();
#endif

		_connection.CreateTable<Colmeia>();
		_connection.CreateTable<Evento>();
	}

	public Colmeia InsertColmeia()
	{
		Colmeia colmeia = new Colmeia();
		_connection.Insert(colmeia);

	//	_connection.Table<Colmeia>();
		Debug.Log(_connection.Table<Colmeia>().Count());
		return colmeia;
	}

	public Evento InsertEvento(Evento.TipoEvento tipo_evento, int colmeia_id, int day, int month, int year)
	{
		Evento evento = new Evento(tipo_evento, colmeia_id, day, month, year);
		_connection.Insert(evento);
		return evento;
	}

	public bool IsRepeatedName(string name)
	{
		if(_connection.Table<Colmeia>().Where(x => x.name == name).FirstOrDefault() == null)
			return false;
		else
			return true;
	}

	public IEnumerable<Evento> GetEventosInColmeia(int colmeia_id)
	{
		return _connection.Table<Evento>().Where(x => x.id == colmeia_id);
	}

	/*
	public Colection InsertCollection(string name_collection, int total_pacotes_collection)
	{
		var colection = new Colection{
			name = name_collection,
			total_pacotes = total_pacotes_collection,
			pacotes_in_collection = 0
		};

		_connection.Insert(colection);
		Debug.Log(colection.Id);

		for(int i = 0; i < total_pacotes_collection; i++){
			colection.AddPacoteEntry(i+1, _connection);
		}

		return colection;
	}

	public void AddPacoteToCollection(int collection_id, int pacote_id)
	{
		if(_connection.Table<Pacote>().Where(x=>x.Id == pacote_id).FirstOrDefault() != null){
			Colection c = _connection.Table<Colection>().Where(x => x.Id == collection_id).FirstOrDefault();
			c.AddPacote(pacote_id, _connection);
		}
	}

	public void RemovePacoteFromCollection(int collection_id, int pacote_id)
	{
		Colection c = _connection.Table<Colection>().Where(x => x.Id == collection_id).FirstOrDefault();
		c.RemovePacote(pacote_id, _connection);
	}

	public Colection GetColection(int collection_id)
	{
		return _connection.Table<Colection>().Where(x => x.Id == collection_id).FirstOrDefault();
	}



	public IEnumerable<Colection> GetAllCollections()
	{
		return _connection.Table<Colection>();
	}

	public void DeleteColection(int collection_id)
	{
		IEnumerable<Pacote> pacotes = _connection.Table<Pacote>().Where(x => x.collection_id == collection_id);
		foreach(Pacote p in pacotes){
			_connection.Delete(p);
		}

		Colection collection = _connection.Table<Colection>().Where(x => x.Id == collection_id).FirstOrDefault();
		_connection.Delete(collection);
	}*/
}