using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("RestaurantList")]
public class RestaurantList
{
    [XmlElement("Restaurant")]
    public List<Restaurant> Restaurants { get; set; }
}
