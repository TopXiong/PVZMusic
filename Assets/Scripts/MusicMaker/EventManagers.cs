using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MusicMaker
{
    public class EventManagers : MonoBehaviour
    {

        public Text text;
        private GameObject buttonSelect;

        public void TrackOnClick()
        {
            var buttonSelf = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            Debug.Log(buttonSelf.name);
            buttonSelect = buttonSelf;
            GameManager.Instance.InputPanel.SetActive(true);
        }

        public void InputButtonOnClick()
        {            
            try
            {
                int i = int.Parse(text.text.Split(',')[0]), j= int.Parse(text.text.Split(',')[1]);
                string name = buttonSelect.name.Split('_')[0];                
                name += "_" + i + "_" + j + "_" + GameManager.Instance.pointMap[i, j].GetComponent<Point>().plantType;
                buttonSelect.name = name;
                if(GameManager.Instance.pointMap[i, j].GetComponent<Image>().sprite!=null)
                {
                    buttonSelect.GetComponent<Image>().sprite = GameManager.Instance.pointMap[i, j].GetComponent<Image>().sprite;
                    buttonSelect.transform.GetChild(0).GetComponent<Text>().text = text.text;
                }
            }
            catch(Exception e)
            {
                text.text = "Input Error";
            }
            GameManager.Instance.InputPanel.SetActive(false);
        }

        public void OnHerScrollChange(float her)
        {
            Debug.Log(her);
        }
    }
}
