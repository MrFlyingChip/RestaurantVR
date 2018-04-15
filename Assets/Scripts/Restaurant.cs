using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Restaurant
{
    [XmlElement("Name")]
    public string Name { get; set; }
    [XmlElement("Date")]
    public string Date { get; set; }
    [XmlElement("Width")]
    public int Width { get; set; }
    [XmlElement("Height")]
    public int Height { get; set; }
}
