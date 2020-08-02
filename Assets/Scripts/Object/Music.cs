using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PZObject
{
    public class Music
    {
        public struct Track
        {
            public PlantType musical;
            public List<int> taps;

            public Track(PlantType musical)
            {
                this.musical = musical;
                taps = new List<int>();
            }
        }

        public List<Track> tracks;

        private Music()
        {
            tracks = new List<Track>();
        }

        public static Music TestGetMusic()
        {
            Music music = new Music();
            Track SunFlowerTrack = new Track();
            SunFlowerTrack.musical = PlantType.SunFlower;
            int[] FlowerDance = new int[] 
            {3,2,6,2,3,2, -6,2,
            3,2,6,2,3,2,-6,2,
            3,2,6,2,3,2,-6,2,
            3,2,6,2,3,2,-6,2,
            3,2,6,2,3,2,-6,2,
            3,2,6,2,3,2,-6,2,
            3,2,6,2,3,2,-6,2,
            6};
            SunFlowerTrack.taps = new List<int>(FlowerDance);
            music.tracks.Add(SunFlowerTrack);

            Track MarigoldTrack = new Track();
            MarigoldTrack.musical = PlantType.Marigold;
            int[] MarigoldFlowerDance = new int[]
            {-4,1,4,5,6,0,0,0,
            -5,2,5,6,7,0,0,0,
            -6,3,5,6,7,0,0,0,
            -6,3,6,7,1+7,7,6,3,
            -4,1,4,5,6,0,0,0,
            -5,2,5,6,7,0,0,0,
            -6,3,6,7,1+7,7,6,3,
            -6};
            MarigoldTrack.taps = new List<int>(MarigoldFlowerDance);
            music.tracks.Add(MarigoldTrack);
            return music;
        }

    }
}