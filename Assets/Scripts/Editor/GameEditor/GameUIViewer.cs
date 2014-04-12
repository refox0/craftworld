
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System;

public class GameUIViewer : EditorWindow
{
	GameUIComponent uiFind = null;

	UnityEngine.Object[] uiPopupArray = null;
	string[] uiPopupStringArray = null;
	string[] uiPopupSelectStringArray = { "All" , "pP" , "lP" , GameSetting.pResPhone.dir , GameSetting.pResPhoneRetina35.dir , 
		GameSetting.pResPhoneRetina40.dir , GameSetting.pResTable.dir , 
		GameSetting.pResTableRetina.dir ,  GameSetting.lResPhone.dir , GameSetting.lResPhoneRetina35.dir , 
		GameSetting.lResPhoneRetina40.dir , GameSetting.lResTable.dir , 
		GameSetting.lResTableRetina.dir};

	int uiPopupSelectSelect = 0;
	int uiPopupSelect = 0;

	Transform uiTransform = null;

	GameObject targetObject = null;


	
	void OnGUI()
	{
		GUI.color = Color.green;
		EditorGUILayout.LabelField( "UI Finder:" , EditorStyles.boldLabel );
		GUI.color = Color.white;
		
		EditorGUILayout.BeginHorizontal();

		uiPopupSelectSelect = EditorGUILayout.Popup( uiPopupSelectSelect , uiPopupSelectStringArray );

		if ( GUILayout.Button( "Reload" ) )
		{
			loadData();
			
			if ( uiPopupArray == null || uiPopupArray.Length == 0 )
			{
				ShowNotification( new GUIContent("No UI selected for searching") );
				return;
			}
		}

		EditorGUILayout.EndHorizontal();

		if ( uiPopupArray == null || uiPopupArray.Length == 0 )
		{
			return;
		}

		EditorGUILayout.LabelField( "UI Length:" + uiPopupArray.Length );

		showUIFinder();
		
		GUI.color = Color.green;
		EditorGUILayout.LabelField( "UI Viewer:" , EditorStyles.boldLabel );
		GUI.color = Color.white;
		
//		if ( !GameActionViewerTestUIHandler.instance ) 
//		{
//			GUI.color = Color.red;
//			GUILayout.Label( "Please Start TestViewer Scene." , EditorStyles.boldLabel );
//			GUI.color = Color.white;
//			
//			targetObject = null;
//
//			return;
//		}
		
		if ( uiPopupArray != null && uiPopupArray.Length != 0 )
		{
			showUI();
		}
		
		
	}
	
	
	void showUIFinder()
	{
		EditorGUILayout.BeginHorizontal();
		
		uiPopupSelect = EditorGUILayout.Popup( uiPopupSelect , uiPopupStringArray );
		
		GameObject obj = ( GameObject )uiPopupArray[ uiPopupSelect ];
		
		uiFind = obj.GetComponent< GameUIComponent >();
		uiFind = EditorGUILayout.ObjectField( "UI" , uiFind , typeof( GameUIComponent ) , false ) as GameUIComponent;
		
		EditorGUILayout.EndHorizontal();
	}
	
	void showUI()
	{
		EditorGUILayout.BeginHorizontal();
		
		if ( GUILayout.Button("Show!" ) )
		{
			if ( targetObject != null )
			{
				Destroy( targetObject );
				targetObject = null;
			}

			//uiTransform = GameDefine.getTransform( GameActionViewerTestUIHandler.instance.gameObject.transform.parent , "Anchor - Center" );

			GameObject obj = ( GameObject )uiPopupArray[ uiPopupSelect ];
			targetObject = (GameObject)Instantiate( obj );
			targetObject.transform.parent = uiTransform;
			targetObject.transform.localScale = new Vector3( 1.0f , 1.0f , 1.0f );
			targetObject.transform.localPosition = new Vector3( 1.0f , 1.0f , 1.0f );
		}
		
		if ( GUILayout.Button("Clear" ) )
		{
			if ( targetObject != null )
			{
				Destroy( targetObject );
				targetObject = null;
			}
		}
		
		EditorGUILayout.EndHorizontal();
		
//		if ( actionEditor != null )
//		{
//			actionEditor.OnInspectorGUI();
//			
//			action.Update();
//		}
	}
	
	
	public void loadData()
	{
		if ( uiPopupArray != null )
		{
			uiPopupArray = null;
		}

		string select = uiPopupSelectStringArray[ uiPopupSelectSelect ];
		if ( uiPopupSelectSelect == 0 ) 
		{
			select = "";
		}

		uiPopupArray = (UnityEngine.Object[])GameEditorDefine.GetAssetsOfType( typeof( GameUIComponent ) , ".prefab" , select );
		
		if ( uiPopupArray == null )
		{
			return;
		}
		
		uiPopupStringArray = new string[ uiPopupArray.Length ];
		
		for ( int i = 0 ; i < uiPopupArray.Length ; i++ )
		{
			//GameObject obj = ( GameObject )uiPopupArray[ i ];
			//GameActionController action1 = obj.GetComponent< GameActionController >();
			//action1.Start();
			
			uiPopupStringArray[ i ] = uiPopupArray[ i ].name;
		}


	}
	
	
	
	
}
