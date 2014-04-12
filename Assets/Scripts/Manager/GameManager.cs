using UnityEngine;
using System.Collections;


public class GameManager : Singleton< GameManager >
{

	void Start ()
	{
		if ( mInstance == null )
		{
			mInstance = this;
			DontDestroyOnLoad( gameObject );

			initGame();
		}
		else
		{
			Destroy( gameObject );
		}
		
	}


	public void initGame()
	{

	}


	public void releaseUnused()
	{
		GameUIManager.instance.releaseUnusedHandler();

		Resources.UnloadUnusedAssets();
	}
	
	
	#if UNITY_EDITOR
	
	public bool editorReleaseUnused = false;

	void Update()
	{

		if ( editorReleaseUnused )
		{
			releaseUnused();
			
			editorReleaseUnused = false;
		}
	}
	
	#endif
}
