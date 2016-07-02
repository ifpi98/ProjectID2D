using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class CSVParser
{
	public CSVParser()
	{
	}
	~CSVParser()
	{
		_reader		= null;
		_Header		= null;
	}

	protected FileInfo _sourceFile	= null;
	protected TextReader _reader	= null;
	protected string[] _Header		= null;


	// Must Override!
	public virtual void Load() {}
	public virtual void Parse( string[] inputData ) { }
	
	// Getter / Setter

	// Default Functions
	public void LoadFile( string filePath )
	{
		string fileFullPath = Application.dataPath + "/Resources/" + filePath;
		Debug.Log( fileFullPath );
		_sourceFile = new FileInfo( fileFullPath );
		if( _sourceFile != null && _sourceFile.Exists )
		{
			_reader = _sourceFile.OpenText();
		}

		if( _reader == null )
		{
			Debug.LogError( "File not found or not readable : " + fileFullPath );
		}

		if( _reader == null )
		{
			Debug.LogError( "LoadFile Fail : " + filePath );
			return;
		}

		int lineCount = 0;
		string inputData = _reader.ReadLine();
		while( inputData != null )
		{
			Debug.Log( "Parsing : " + inputData );

			string[] stringList = inputData.Split( ',' );
			if( stringList.Length == 0 )
			{
				continue;
			}

			//string keyValue = stringList[0];
			if( ParseData( stringList, lineCount ) == false )
			{
				Debug.LogError( "Parsing fail : " + stringList.ToString() );
			}

			inputData = _reader.ReadLine();
			lineCount++;
		}

		_sourceFile = null;

		_reader.Dispose();
		_reader		= null;
	}

	public bool ParseData( string[] inputData, int lineCount )
	{
		if( lineCount == 0 )
		{
			// Header
			_Header = inputData;

			return true;
		}

		if( VarifyKey( inputData[0] ) == false )
		{
			Debug.Log( "VarifyKey fail : " + inputData[0] );
			return false;
		}

		Parse( inputData );

		return true;
	}

	public virtual bool VarifyKey( string keyValue )
	{


		return true;
	}



}