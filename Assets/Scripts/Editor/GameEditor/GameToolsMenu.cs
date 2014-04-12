
using UnityEditor;
using UnityEngine;


public class GameToolsMenu
{



	[ MenuItem( "SA Tools( 1.0 ) /Movie Editor" ) ]
	static void OpenMovieEditor()
	{

		GameMovieEditor window = ( GameMovieEditor )EditorWindow.GetWindow (typeof ( GameMovieEditor ), false ," Movie Editor ");
		window.Show();
	}

	[ MenuItem( "SA Tools( 1.0 ) /Action Viewer" ) ]
	static void OpenActionViewer()
	{
	}

	
	[ MenuItem( "SA Tools( 1.0 ) /UI Viewer" ) ]
	static void OpenUIViewer()
	{
		GameUIViewer window = ( GameUIViewer )EditorWindow.GetWindow ( typeof ( GameUIViewer )  , false , " UI Viewer " );
		window.Show();
		window.loadData();
	}

}
