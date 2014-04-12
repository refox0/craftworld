using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameConfigManager : Singleton< GameConfigManager >
{

	void Awake ()
	{
		if ( mInstance == null )
		{
			mInstance = this;
			DontDestroyOnLoad( gameObject );

		}
		else
		{
			Destroy( gameObject );
		}

	}

	public void loadAll()
	{

	}



#if UNITY_EDITOR
	
	public bool editorReload = false;

	void Update()
	{
		if ( editorReload )
		{
			loadAll();

			editorReload = false;
		}
	}
#endif
}

