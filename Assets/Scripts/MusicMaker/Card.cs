using PZObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MusicMaker
{
    public class Card : MonoBehaviour
    {
        public PlantType plantType;

        public void Init(PlantType plantType)
        {
            this.plantType = plantType;
            transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load("Sprites/Plant/" + plantType + "/" + plantType + "_01", typeof(Sprite)) as Sprite;
        }

        public void OnClick()
        {
            Debug.Log(transform.position);
            GameManager.Instance.PlantSelect = plantType;
        }
    } 
}
