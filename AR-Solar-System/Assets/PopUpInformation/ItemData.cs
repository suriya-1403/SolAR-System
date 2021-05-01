
using System.Xml.Serialization;

[XmlRoot("itemdata")]
public class ItemData
{
    [XmlElement("item")]
    public Item[] items;

}
public class Item
{
    [XmlAttribute]
    public string id;
    [XmlAttribute]
    public string name;
    [XmlAttribute]
    public string photo_path;
    [XmlText]
    public string Information;

}
