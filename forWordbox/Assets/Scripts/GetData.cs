using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

public class GetData : MonoBehaviour
{



    [SerializeField] string API_URL = "";  //Default: https://randomuser.me/api/?results=50&callback=randomuserdata.

    [SerializeField] RandomUserData RandomUsers;

    public Transform place;
    [SerializeField] InfoUser ModelUser;


    private void Start()
    {
        StartCoroutine("GetfromApi");
    }
    public void sendUsers() {

        foreach (Result res in RandomUsers.results) {


            ModelUser.username.text = res.name.title + " " + res.name.last + " " + res.name.first;
            ModelUser.urlPicBig = res.picture.large;
            ModelUser.urlpicThumb = res.picture.thumbnail;
            ModelUser.Name = res.name.title+" "+ res.name.last+" "+ res.name.first;
            ModelUser.City = res.location.city;
            ModelUser.Mail = res.email;
            ModelUser.Gender = res.gender;
            ModelUser.Age = res.registered.age.ToString();

           var obj= Instantiate(ModelUser, place.position, Quaternion.identity);

            obj.transform.SetParent(place);
            obj.transform.localScale = new Vector3(1, 1, 1);
        
        }
    }
    IEnumerator GetfromApi()
    {

        UnityWebRequest request = UnityWebRequest.Get(API_URL);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error while fetching data from API: " + request.error);
            yield break;
        }

       string json = request.downloadHandler.text;
      string cleanjson= json.Replace("randomuserdata(", " ").Replace(");", " ");
        Debug.Log(cleanjson);
       RandomUsers = JsonUtility.FromJson<RandomUserData>(cleanjson);

        sendUsers();

    }


    [ContextMenu("Download")]
    public void dowloadinfo()
    {

        StartCoroutine("GetfromApi");

    }
    }

[System.Serializable]
public class RandomUserData
{
    public Result[] results;
    public Info info;
}

[System.Serializable]
public class Result
{
    public string gender;
    public Name name;
    public Location location;
    public string email;
    public Login login;
    public Dob dob;
    public Registered registered;
    public string phone;
    public string cell;
    public Id id;
    public Picture picture;
    public string nat;
}

[System.Serializable]
public class Name
{
    public string title;
    public string first;
    public string last;
}

[System.Serializable]
public class Location
{
    public Street street;
    public string city;
    public string state;
    public string country;
    public int postcode;
    public Coordinates coordinates;
    public Timezone timezone;
}

[System.Serializable]
public class Street
{
    public int number;
    public string name;
}

[System.Serializable]
public class Coordinates
{
    public string latitude;
    public string longitude;
}

[System.Serializable]
public class Timezone
{
    public string offset;
    public string description;
}

[System.Serializable]
public class Login
{
    public string uuid;
    public string username;
    public string password;
    public string salt;
    public string md5;
    public string sha1;
    public string sha256;
}

[System.Serializable]
public class Dob
{
    public string date;
    public int age;
}

[System.Serializable]
public class Registered
{
    public string date;
    public int age;
}

[System.Serializable]
public class Id
{
    public string name;
    public object value;
}

[System.Serializable]
public class Picture
{
    public string large;
    public string medium;
    public string thumbnail;
}

[System.Serializable]
public class Info
{
    public string seed;
    public int results;
    public int page;
    public string version;
}