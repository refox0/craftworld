using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameUIManager : GameHandlerManager< GameUIManager >
{
	void Awake ()
	{
		if ( mInstance == null )
		{
			mInstance = this;
		}

	}


	
	public GameObject createUI( string name )
	{
		string s = GameSetting.UIPath;
		s += name;
		
		GameObject cloneObject = (GameObject)Resources.Load (s);

		return (GameObject)Instantiate( cloneObject );
	}


	public GameObject getCloneUI( string name )
	{
		string s = GameSetting.UIPath;
		s += name;
		
		GameObject cloneObject = (GameObject)Resources.Load (s);

		return cloneObject;
	}


	public void checkSingel( string name )
	{
		foreach ( KeyValuePair< string, GameHandler > a in uiDic )
		{ 
			GameUIHandlerInterface uihander = (GameUIHandlerInterface)a.Value;

			if ( a.Key != name && !uihander.isAllways() )
			{
				uihander.UnShow();
			}
		}
	}
	
	#if UNITY_EDITOR
	
	public bool editorClearUnusedUI = false;
	
	void Update()
	{
		if ( editorClearUnusedUI )
		{
			releaseUnusedHandler();
			
			editorClearUnusedUI = false;
		}
	}

	
	#endif

}
