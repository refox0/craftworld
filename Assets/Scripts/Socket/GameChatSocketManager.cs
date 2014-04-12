using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



public class GameChatSocketManager : Singleton< GameChatSocketManager >
{
	#if UNITY_EDITOR
	[ System.Serializable ]
	public class SocketSelection
	{
		public string HostName;
		public string HostIP;
		public int Port;
	}
	public SocketSelection[] editorSocketSelection;
	#endif
	public string HostIP = "";
	public int HostPort = 0;

	public delegate void msgHandler( GameNetMessage.NetMsgHead head );
	
	public struct MsgHandler
	{
		public Type type;
		public msgHandler handler;
	}
	
	private GameClientSocket socket = new GameClientSocket();
	private Dictionary< int , MsgHandler > handlerDic = new Dictionary< int , MsgHandler >();
	
	private bool isConnected = false;
	
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
	
	public void regeditMsg( int t , msgHandler handler , Type type )
	{
		MsgHandler h = new MsgHandler();
		h.type = type;
		h.handler = handler;
		
		handlerDic[ t ] = h;
	}
	
	public bool connect()
	{
		if ( HostIP.Length == 0 || HostPort == 0 )
		{
			return false;
		}
		
		if ( socket.isConnected() )
		{
			return true;
		}
		
		isConnected = socket.connect( HostIP , HostPort );
		return isConnected;
	}
	
	public void sendMsg( GameNetMessage.NetMsgInterface msg )
	{
		socket.sendMsg( msg );
	}
	
	public void close()
	{
		socket.close();
	}
	
	
	void Update()
	{
		socket.update();
		
		if ( isConnected && !socket.isConnected() ) 
		{
			// reconnect,,
			
			isConnected = socket.reconnect();
			
			if ( !isConnected )
			{
				isConnected = true;
			}
			else
			{
				// connected,,
				
			}
			
			return;
		}
		
		for ( int i = 0 ; i < 1 ; i++ )
		{
			if ( socket.iBuffer.getLen() > 4 ) 
			{
				byte[] ibuffer = socket.iBuffer.getBuffer();
				int offset = socket.iBuffer.getOffset();
				int len = socket.iBuffer.getLen();
				
				GameNetMessage.NetMsgHead head = ( GameNetMessage.NetMsgHead )GameDefine.bytesToStruct( ibuffer , offset , typeof( GameNetMessage.NetMsgHead ) ); 
				
				bool b = handlerDic.ContainsKey( head.type );
				
				if ( b )
				{
					if ( len < head.size )
					{
						return;
					}
					
					MsgHandler handler = handlerDic[ head.type ];
					
					GameNetMessage.NetMsgHead msg = ( GameNetMessage.NetMsgHead )GameDefine.bytesToStruct( ibuffer , offset , handler.type ); 

					handler.handler( msg );
					
					Debug.Log( "recv net msg " + msg.type + " class " + handler.type ); 
				}
				else
				{
					Debug.LogError( "msg not regedit " + head.type ); 
					
					return;
				}
				
				socket.iBuffer.removeBuffer( head.size + 2 );
			}
			else
			{
				return;
			}
		}
	}
	
	
}
