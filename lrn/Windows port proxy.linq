<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/*
http://winitpro.ru/index.php/2014/12/23/nastrojka-port-forvardinga-v-windows/

netsh interface portproxy add v4tov4 listenport=3340 listenaddress=10.10.1.110 connectport=3389 connectaddress=10.10.1.110

netsh interface portproxy show all

netsh interface portproxy delete v4tov4 listenport=3340 listenaddress=10.10.1.110
*/