using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace sapra.silvercoin_project
{
    public class LevelManager : MonoBehaviour
    {
        public TextMeshProUGUI rocksText;
        public TextMeshProUGUI timeText;
        public List<Health> importantRocks;
        private int remainingRocks;
        private float currentTime;
        // Start is called before the first frame update
        void Start()
        {
            remainingRocks = importantRocks.Count;
            rocksText.SetText(importantRocks.Count + "/" + remainingRocks);
            foreach(Health ROCK in importantRocks)
            {
                ROCK.onDestroy += UpdateDestroyed;
            }
        }
        void Update()
        {
            currentTime += Time.deltaTime;
            timeText.SetText((Mathf.Floor(currentTime*100)/100).ToString());
        }
        void UpdateDestroyed()
        {
            remainingRocks -= 1;
            rocksText.SetText(importantRocks.Count + "/" + remainingRocks);
            if(remainingRocks <= 0)
                LevelComplete();
        }
        void LevelComplete()
        {
            if(MenuManager.instance != null)
            {
                MenuManager.instance.OnComplete(currentTime);
            }
        }
    }
}