using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
public class InfoUser : MonoBehaviour
{
    public string urlPicBig;
    public string urlpicThumb;
    public string Name;
    public string Age;
    public string City;
    public string Mail;
    public string Gender;
    public int likes;
    public TMP_Text username;

    [SerializeField] Image thumb;
    [SerializeField] GameObject loading;
    [SerializeField]Sprite BigPic;

    void Start()
    {
        
    }

    private void OnEnable()
    {

        StartCoroutine(DownloadPics());
    }

    IEnumerator DownloadPics() {

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(urlpicThumb);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            thumb.sprite = sprite;
        }
        else
        {
            Debug.LogError(request.error);
        }

    }
    IEnumerator DownloadBigpics()
    {

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(urlpicThumb);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
           BigPic = sprite;
            loading.SetActive(false);
            sendtomodal();
        }
        else
        {
            Debug.LogError(request.error);
        }

    }

    [ContextMenu("DonwBp")]
    public void downloadbigpic() {
        loading.SetActive(true);
        StartCoroutine(DownloadBigpics());

    }

    public void sendtomodal() {

        ModalUser modal = GameObject.FindGameObjectWithTag("Modalwin").GetComponent<ModalUser>();
        modal.BigPic.sprite = BigPic;
        modal.Name.text = Name;
        modal.Gender.text = Gender;
        modal.Age.text = Age;
        modal.City.text = City;
        modal.Mail.text = Mail;
        modal.popUp();
    }
}
