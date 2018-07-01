using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public static class FileManager
{
    public static RestaurantList ReadAllRestaurants()
    {
        string filePath = "DB/Restaurants";
        TextAsset targetFile = Resources.Load<TextAsset>(filePath);
        XmlSerializer ser = new XmlSerializer(typeof(RestaurantList));
        RestaurantList restaurants = new RestaurantList();
        using (StringReader sr = new StringReader(targetFile.text))
        {
            restaurants = (RestaurantList)ser.Deserialize(sr);
        }
        return restaurants;
    }
}
