using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class EventSubscribe : MonoBehaviour
{
    [SerializeField] private string[] eventIDs;
    [SerializeField] private RhythmSpawner rhythmSpawnerComponent;
    [SerializeField] private BackgroundManager backgroundManager;


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

    void Start()
    {
        foreach (string events in eventIDs)
        {
            Koreographer.Instance.RegisterForEvents(events, FireEventDebugLog);
        }

    }

}