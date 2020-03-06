<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Namespace>System.DirectoryServices</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

DirectoryEntry entry = new DirectoryEntry("LDAP://HQ");
DirectorySearcher adSearcher = new DirectorySearcher(entry);

adSearcher.SearchScope = SearchScope.Subtree;
adSearcher.Filter = "(&(objectClass=user)(samaccountname=samartsev_26224))";
SearchResult userObject = adSearcher.FindOne();

userObject.Properties.Dump();

userObject.Properties["displayname"].Dump();
userObject.Properties["mail"].Dump();
userObject.Properties["telephonenumber"].Dump();