using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MusicMaker
{
    public class Control : MonoBehaviour, IPointerClickHandler
    {
        Color Ocolor;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                GetComponent<Image>().color = Color.green;
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                GetComponent<Image>().color = Ocolor;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Ocolor = GetComponent<Image>().color;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
