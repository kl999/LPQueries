<Query Kind="Statements">
  <Connection>
    <ID>a4c45978-5d31-40c9-a263-9421bd6a63cf</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAACCRzOW190H88gaY8Y3f3SYAAAAAASAAACgAAAAEAAAAPVVo4Y07IdGbqHOoeYCbYBIAAAAw0QJOudi/6lhAZY7UJZwdDgj46LQT1jcS68cwnbog51Sfkj7ifzb8FgkOv2bsobLOywucHlRxfnRX3uUNf1W+zUYil1JbCA9FAAAAN40gTblN5bFfewbyWvmABgHNLdq</CustomCxString>
    <Server>192.168.0.35</Server>
    <UserName>frompir</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAADwxvNcWLoqT7wOSQTxCc61AAAAAASAAACgAAAAEAAAANutJ6NqGFPfIRDVtMBgDcwIAAAAlAIB1msaLxsUAAAAwLP/xLTgEgnzNdFexWeGiEtGYxU=</Password>
    <Database>frompir</Database>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DisplayName>.35 From PIR</DisplayName>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
      <ExtraCxOptions>CharSet= utf8;</ExtraCxOptions>
    </DriverData>
  </Connection>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

$response_poly = json_decode(file_get_contents("http://jgo.maps.yandex.net/1.1/tiles?l=trj,trjl,trje&lang=ru_RU&x=".$x."&y=".$y."&z=".$z."&tm=".$tm));


for ($j=0; $j<count($response_poly->data->features);$j++)
{
	for ($k=0; $k<count($response_poly->data->features[$j]->properties->HotspotMetaData->RenderedGeometry->coordinates);$k++)
	{
		for ($i=0; $i<count($response_poly->data->features[$j]->properties->HotspotMetaData->RenderedGeometry->coordinates[$k][0]);$i++)
		{
			$poly_x[$j][$k][$i]=$response_poly->data->features[$j]->properties->HotspotMetaData->RenderedGeometry->coordinates[$k][0][$i][0];
			$poly_y[$j][$k][$i]=$response_poly->data->features[$j]->properties->HotspotMetaData->RenderedGeometry->coordinates[$k][0][$i][1];
		}
	}
	if ($response_poly->data->features[$j]->properties->description>=30)
		$color[$j]='green';
	elseif ($response_poly->data->features[$j]->properties->description>=20)
		$color[$j]='yellow';
	else
		$color[$j]='red';
}