//using System.Xml.Linq;

//XDocument xdoc = new XDocument();
//// создаем первый элемент
//XElement iphone6 = new XElement("phone");
//// создаем атрибут
//XAttribute iphoneNameAttr = new XAttribute("name", "iPhone 6");
//XElement iphoneCompanyElem = new XElement("company", "Apple");
//XElement iphonePriceElem = new XElement("price", "40000");
//// добавляем атрибут и элементы в первый элемент
//iphone6.Add(iphoneNameAttr);
//iphone6.Add(iphoneCompanyElem);
//iphone6.Add(iphonePriceElem);
 
//// создаем второй элемент
//XElement galaxys5 = new XElement("phone");
//XAttribute galaxysNameAttr = new XAttribute("name", "Samsung Galaxy S5");
//XElement galaxysCompanyElem = new XElement("company", "Samsung");
//XElement galaxysPriceElem = new XElement("price", "33000");
//galaxys5.Add(galaxysNameAttr);
//galaxys5.Add(galaxysCompanyElem);
//galaxys5.Add(galaxysPriceElem);
//// создаем корневой элемент
//XElement phones = new XElement("phones");
//// добавляем в корневой элемент
//phones.Add(iphone6);
//phones.Add(galaxys5);
//// добавляем корневой элемент в документ
//xdoc.Add(phones);
////сохраняем документ
//xdoc.Save("phones.xml");