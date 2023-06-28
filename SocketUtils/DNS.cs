/*
 * Author: [Project HSI]
 * Description: Adds DNS helper functions.
*/

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SocketUtils
{
	public static class DNS
	{
		public static bool HostValid(string host)
		{
			try
			{
				Dns.GetHostEntry(host).AddressList[0].ToString();
				return true;
			}
			catch (IndexOutOfRangeException)
			{
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static string ResolveHost(string host)
		{
			try
			{
				return Dns.GetHostEntry(host).AddressList[0].ToString();
			}
			catch (IndexOutOfRangeException)
			{
				// probably already an IP address.
				return host;
			}
			catch (Exception)
			{
				throw new ArgumentException($"{host} is not a valid IP address.");
			}
		}
	}
}
