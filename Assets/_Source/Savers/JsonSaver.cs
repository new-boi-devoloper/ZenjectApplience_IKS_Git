using System;
using System.IO;
using _Source.Abstract;
using UnityEngine;

namespace _Source.Savers
{
    public class JsonSaver : ISaver
    {
        public void SaveScore(int score, string path = null)
        {
            var data = new ScoreData { Score = score };
            var json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }
    }

    [Serializable]
    public class ScoreData
    {
        public int Score;
    }
}