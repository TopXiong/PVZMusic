using PZObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace MusicMaker
{
    public class GameManager : MonoBehaviour
    {
        public GameObject itemList;
        public GameObject track;
        public GameObject point;
        public PZObject.PlantType PlantSelect;
        private static GameManager _instance;

        public GameObject VerScroll;
        public GameObject HerScroll;

        public GameObject InputPanel;

        public GameObject[,] pointMap;

        public Scrollbar HorScrollbar;

        public int MusicLength = 1;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    //则创建一个
                    _instance = GameObject.Find("Canvas").GetComponent<GameManager>();
                //返回这个实例
                return _instance;
            }
        }

        void Start()
        {
            pointMap = new GameObject[5,9];
            StartCoroutine(InitCard());
            InitPointMap();
            InitTrack();
            InitControl();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(HorScrollbar.value);
        }

        private void InitControl()
        {
            GameObject deep = Resources.Load("Prefabs/MusicMake/Ctrl", typeof(GameObject)) as GameObject;
            //GameObject light = Resources.Load("Prefabs/MusicMake/light", typeof(GameObject)) as GameObject;
            bool isDeep = true;
            for(int i = 0; i < MusicLength; i++, isDeep=!isDeep)
            {
                for(int j = 0; j < 5 * 9;j++)
                {
                    //GameObject ctrl = isDeep ? Instantiate(deep) : Instantiate(light);
                    GameObject ctrl = Instantiate(deep);
                    ctrl.GetComponent<Image>().color = isDeep ? DataValue.deep: DataValue.light;
                    ctrl.transform.SetParent(HerScroll.transform);
                    ctrl.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            HerScroll.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, MusicLength * track.GetComponent<RectTransform>().rect.size.x);
            HerScroll.transform.parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 5 * 9 * track.GetComponent<RectTransform>().rect.size.y);
        }

        private void InitTrack()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    GameObject newTrack = Instantiate(track);
                    newTrack.transform.SetParent(track.transform.parent);
                    newTrack.transform.localScale = new Vector3(1, 1, 1);
                    Debug.Log("point(" + i + "," + j + ")");
                }
            }
            VerScroll.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 5 * 9 * track.GetComponent<RectTransform>().rect.size.y);
            HerScroll.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 5 * 9 * track.GetComponent<RectTransform>().rect.size.y);
        }

        private IEnumerator InitCard()
        {
            var request = UnityWebRequest.Get(Application.streamingAssetsPath + "/MusicMakeCard.conf");
            yield return request.SendWebRequest();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(request.downloadHandler.text);
            XmlNode node = xmlDocument.SelectSingleNode("items");
            foreach(XmlNode xmlNode in node.ChildNodes)
            {
                GameObject card = Instantiate(Resources.Load("Prefabs/MusicMake/MusicMakeCard", typeof(GameObject)) as GameObject);
                card.GetComponent<Card>().Init((PZObject.PlantType)Enum.Parse(typeof(PZObject.PlantType), xmlNode.InnerText));
                card.transform.SetParent(itemList.transform);
                card.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void InitPointMap()
        {
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    GameObject newPoint = Instantiate(point);
                    newPoint.name = "point(" + i + "," + j + ")";
                    pointMap[i, j] = newPoint;
                    newPoint.transform.SetParent(point.transform.parent);
                    newPoint.transform.localScale = new Vector3(1, 1, 1);
                    newPoint.transform.position = point.transform.position + i * new Vector3(0, -0.85f, 0) + j * new Vector3(1.6f, 0, 0);
                    newPoint.transform.GetChild(0).GetComponent<Text>().text = i + "," + j;
                }
            }
            point.SetActive(false);
        }

    }

}