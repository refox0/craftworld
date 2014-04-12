using System;
using UnityEngine;

public class GameSetting : MonoBehaviour 
{
	public enum GameResType
	{
		RESPHONE3,
		RESPHONE4,
		RESPHONE5,
		RESPAD2,
		RESPAD3,
	};
	
	public enum GameMultiple
	{
		GMX1 = 1,
		GMX2 = 2,
		GMX4 = 4,
	}

	public struct GameResStruct
	{
		public Vector2 sizeInPixel;
		public Vector2 sizeDesign;
		public float scale;
		public float showSacle;
		public float battleShowSacle;
		public int maxXGrid;
		public int maxYGrid;
		public int type;
		public string dir;

		public GameResStruct( Vector2 p , Vector2 d , float s , float ss , float bss , int mx , int my , int t , string dd )
		{
			sizeInPixel = p;
			sizeDesign = d;
			scale = s;
			showSacle = ss;
			battleShowSacle = bss;
			maxXGrid = mx;
			maxYGrid = my;
			type = t;
			dir = dd;
		}
	}

	static bool pResPortrait;


	/// <summary>
	/// not use HD res,
	/// </summary>
	/// 
	/// UI ipad HD must scale 2.0. 
	/// RESPHONE3 not support,
	/// 

#if UNITY_EDITOR
	
	public static GameResStruct pResPhone = new GameResStruct( new Vector2(320,480), new Vector2(320,480), 1.0f, 1.0f, 1.0f, 7,7,(int)GameResType.RESPHONE3 , "pPhone" );
	public static GameResStruct pResPhoneRetina35 = new GameResStruct( new Vector2(640 ,960), new Vector2(320,480), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPHONE4 , "pPhone" );
	public static GameResStruct pResPhoneRetina40 = new GameResStruct( new Vector2(640,1136), new Vector2(320,568), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPHONE5 , "pPhone" );
	public static GameResStruct pResTable = new GameResStruct( new Vector2(768,1024), new Vector2(768,1024), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPAD2 , "pPad" );
	public static GameResStruct pResTableRetina = new GameResStruct( new Vector2(1536,2048), new Vector2(768,1024), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPAD3 , "pPad" );

	public static GameResStruct lResPhone = new GameResStruct( new Vector2(480,320), new Vector2(480,320), 1.0f, 1.0f, 1.0f, 7,7,(int)GameResType.RESPHONE3 , "lPhone" );
	public static GameResStruct lResPhoneRetina35 = new GameResStruct( new Vector2(960,640), new Vector2(480,320), 1.0f, 1.0f, 1.0f, 17,17,(int)GameResType.RESPHONE4 , "lPhone" );
	public static GameResStruct lResPhoneRetina40 = new GameResStruct( new Vector2(1136,640), new Vector2(568,320), 1.0f, 1.0f, 1.0f, 17,17,(int)GameResType.RESPHONE5 , "lPhone" );
	public static GameResStruct lResTable = new GameResStruct( new Vector2(1024,768), new Vector2(1024,768), 1.0f, 1.0f, 1.0f, 17,17,(int)GameResType.RESPAD2 , "lPad" );
	public static GameResStruct lResTableRetina = new GameResStruct( new Vector2(2048,1536), new Vector2(1024,768), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPAD3 , "lPad" );

#elif UNITY_IPHONE  

	public static GameResStruct pResPhone = new GameResStruct( new Vector2(320,480), new Vector2(320,480), 1.0f, 1.0f, 1.0f, 7,7,(int)GameResType.RESPHONE3 , "pPhone" );
	public static GameResStruct pResPhoneRetina35 = new GameResStruct( new Vector2(640 ,960), new Vector2(320,480), 2.0f, 2.0f, 1.0f, 9,9, (int)GameResType.RESPHONE4 , "pPhone" );
	public static GameResStruct pResPhoneRetina40 = new GameResStruct( new Vector2(640,1136), new Vector2(320,568), 2.0f, 2.0f, 1.0f, 9,9, (int)GameResType.RESPHONE5 , "pPhone" );
	public static GameResStruct pResTable = new GameResStruct( new Vector2(768,1024), new Vector2(768,1024), 1.0f, 1.4f, 1.0f, 13,13, (int)GameResType.RESPAD2 , "pPad" );
	public static GameResStruct pResTableRetina = new GameResStruct( new Vector2(1536,2048), new Vector2(768,1024), 2.0f, 2.8f, 1.0f, 13,13, (int)GameResType.RESPAD3 , "pPad" );
	
	public static GameResStruct lResPhone = new GameResStruct( new Vector2(480,320), new Vector2(480,320), 1.0f, 1.0f, 1.0f, 7,7,(int)GameResType.RESPHONE3 , "lPhone" );
	public static GameResStruct lResPhoneRetina35 = new GameResStruct( new Vector2(960,640), new Vector2(480,320), 2.0f, 2.0f, 1.0f, 9,9,(int)GameResType.RESPHONE4 , "lPhone" );
	public static GameResStruct lResPhoneRetina40 = new GameResStruct( new Vector2(1136,640), new Vector2(568,320), 2.0f, 2.0f, 1.0f, 9,9,(int)GameResType.RESPHONE5 , "lPhone" );
	public static GameResStruct lResTable = new GameResStruct( new Vector2(1024,768), new Vector2(1024,768), 1.0f, 1.4f, 1.0f, 13,13,(int)GameResType.RESPAD2 , "lPad" );
	public static GameResStruct lResTableRetina = new GameResStruct( new Vector2(2048,1536), new Vector2(1024,768), 2.0f, 2.8f, 1.0f, 13,13, (int)GameResType.RESPAD3 , "lPad" );

#else

	public static GameResStruct pResPhone = new GameResStruct( new Vector2(320,480), new Vector2(320,480), 1.0f, 1.0f, 1.0f, 7,7,(int)GameResType.RESPHONE3 , "pPhone" );
	public static GameResStruct pResPhoneRetina35 = new GameResStruct( new Vector2(640 ,960), new Vector2(320,480), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPHONE4 , "pPhone" );
	public static GameResStruct pResPhoneRetina40 = new GameResStruct( new Vector2(640,1136), new Vector2(320,568), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPHONE5 , "pPhone" );
	public static GameResStruct pResTable = new GameResStruct( new Vector2(768,1024), new Vector2(768,1024), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPAD2 , "pPad" );
	public static GameResStruct pResTableRetina = new GameResStruct( new Vector2(1536,2048), new Vector2(768,1024), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPAD3 , "pPad" );

	public static GameResStruct lResPhone = new GameResStruct( new Vector2(480,320), new Vector2(480,320), 1.0f, 1.0f, 1.0f, 7,7,(int)GameResType.RESPHONE3 , "lPhone" );
	public static GameResStruct lResPhoneRetina35 = new GameResStruct( new Vector2(960,640), new Vector2(480,320), 1.0f, 1.0f, 1.0f, 17,17,(int)GameResType.RESPHONE4 , "lPhone" );
	public static GameResStruct lResPhoneRetina40 = new GameResStruct( new Vector2(1136,640), new Vector2(568,320), 1.0f, 1.0f, 1.0f, 17,17,(int)GameResType.RESPHONE5 , "lPhone" );
	public static GameResStruct lResTable = new GameResStruct( new Vector2(1024,768), new Vector2(1024,768), 1.0f, 1.0f, 1.0f, 17,17,(int)GameResType.RESPAD2 , "lPad" );
	public static GameResStruct lResTableRetina = new GameResStruct( new Vector2(2048,1536), new Vector2(1024,768), 1.0f, 1.0f, 1.0f, 17,17, (int)GameResType.RESPAD3 , "lPad" );

#endif

	public static GameResStruct activeRes;

	public void Awake()
	{
		initGameSetting();
	}

	static bool inited = false;

	public static void initGameSetting()
	{
		if ( !inited )
		{
			pResPortrait = Screen.height > Screen.width;

			if ( pResPortrait ) 
			{
				int actualHeight = Screen.height;

				if ( actualHeight > pResPhoneRetina40.sizeInPixel.y )
				{
					activeRes = pResTableRetina;
					Multiple = (int)GameMultiple.GMX4;
				}
				else if ( actualHeight > pResTable.sizeInPixel.y )
				{
					activeRes = pResPhoneRetina40;
					Multiple = (int)GameMultiple.GMX2;
				}
				else if ( actualHeight > pResPhoneRetina35.sizeInPixel.y )
				{
					activeRes = pResTable;
					Multiple = (int)GameMultiple.GMX2;
				}
				else if ( actualHeight > pResPhone.sizeInPixel.y )
				{
					activeRes = pResPhoneRetina35;
					Multiple = (int)GameMultiple.GMX2;
				}
				else
				{
					activeRes = pResPhone;
					Multiple = (int)GameMultiple.GMX2;
				}

//				float f = Screen.height / Screen.width;
//				float f1 = pResPhoneRetina40.sizeDesign.y / pResPhoneRetina40.sizeDesign.x;
//				float f2 = pResPhoneRetina35.sizeDesign.x / pResPhoneRetina35.sizeDesign.y;
//				float f3 = pResTable.sizeDesign.y / pResTable.sizeDesign.x;
//				
//				float f11 = f1 - f > 0 ? f1 - f : f - f1;
//				float f22 = f2 - f > 0 ? f2 - f : f - f2;
//				
//				if ( f22 > f11 )
//				{
//					activeRes = pResPhoneRetina40;
//				}
//				else
//				{
//					activeRes = pResPhoneRetina35;
//				}
			}
			else
			{
				int actualWidth = Screen.width;

				if ( actualWidth > lResPhoneRetina40.sizeInPixel.x )
				{
					activeRes = lResTableRetina;
					Multiple = (int)GameMultiple.GMX4;
				}
				else if ( actualWidth > lResTable.sizeInPixel.x )
				{
					activeRes = lResPhoneRetina40;
					Multiple = (int)GameMultiple.GMX2;
				}
				else if ( actualWidth > lResPhoneRetina35.sizeInPixel.x )
				{
					activeRes = lResTable;
					Multiple = (int)GameMultiple.GMX2;
				}
				else if ( actualWidth > lResPhone.sizeInPixel.x )
				{
					activeRes = lResPhoneRetina35;
					Multiple = (int)GameMultiple.GMX2;
				}
				else
				{
					activeRes = lResPhone;
					Multiple = (int)GameMultiple.GMX2;
				}
			}



#if UNITY_EDITOR
			StreamingAssetsPath = Application.dataPath + "/StreamingAssets/";
			activeRes = lResPhoneRetina35;
#elif UNITY_IPHONE
			StreamingAssetsPath = Application.dataPath + "/Raw/";
#elif UNITY_ANDROID
			StreamingAssetsPath = "jar:file://" + Application.dataPath + "!/assets/";
#else
			StreamingAssetsPath = Application.dataPath + "/StreamingAssets/";
			activeRes = lResTable;
#endif


			UIPath = "Prefabs/" + activeRes.dir + "/UI/";

			Debug.Log( "Screen: " + Screen.width + " " + Screen.height );
			Debug.Log( "UIPath: " + UIPath );
			Debug.Log( "StreamingAssetsPath: " + StreamingAssetsPath );

			inited = true;
		}
	}

	public static bool		UseAsync = true;

	public static string	MiniMapPath = "MiniMap/";
	public static string	TexturesPath = "Textures/";
	public static string	UIAtlasPath = "UIAtlas/";
	public static int		Multiple;
	public static string	UIPath;
	public static string	StreamingAssetsPath;

	public static float		GameSpeed = 1.0f;
	public static float		GameScale = 1.0f;


}

