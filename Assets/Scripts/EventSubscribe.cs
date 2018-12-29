using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class EventSubscribe : MonoBehaviour {
    [SerializeField] private string eventID;
    [SerializeField] private RhythmSpawner rhythmSpawnerComponent;


    void FireEventDebugLog(KoreographyEvent koreoEvent)
    {
        rhythmSpawnerComponent.Spawn(koreoEvent.GetTextValue());
    }

    // Use this for initialization
    void Start ()
    {


        Koreographer.Instance.RegisterForEvents(eventID, FireEventDebugLog);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
