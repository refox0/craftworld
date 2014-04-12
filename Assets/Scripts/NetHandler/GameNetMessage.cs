using System;
using System.Runtime;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;




public struct GameNetMessage
{

	
	public enum MsgType
	{

		
		
		
	};

	
	
	public interface NetMsgInterface
	{
		
	}

	
	[ StructLayout( LayoutKind.Sequential , Pack = 1 ) ]
	public struct NetMsgHead : NetMsgInterface
	{
		public short size;
		public short type;
		
		public NetMsgHead( short s = 0 , short t = 0 )
		{
			size = s;
			type = t;
		}
		
	};  

	

}