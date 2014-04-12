using UnityEngine;
using System.Collections;



public class GameDataManager : Singleton< GameDataManager >
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
	
	public void clearAll()
	{

	}
	
	
	void Update()
	{

	}

}
