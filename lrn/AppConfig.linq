<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Configuration</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="MyKey" value="Hello world!" />
        </appSettings>
        <connectionStrings>
          <add name="MyDBCon" connectionString="Data Source=(LocalDB)\MyDB;Initial Catalog=Test;Integrated Security=True;Pooling=False" />
        </connectionStrings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

ConfigurationManager.AppSettings["MyKey"].Dump("Custom key");

var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

var settings = configFile.AppSettings.Settings;
if (settings["ChgKey"] == null)
{
    settings.Add("ChgKey", "1");
}
else
{
    settings["ChgKey"].Value = (Int32.Parse(settings["ChgKey"].Value) + 1).ToString();
}

configFile.Save(ConfigurationSaveMode.Modified);
ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

ConfigurationManager.ConnectionStrings["MyDBCon"].Dump("Connection string");

settings.Dump();

/*
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>()
    {
        ["SomeKey"] = "SomeValue"
    })
    .Build();

configuration.Dump();*/
