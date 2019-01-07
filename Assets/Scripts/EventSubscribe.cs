using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using SonicBloom.Koreo.Players;

public class EventSubscribe : MonoBehaviour
{
    [SerializeField] private string[] eventIDs;
    [SerializeField] private RhythmSpawner rhythmSpawnerComponent;
    [SerializeField] private BackgroundManager backgroundManager;
    [SerializeField] private SimpleMusicPlayer player;

    void FireEventDebugLog(KoreographyEvent koreoEvent)
    {
        if (koreoEvent.GetTextValue() == "CB")
        {
            backgroundManager.NextBackground();
        }
        else
        {
            rhythmSpawnerComponent.Spawn(koreoEvent.GetTextValue());
        }
    }

    private void Update() {
        if (Time.timeScale ==0) {
            player.Pause();
        }
        else if(!player.IsPlaying && Time.timeScale == 1) {
            player.Play();
        }

    }

    void Start()
    {
        foreach (string events in eventIDs)
        {
            Koreographer.Instance.RegisterForEvents(events, FireEventDebugLog);
        }

    }

}