<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

bool IncludeInvoicesNode = true;

public virtual string ParametersNodeName
{
  get { return "parameters"; }
}

/*--------------------*/void Main()//-----------------------------------------------------------------------------------
{
	//ToXmlCommon(null).InnerXml.Dump();
	XElement.Parse(ToXmlCommon(null).OuterXml).Dump();
}

protected virtual XmlDocument ToXmlCommon(string invoiceId)
{
  XmlDocument document = new XmlDocument();
  document.LoadXml(String.Format("<document><payer id='' name='' address='' type=''/>{0}</document>",
      IncludeInvoicesNode ? "<invoices/>" : ""));

  XmlNode nodePayer = document.SelectSingleNode("/document/payer");
  nodePayer.Attributes["id"].InnerText = "payer.Id";
  nodePayer.Attributes["name"].InnerText = "payer.Name";
  nodePayer.Attributes["address"].InnerText = "payer.Address";

  if (true)//calcParams != null && calcParams.Count != 0)
  {
      XmlNode nodeAddInfo = document.SelectSingleNode("/document").InsertAfter(document.CreateElement("addInfo"), nodePayer);
      XmlNode nodeParams = nodeAddInfo.AppendChild(document.CreateElement("calcParams"));

      for(int i = 0; i < 5; i++)//each (CalculationParameter calcParam in calcParams)
      {
          XmlNode nodeParam = nodeParams.AppendChild(document.CreateElement("calcParam"));
          nodeParam.Attributes.Append(document.CreateAttribute("id")).InnerText = "calcParam.Id" + i;
          nodeParam.Attributes.Append(document.CreateAttribute("name")).InnerText = "calcParam.Name" + i;
          nodeParam.Attributes.Append(document.CreateAttribute("alias")).InnerText = "calcParam.Alias" + i;
          nodeParam.Attributes.Append(document.CreateAttribute("value")).InnerText = "calcParam.Value" + i;
      }
  }

  XmlNode nodeInvoices;
  if (IncludeInvoicesNode)
  {
      nodeInvoices = document.SelectSingleNode("/document/invoices");
  }
  else
  {
      nodeInvoices = document.SelectSingleNode("/document");
  }
  for(int i = 0; i < 3; i++)//each (Invoice invoice in invoices)
  {
      //if (invoiceId != null && invoice.Id != invoiceId) break;

      nodeInvoices.AppendChild(ToXml(document, IncludeInvoicesNode, ParametersNodeName, i));
  }

  return document;
}

internal XmlNode ToXml(XmlDocument docParent, bool includeInvoicesNode, string parametersNodeName, int i)
{
  XmlNode nodeInvoice;
  if (includeInvoicesNode)
  {
      nodeInvoice = docParent.CreateElement("invoice");

      nodeInvoice.Attributes.Append(docParent.CreateAttribute("id")).InnerText = i.ToString();
      nodeInvoice.Attributes.Append(docParent.CreateAttribute("amount")).InnerText = "Amount.Value100";
      nodeInvoice.Attributes.Append(docParent.CreateAttribute("currency")).InnerText = "currency";
      nodeInvoice.Attributes.Append(docParent.CreateAttribute("periodDate")).InnerText =
          "periodDate.ToString(\"yyyy-MM-dd HH:mm:ss\")";
      nodeInvoice.Attributes.Append(docParent.CreateAttribute("formedDate")).InnerText =
          "formedDate.ToString(\"yyyy-MM-dd HH:mm:ss\")";
      nodeInvoice.Attributes.Append(docParent.CreateAttribute("expireDate")).InnerText =
          "expireDate.ToString(\"yyyy-MM-dd HH:mm:ss\")";
      nodeInvoice.Attributes.Append(docParent.CreateAttribute("status")).InnerText =
          "status";
      nodeInvoice.Attributes.Append(docParent.CreateAttribute("regId")).InnerText =
          "SystemInfo.Id";
  }
  else
  {
      nodeInvoice = docParent.SelectSingleNode("/document");
  }
  XmlNode nodeParameters = nodeInvoice.AppendChild(docParent.CreateElement(parametersNodeName));

  long totalSum = 0;
  for(int i2 = 0; i2 < 3; i2++)//each (IInvoiceParameter parameter in parameters)
  {
  		XmlDocument xmlAddInfo = new XmlDocument(); ;

        xmlAddInfo.LoadXml("<root>parameter.ToXml(docParent)</root>");
		
      totalSum += i2;//(parameter.PaySum.Value100 > 0 ? parameter.PaySum.Value100 : parameter.FixSum.Value100);
      //nodeParameters.AppendChild(xmlAddInfo.FirstChild);
  }

  if (includeInvoicesNode)
  {
      return nodeInvoice;
  }
  else
  {
      return nodeParameters;
  }
}