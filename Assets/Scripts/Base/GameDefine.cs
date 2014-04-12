using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip; 
using ICSharpCode.SharpZipLib.Zip; 
using System.IO;
using System;





public class GameDefine 
{
	public const float	GAME_VERSION = 1.01f;

	public const int	INVALID_ID = -1;


	public static Transform getTransform( Transform check , string name )   
	{   
		for ( int i = 0 ; i < check.childCount ; i++ )
		{
			Transform t = check.GetChild( i );
			if ( t.name == name )
			{
				return t;
			}
			
			if ( t.childCount != 0 )
			{
				Transform t1 = getTransform( t , name );
				
				if ( t1 ) 
				{
					return t1;
				}
			}
		}
		
		return null;   
	}  

	
	public static byte[] Compress( byte[] bytesToCompress ) 
	{ 
		byte[] rebyte = null; 
		MemoryStream ms = new MemoryStream(); 
		
		GZipOutputStream s = new GZipOutputStream( ms ); 
		s.Write( bytesToCompress , 0 , bytesToCompress.Length ); 

		rebyte = ms.ToArray(); 

		s.Close(); 
		ms.Close(); 

		return rebyte;
	}
	
	public static byte[] DeCompress( byte[] bytesToDeCompress ) 
	{ 
		byte[] rebyte = new byte[ bytesToDeCompress.Length * 20 ];

		MemoryStream ms = new MemoryStream( bytesToDeCompress ); 
		MemoryStream outStream = new MemoryStream();


		GZipInputStream s = new GZipInputStream( ms ); 
		int read = s.Read( rebyte , 0 , rebyte.Length ); 
		while ( read > 0 )
		{
			outStream.Write( rebyte, 0 , read );
			read = s.Read( rebyte , 0, rebyte.Length );
		}

		byte[] rebyte1 = outStream.ToArray(); 

		ms.Close();
		s.Close();
		outStream.Close();

		return rebyte1;
	}


	
	public static byte[] structToBytes( object structObj )
	{
		int size = Marshal.SizeOf( structObj );
		IntPtr buffer = Marshal.AllocHGlobal( size );
		
		try
		{
			Marshal.StructureToPtr( structObj , buffer , false );
			byte[] bytes = new byte[ size ];
			Marshal.Copy( buffer , bytes , 0 , size );
			return bytes;
		}
		finally
		{
			Marshal.FreeHGlobal( buffer );
		}
	}


	public static object bytesToStruct( byte[] bytes , int index , Type strcutType )
	{
		int size = Marshal.SizeOf( strcutType );
		IntPtr buffer = Marshal.AllocHGlobal( size );

		try
		{
			Marshal.Copy( bytes , index , buffer , size );
			object obj = Marshal.PtrToStructure( buffer , strcutType );
			return obj;
		}
		finally
		{
			Marshal.FreeHGlobal( buffer );
		}
	}


	public static T[] bytesToStructArray< T >( byte[] bytes , int index , Type strcutType , int sizeT )
	{
		int size = Marshal.SizeOf( strcutType );

		T[] obj = new T[ sizeT ];

		for ( int i = 0; i < sizeT ; i++ ) 
		{
			obj[ i ] = (T)bytesToStruct( bytes , index + i * size , strcutType );
		}

		return obj;
	}

}
