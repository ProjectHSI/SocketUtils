using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SocketUtils
{
	public static class Socket
	{
		// we need to force the namespace here, otherwise this will read as SocketUtils->Socket->ConnectionOpen(SocketUtils->Socket)
		// which is not valid, primarily due to the function getting it's parent (which is not acceptable here)
		// or as the IDE puts it: putting a static class as a type (also not acceptable).
		public static bool IsConnectionOpen(System.Net.Sockets.Socket socket)
		{
			try
			{
				/*
				 * to fix ambiguity, we put the !socket.Poll... negative operation inside of brackets.
				 * to prevent interpretations such as:
				 * NOT(X AND Y)
				 * and to force the interpretation as
				 * (NOT(X)) AND Y 
				*/
				return ((!socket.Poll(100, SelectMode.SelectRead)) && (socket.Available == 0)) || !socket.Connected;
			}
			catch
			{
				return false;
			}
		}
	}
}
