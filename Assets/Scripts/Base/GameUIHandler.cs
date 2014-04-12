using System;
using UnityEngine;
using System.Collections;


public abstract class GameUIHandler< T > : Singleton< T > , GameUIHandlerInterface
{
	public string uiName;
	public Transform anchor;
	public int renderQ = 0;
	public bool allways = false;
	public bool single = false;

	public abstract void onRelease();
	public abstract void onInit();
	public abstract void onOpen();
	public abstract void onClose();


	[ HideInInspector ] public bool isShow = false;
	[ HideInInspector ] public GameObject uiObject = null;
	[ HideInInspector ] public GameObject cloneObject = null;
	[ HideInInspector ] public bool isLoaded = false;
	
	public bool isSingle()
	{
		return single;
	}
	public  bool isAllways()
	{
		return allways;
	}

	public void Show()
	{
		if ( !isLoaded )
		{
			string s = GameSetting.UIPath;
			s += uiName;
			
			cloneObject = (GameObject)Resources.Load( s );

			if ( !cloneObject ) 
			{
				Debug.LogError( "res not found " + s );
				return;
			}

			uiObject = NGUITools.AddChild( anchor.gameObject , cloneObject );
			UIPanel panel = uiObject.GetComponent< UIPanel >();
			panel.renderQueue = UIPanel.RenderQueue.StartAt;
			panel.startingRenderQueue = renderQ;

			isLoaded = true;

			GameUIManager.instance.setHandler( uiName , this );

			onInit();
		}
		else
		{
			uiObject.SetActive( true );
		}


		isShow = true;
		
		onOpen();

		if ( single )
		{
			GameUIManager.instance.checkSingel( uiName );
		}
		

	}
	
	public void UnShow()
	{
		if ( !uiObject )
		{
			return;
		}

		isShow = false;
		uiObject.SetActive (false);
		
		onClose ();
	}

	public void ReleaseUnused()
	{
		if ( !isShow )
		{
			Release();
		}
	}
	
	public void Release()
	{
		if ( !isLoaded ) 
		{
			return;
		}

		if ( isShow )
		{
			onClose ();
			isShow = false;
		}

		onRelease ();

		NGUITools.Destroy( uiObject );

		cloneObject = null;
		//DestroyImmediate( cloneObject );
		Resources.UnloadUnusedAssets();

		isLoaded = false;
	}
}


