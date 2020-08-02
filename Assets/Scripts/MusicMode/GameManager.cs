using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PZObject;
using Tools;

namespace MusicMode
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public GameObject[,] plantsMap = new GameObject[5, 9];
        public GameObject[,] pointsMap = new GameObject[5, 9];
        public GameObject points;
        public GameObject plants;
        public int BPM = 240;
        public float timer;
        public Music music;
        private AudioClip[] clips;
        public delegate void BPMTimeHandle(int count);
        public event BPMTimeHandle BPMTimeEnd;
        private bool WaitDelay = true;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    //则创建一个
                    _instance = GameObject.Find("background").GetComponent<GameManager>();
                //返回这个实例
                return _instance;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            points = GameObject.FindGameObjectsWithTag("point")[0];
            plants = GameObject.Find("plants");
            Vector3 position = new Vector3(-3.97f, 1.62f, 0);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    GameObject point = Instantiate(Resources.Load("Prefabs/point", typeof(GameObject)) as GameObject);
                    point.name = "point(" + i + "," + j + ")";
                    pointsMap[i, j] = point;
                    point.transform.SetParent(points.transform);
                    point.transform.position = position + i * new Vector3(0, -1f, 0) + j * new Vector3(0.8f, 0, 0);
                    if (i == 0 && j == 0)
                    {
                        Debug.Log(point.transform.position);
                    }
                }
            }
            GameObject plant = Instantiate(Resources.Load("Prefabs/SunFlower", typeof(GameObject)) as GameObject);
            plant.name = "plant(" + 3 + "," + 3 + ")";
            plantsMap[3, 3] = plant;
            plant.transform.SetParent(plants.transform);
            plant.transform.position = pointsMap[3, 3].transform.position;
            plant.GetComponent<SunFlower>().point = new Vector2Int(3, 3);
            plant = Instantiate(Resources.Load("Prefabs/Marigold", typeof(GameObject)) as GameObject);
            plant.name = "plant(" + 2 + "," + 2 + ")";
            plantsMap[2, 2] = plant;
            plant.transform.SetParent(plants.transform);
            plant.transform.position = pointsMap[2, 2].transform.position;
            plant.GetComponent<Marigold>().point = new Vector2Int(2, 2);
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        GameObject plant = Instantiate(Resources.Load("Prefabs/SunFlower", typeof(GameObject)) as GameObject);
            //        plant.name = "plant(" + i + "," + j + ")";
            //        plantsMap[i, j] = plant;
            //        plant.transform.SetParent(plants.transform);
            //        plant.transform.position = pointsMap[i, j].transform.position;
            //        plant.GetComponent<SunFlower>().point = new Vector2Int(i, j);
            //    }
            //}
            SpriteAdapter.Instance.UpdateAll();
            BPMTimeEnd += ParseMusic;
            StartCoroutine(TimeUpdate());
            //GameObject sun = Instantiate(Resources.Load("Prefabs/Sun", typeof(GameObject)) as GameObject);
            //int line = 0;
            //sun.transform.position = pointsMap[line, Random.Range(0, 9)].transform.position;
            //sun.transform.localScale = SpriteAdapter.Instance.baseVector;
            //sun.GetComponent<Sun>().point = new Vector2Int(line, Random.Range(0, 9));
            music = Music.TestGetMusic();
        }
        public IEnumerator TimeUpdate()
        {
            if (WaitDelay)
            {
                timer = 1.6f;
                WaitDelay = false;
            }
            else
            {
                timer = 60.0f/ BPM / 4f;
            }
            int count = 0;
            while (true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 60.0f/ BPM  / 4f;

                    BPMTimeEnd.Invoke(count);
                    count++;

                    //column += Random.Range(-1, 2);
                    //column = column > 9 ? 3 : column;
                    //column = column < 0 ? 3 : column;
                    //plantsMap[line, column].GetComponent<SunFlower>().OnPlay();
                    //GameObject sun = Instantiate(Resources.Load("Prefabs/Sun", typeof(GameObject)) as GameObject);
                    //Debug.Log(line + "--" + column);
                    //sun.transform.position = pointsMap[line, column].transform.position;
                    //Debug.Log(pointsMap[line, column].transform.position);
                    //sun.transform.localScale = SpriteAdapter.Instance.baseVector;
                    //sun.GetComponent<Sun>().point = new Vector2Int(line, column);
                }
                yield return null;
            }
        }

        public void ParseMusic(int count)
        {
            foreach (Music.Track track in music.tracks)
            {
                if (count<track.taps.Count && track.taps[count] != 0)
                {
                    if(track.musical == PlantType.SunFlower)
                    {
                        plantsMap[3, 3].GetComponent<SunFlower>().tone = track.taps[count];
                        plantsMap[3, 3].GetComponent<SunFlower>().OnPlay();
                    }else if (track.musical == PlantType.Marigold)
                    {
                        plantsMap[2, 2].GetComponent<Marigold>().tone = track.taps[count];
                        plantsMap[2, 2].GetComponent<Marigold>().OnPlay();
                    }
                }
            }
        }
    }
}
