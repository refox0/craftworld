using UnityEngine;
using UnityEditor;
using System;

[ CustomEditor( typeof( GameSocketManager ) ) ]
public class GameSocketInspector : Editor
{
	private SerializedProperty  
		HostIP,  
		HostPort,
		Selection;  

	public GameSocketInspector ()
	{

	}

	private bool[] select = new bool[1];

	void OnEnable () 
	{
		HostIP = serializedObject.FindProperty ( "HostIP" );
		HostPort = serializedObject.FindProperty ( "HostPort" );
		Selection = serializedObject.FindProperty( "editorSocketSelection" );
	}

	public override void OnInspectorGUI ()
	{
		EditorGUILayout.PropertyField( HostIP ); 
		EditorGUILayout.PropertyField( HostPort ); 

		if ( Selection.arraySize != 0 )
		{
			GUI.color = GameEditorDefine.EditorColor;
			GUILayout.Label( "Please Select Hosts:" );  
			GUILayout.BeginVertical();
			
			if ( select.Length != Selection.arraySize ) 
			{
				select = new bool[ Selection.arraySize ];
			}
			
			for ( int i = 0 ; i < Selection.arraySize ; i++ )
			{
				SerializedProperty pro = Selection.GetArrayElementAtIndex( i );  

				//EditorGUILayout.BeginToggleGroup();
				select[ i ] = GUILayout.Toggle( select[ i ] , pro.FindPropertyRelative( "HostName" ).stringValue );
				
				if ( select[ i ] )
				{
					clearSelectHost( i );
					
					HostIP.stringValue = pro.FindPropertyRelative( "HostIP" ).stringValue;
					HostPort.intValue = pro.FindPropertyRelative( "Port" ).intValue;
				}
			}

			GUILayout.Label( "-----------------");  

			GUILayout.EndVertical(); 
		}
		



		EditorGUILayout.PropertyField( Selection , true );

		GUI.color = Color.white;


		serializedObject.ApplyModifiedProperties();
	}


	private void clearSelectHost( int index )
	{
		for ( int i = 0; i < select.Length ; i++ )
		{
			if ( index != i )
			{
				select[ i ] = false;
			}
		}
	}

	void OnGUI()  
	{  
		


	}
}

