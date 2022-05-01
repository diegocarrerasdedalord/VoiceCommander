using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommands : MonoBehaviour
{
    private KeywordRecognizer keyWordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    Powers powers;
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("alakazam", SpawnAlly);
        actions.Add("drakaris", SpitFire);

        keyWordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keyWordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keyWordRecognizer.Start();

        powers = FindObjectOfType<Powers>();
       // keyWordRecognizer.Stop()//si queremos que se detenga

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    private void SpawnAlly() //podria hacer que sea un teleport a una zona cercana tambien tipo foreach torre cercana spawnear en la mas cercana
    {
        transform.Translate(1, 0, 0);
    }
    private void SpitFire()
    {
        powers.SpitFire();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
