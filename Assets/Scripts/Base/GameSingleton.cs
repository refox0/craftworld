using UnityEngine;
using System.Collections;


public class Singleton< T > : MonoBehaviour 
{
	static public T mInstance = default(T);
	static public T instance
	{
		get
		{
			if ( mInstance == null )
			{
				Debug.LogWarning( "mInstance is null" );
			}

			return mInstance;
		}
	}


}

