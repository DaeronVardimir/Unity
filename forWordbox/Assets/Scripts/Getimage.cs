using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Getimage : MonoBehaviour
{
    public string url;
    public string filename;

    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            byte[] bytes = texture.EncodeToPNG();

            string path = Application.persistentDataPath + "/" + filename;
            System.IO.File.WriteAllBytes(path, bytes);
        }
        else
        {
            Debug.LogError(request.error);
        }
    }
}
