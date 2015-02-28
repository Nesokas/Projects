using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

public class Colmeia {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	private string name;

	private struct Date {
		public int day;
		public int month;
		public int year;
	}

	private enum Actions {
	
		ACCAO_A,
		ACCAO_B,
		ACCAO_C,
		ACCAO_D
		
	}

	private Actions action;
	private Date date;

	public void SetName(string colmeia_name)
	{
		name = colmeia_name;
	}

	public void SetDate(int day, int month, int year)
	{
		date.day = day;
		date.month = month;
		date.year = year;
	}

	//public void SetAction(
}

