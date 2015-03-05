using UnityEngine;
using System.Collections;
using SQLite4Unity3d;
using System;

public class Evento {
	
	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public int colmeia_id { get; set; }

/*	public int day { get; set; }
	public int month { get; set; }
	public int year { get; set; }
*/
	public DateTime date { get; set; }

	public enum TipoEvento {
		
		ACCAO_A,
		ACCAO_B,
		ACCAO_C,
		ACCAO_D
		
	}

	public TipoEvento tipo_evento;

	public Evento(){}

	public Evento(TipoEvento evento, int colmeia_id)
	{
	/*	this.day = day;
		this.month = month;
		this.year = year;
*/
		tipo_evento = evento;
		this.colmeia_id = colmeia_id;
		date = DateTime.Now;
	}
}
