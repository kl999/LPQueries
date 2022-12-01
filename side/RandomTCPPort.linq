<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var rand = new Random();

var reservedPorts = 50001;

(reservedPorts + rand.Next((UInt16.MaxValue - reservedPorts))).Dump();