<Query Kind="Program">
  <Connection>
    <ID>b2aac786-6e24-43fc-aff9-4fa7b0f86818</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAAB0aBac5XR15KW7AtZYYwGgAAAAAASAAACgAAAAEAAAAKutYqlP5CwXtVP0zaEla6JIAAAA0J+yYZ1aGj/rwGX2/HtUh4GOUFcLsH565L6NJ/0EDhoCVoGdUSAyLAgDZEutxqdAnj6Tq77ffFmOsdgtWxA7tlIk8XJ/6LOxFAAAABs0ugKbcjM3dDHhA1L9qCERMUUb</CustomCxString>
    <Server>192.168.0.200</Server>
    <Database>pir</Database>
    <UserName>pirro</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAAAAZo7tSVA6XHKSsWEOow6FAAAAAASAAACgAAAAEAAAAIj/YEY+5XhgXBjLXIFL8uQIAAAAzbd7I1B/A2AUAAAAShnQq8Gg1v9jqiQFtenEAHalhKM=</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DisplayName>To PIR (read only)</DisplayName>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
      <ExtraCxOptions>CharSet=utf8;</ExtraCxOptions>
    </DriverData>
  </Connection>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	dec decoder = new dec();
	
	BinaryReader read = new BinaryReader(new FileStream("c:\\code.cg", System.IO.FileMode.Open));
	
	byte[] buf =  read.ReadBytes(decoder.hbLen);
	
	read.Close();
	
	decoder.decode(buf)
	.Dump();
}

public class dec
{
	int[] hbInt;
	
	public int hbLen = 0;

	public dec()
	{
		string handbook = "609|582|309|687|457|40|379|961|80|682|178|944|62|257|840|468|870|733|906|703|771|548|272|478|731|162|118|846|448|373|378|966|507|14|761|521|313|238|439|281|433|706|171|483|341|951|480|552|752|765|361|672|247|760|223|391|96|246|522|235|12|644|177|404|186|887|920|34|747|648|857|968|294|360|748|592|639|500|336|208|741|697|763|25|814|518|479|551|401|572|519|751|231|458|230|718|834|79|152|643|745|219|199|423|289|145|28|225|20|217|684|753|678|975|466|50|454|812|642|538|989|863|474|243|310|183|95|565|226|809|285|450|789|440|452|557|172|387|897|422|939|207|700|530|242|689|879|824|915|37|708|954|624|421|499|943|882|611|167|901|264|780|558|137|53|258|645|617|618|728|39|416|464|131|112|993|707|871|705|922|635|547|825|797|958|632|821|19|449|481|30|677|545|510|929|526|425|170|947|637|107|749|656|653|200|160|484|892|193|377|590|402|24|443|43|721|937|66|475|63|322|505|396|719|35|508|919|116|916|488|933|365|799|711|345|7|159|493|757|722|755|140|354|777|323|539|516|327|513|5|816|426|340|351|182|506|86|577|935|855|330|976|963|803|660|286|527|114|201|138|661|115|860|924|397|85|620|409|774|815|189|600|908|375|926|158|827|785|346|626|374|395|461|738|999|878|683|808|211|10|744|907|911|524|179|987|338|614|141|339|695|9|146|914|306|76|581|216|573|455|858|349|693|153|701|415|367|988|938|769|967|997|412|353|148|691|369|875|849|494|615|103|376|315|393|736|535|321|17|326|435|196|957|844|267|646|403|859|467|503|995|927|868|176|109|255|124|122|236|850|928|764|279|250|169|296|994|666|856|101|662|638|337|22|772|946|240|698|314|406|283|593|244|293|312|613|560|486|709|206|274|570|554|263|102|382|899|447|974|194|837|26|202|318|985|234|347|128|290|150|111|504|110|45|166|390|21|288|566|358|842|419|256|977|227|874|261|224|55|575|913|801|601|136|690|470|676|165|48|81|78|616|790|117|549|675|8|671|735|791|776|212|356|389|408|896|845|299|569|191|413|405|459|909|92|971|130|431|714|783|350|331|823|222|385|229|775|773|424|921|694|205|31|308|528|371|525|84|786|270|536|571|608|854|133|890|276|98|362|898|979|586|949|588|471|83|61|512|853|923|782|252|670|502|430|628|418|332|343|437|599|15|732|164|787|541|623|465|633|305|64|686|936|477|99|394|489|59|658|836|2|284|237|742|885|275|795|798|335|245|357|679|587|965|13|120|778|978|220|983|38|793|364|839|187|992|865|72|818|602|398|432|11|460|800|221|664|482|444|953|880|998|889|157|88|266|97|851|359|877|121|297|195|129|71|135|49|300|469|540|893|807|696|462|119|681|214|729|473|674|149|533|973|320|197|826|553|6|952|287|490|29|456|788|864|105|239|174|495|173|828|550|564|451|598|304|434|804|717|100|180|970|930|228|317|848|891|151|319|291|68|438|383|720|605|529|67|51|820|984|532|655|233|213|651|766|673|144|562|948|650|147|835|411|584|74|190|832|134|259|420|659|685|657|941|794|251|260|591|254|631|559|903|543|328|155|185|509|277|414|905|492|710|542|964|531|278|241|33|87|324|188|445|713|496|640|161|866|867|959|630|652|56|82|203|725|712|726|841|621|574|355|427|649|400|307|762|945|792|829|669|127|262|192|603|811|142|18|942|881|271|0|756|441|181|819|46|265|563|636|515|156|407|125|578|876|723|249|904|594|962|463|734|442|610|641|555|629|91|27|511|32|298|90|940|589|57|248|139|715|568|754|960|487|688|767|595|436|861|750|668|739|634|724|44|386|333|990|104|301|980|23|619|813|900|303|175|830|833|410|380|843|740|822|520|746|113|366|204|663|268|759|89|94|982|665|956|472|348|699|498|917|184|16|931|546|972|986|75|534|210|702|77|132|852|384|654|604|894|429|796|163|363|42|743|583|126|54|895|282|311|123|810|232|392|622|779|817|737|154|537|730|886|47|576|69|884|612|106|399|567|918|485|1|93|334|606|269|253|36|273|544|329|692|143|902|370|501|716|579|932|969|352|704|198|215|667|758|910|888|372|781|446|168|596|292|3|838|680|806|597|883|585|869|556|770|514|65|831|52|627|580|925|60|280|302|491|523|476|768|873|805|625|607|388|381|108|955|73|847|996|325|950|41|981|368|342|991|4|417|218|316|802|517|70|58|209|453|344|934|428|727|647|872|862|784|912|561|497|295";
		
		hbInt = handbook.Split('|')
		.Select(o => Int32.Parse(o)).ToArray();
		
		hbLen = hbInt.Length;
		
		//hbInt.Dump();
	}
	
	public string decode(byte[] enter)
	{
		//enter.Dump();
	
		byte[] buf = new byte[hbInt.Length];
		
		enter.Length.Dump();
		//hbInt.Length.Dump();
		for(int i = 0; i < hbInt.Length; i++)
		{
			buf[hbInt[i]] = enter[i];
			
			//(i+": "+buf[hbInt[i]]+"->"+hbInt[i]).Dump();
		}
		
		//buf.Dump();
		
		List<byte> ragBuf = new List<byte>();
		
		for(int i = 0; i < hbInt.Length; i++)
		{
			if(i % 2 == 0)
				ragBuf.Add((byte)(buf[i] - 10));
			else
				ragBuf.Add((byte)(buf[i] + 10));
				
			if((char)ragBuf.Last() == '>')
				break;
		}
		
		string tStr = Encoding.UTF8.GetString(ragBuf.ToArray());//new string(buf);
		
		tStr.Dump("1");
	
		return tStr;
	}
}