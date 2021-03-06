// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

public class GameEditorDefine
{
	public GameEditorDefine ()
	{

	}

	/// <summary>
	/// Used to get assets of a certain type and file extension from entire project
	/// </summary>
	/// <param name="type">The type to retrieve. eg typeof(GameObject).</param>
	/// <param name="fileExtension">The file extention the type uses eg ".prefab".</param>
	/// <returns>An Object array of assets.</returns>
	public static UnityEngine.Object[] GetAssetsOfType( System.Type type , string fileExtension , string contain = "" )
	{
		List<UnityEngine.Object> tempObjects = new List<UnityEngine.Object>();
		DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
		FileInfo[] goFileInfo = directory.GetFiles("*" + fileExtension, SearchOption.AllDirectories);
		
		int i = 0; int goFileInfoLength = goFileInfo.Length;
		FileInfo tempGoFileInfo; string tempFilePath;
		UnityEngine.Object tempGO;
		for (; i < goFileInfoLength; i++)
		{
			tempGoFileInfo = goFileInfo[i];
			if (tempGoFileInfo == null)
				continue;
			
			tempFilePath = tempGoFileInfo.FullName;
			tempFilePath = tempFilePath.Replace(@"\", "/").Replace(Application.dataPath, "Assets");

			if ( contain.Length != 0 && !tempFilePath.Contains( contain ) )
			{
				continue;
			}

			//Debug.Log(tempFilePath + "\n" + Application.dataPath);
			
			try 
			{
				tempGO = AssetDatabase.LoadAssetAtPath( tempFilePath , typeof( UnityEngine.Object ) ) as UnityEngine.Object;
			} 
			catch ( Exception ex ) 
			{
				Debug.LogWarning( ex );
				continue;
			}
			
			if (tempGO == null)
			{
				//Debug.LogWarning("Skipping Null");
				continue;
			}
			//			else if ( tempGO.GetType() != type)
			//			{
			//				Debug.LogWarning("Skipping " + tempGO.GetType().ToString());
			//				continue;
			//			}
			
			GameObject gobject = ( GameObject )tempGO;
			if ( gobject )
			{
				if ( gobject.GetComponent( type.ToString() ) == null )
				{
					continue;
				}
			}
			
			tempObjects.Add( gobject );
		}
		
		return tempObjects.ToArray();
	}


	public static UnityEngine.Object[] GetAssets( string fileExtension , string contain = "" )
	{
		List<UnityEngine.Object> tempObjects = new List<UnityEngine.Object>();
		DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
		FileInfo[] goFileInfo = directory.GetFiles("*" + fileExtension, SearchOption.AllDirectories);
		
		int i = 0; int goFileInfoLength = goFileInfo.Length;
		FileInfo tempGoFileInfo; string tempFilePath;
		UnityEngine.Object tempGO;
		for (; i < goFileInfoLength; i++)
		{
			tempGoFileInfo = goFileInfo[i];
			if (tempGoFileInfo == null)
				continue;
			
			tempFilePath = tempGoFileInfo.FullName;
			tempFilePath = tempFilePath.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
			
			if ( contain.Length != 0 && !tempFilePath.Contains( contain ) )
			{
				continue;
			}
			
			//Debug.Log(tempFilePath + "\n" + Application.dataPath);
			
			try 
			{
				tempGO = AssetDatabase.LoadAssetAtPath( tempFilePath , typeof( UnityEngine.Object ) ) as UnityEngine.Object;
			} 
			catch ( Exception ex ) 
			{
				Debug.LogWarning( ex );
				continue;
			}
			
			if (tempGO == null)
			{
				//Debug.LogWarning("Skipping Null");
				continue;
			}
						
			tempObjects.Add( tempGO );
		}
		
		return tempObjects.ToArray();
	}

	public static Color EditorColor = new Color(255f/255f,255f/255f,0f/255f);
}


