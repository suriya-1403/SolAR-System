using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemInformationController : MonoBehaviour
{
    public LayerMask _itemLayer;
    public Transform _uiInformation;

    ItemData _itemData;

    public Image _thumbNail;
    public Text _title;
    public Text _content;
    private object yeild;

    // Start is called before the first frame update
    void Start()
    {
        _itemData = XMLSync.DeserializeFile<ItemData>(Application.streamingAssetsPath + "/Data.xml");

        //if(_itemData != null)
        //{
        //    foreach(Item item in _itemData.items)
        //    {
        //        Debug.Log(item.Information);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Transform clickingOnItem = GetClickingOnItem();
            ShowInformation(clickingOnItem);
        }
    }
    Transform GetClickingOnItem()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Transform clickingOnItem = null;
        if(Physics.Raycast(ray,out hit,50, _itemLayer))
        {
            clickingOnItem = hit.transform;
        }

        return clickingOnItem;
    }
    void ShowInformation(Transform item)
    {
        int selectedIndex = -1;
        if(item != null)
        {
            for (int i = 0; i < _itemData.items.Length; i++)
            {
                if (_itemData.items[i].id == item.name)
                {
                    selectedIndex = i;
                    break;
                }
            }
        }
        if (selectedIndex >= 0)
        {
            _title.text = _itemData.items[selectedIndex].name;
            _content.text = _itemData.items[selectedIndex].Information;
            //_thumbNail.sprite = new Sprite();
            StartCoroutine(LoadThumbnail(Application.streamingAssetsPath + "/" + _itemData.items[selectedIndex].photo_path));
            _uiInformation.gameObject.SetActive(true);
        }
        else
        {
            _uiInformation.gameObject.SetActive(false);
        }
        
    }

    IEnumerator LoadThumbnail(string thumbPath)
    {
        thumbPath = "file:///" + thumbPath.Replace(":/", "://");
        WWW www = new WWW(thumbPath);

        yield return www;
        Debug.Log(www.error);
        if (String.IsNullOrEmpty(www.error))
        {
            if(www.texture != null)
            {
                Texture2D tex = new Texture2D(4, 4, TextureFormat.ETC_RGB4, false);
                www.LoadImageIntoTexture(tex);
                www.Dispose();
                _thumbNail.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one / 2);
            }
        }


    }
}
