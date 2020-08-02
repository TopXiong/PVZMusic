using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MusicMaker
{
    public class Point : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private Image image;
        public PZObject.PlantType plantType;

        public void OnPointerClick(PointerEventData eventData)
        {
            if(GameManager.Instance.PlantSelect == PZObject.PlantType.Shovel)
            {
                plantType = PZObject.PlantType.NULL;
                image.sprite = null;
                Color color = image.color;
                color.a = 0f;
                image.color = color;
                return;
            }
            if (GameManager.Instance.PlantSelect != PZObject.PlantType.NULL && plantType == PZObject.PlantType.NULL)
            {
                image.sprite = Resources.Load("Sprites/Plant/" + GameManager.Instance.PlantSelect + "/" + GameManager.Instance.PlantSelect + "_01", typeof(Sprite)) as Sprite;
                Color color = image.color;
                color.a = 1f;
                image.color = color;
                plantType = GameManager.Instance.PlantSelect;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (GameManager.Instance.PlantSelect == PZObject.PlantType.Shovel)
            {
                return;
            }
            if (GameManager.Instance.PlantSelect != PZObject.PlantType.NULL && plantType == PZObject.PlantType.NULL)
            {
                image.sprite = Resources.Load("Sprites/Plant/" + GameManager.Instance.PlantSelect + "/" + GameManager.Instance.PlantSelect + "_01", typeof(Sprite)) as Sprite;
                Color color = image.color;
                color.a = 0.5f;
                image.color = color;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (GameManager.Instance.PlantSelect == PZObject.PlantType.Shovel)
            {
                return;
            }
            if (plantType == PZObject.PlantType.NULL)
            {
                image.sprite = null;
                Color color = image.color;
                color.a = 0f;
                image.color = color;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            image = GetComponent<Image>();
            plantType = PZObject.PlantType.NULL;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
