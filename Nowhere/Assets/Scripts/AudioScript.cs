using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioScript : MonoBehaviour {

    public float WaterValue;
    private float FadeSpeed;
    public Goo goo;

    public static AudioScript instance = null;

    [FMODUnity.EventRef]
    public string SoundThingy = "event:/Music" ;
    public string OthersoundThingy = "event:/Water"; //Latest for Water
    public FMOD.Studio.EventInstance Music;
    public FMOD.Studio.EventInstance Goop; //Latest for Water
    public FMOD.Studio.ParameterInstance VolumeParameter;
    public FMOD.Studio.ParameterInstance EQParameter; // new
    public FMOD.Studio.ParameterInstance WaterParameter; //Latest for Water
    public float VolumeValue;
    public float WaterRush; //Latest for Water

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        Music = FMODUnity.RuntimeManager.CreateInstance(SoundThingy);
        Goop = FMODUnity.RuntimeManager.CreateInstance(OthersoundThingy);
        Music.getParameter("Volumes", out VolumeParameter);
        Music.getParameter("EQ", out EQParameter); // new
        Goop.getParameter("Dirtywater", out WaterParameter); //Latest for Water
        Music.start();
        Goop.start(); //Latest for Water
    }
    
    void Update() {
        try {
            goo = GameObject.Find("Goo").GetComponent<Goo>();
            WaterValue = goo.level / 4;
        }
        catch (Exception e) {
            WaterValue = 0;
        }
        VolumeParameter.setValue(VolumeValue);
        FadeSpeed = 1f; if (WaterValue <= 0) {
            VolumeValue = Mathf.Lerp(VolumeValue, 0.3f, Time.deltaTime * FadeSpeed);
            WaterRush = Mathf.Lerp(WaterRush, 0f, Time.deltaTime * FadeSpeed); //Latest for Water
        } else if (WaterValue <= 1) {
            VolumeValue = Mathf.Lerp(VolumeValue, 0.3f, Time.deltaTime * FadeSpeed);
            WaterRush = Mathf.Lerp(WaterRush, 0.12f, Time.deltaTime * FadeSpeed); //Latest for Water
        }
        else if (WaterValue <= 2) {
            VolumeValue = Mathf.Lerp(VolumeValue, 1.3f, Time.deltaTime * FadeSpeed);
            WaterRush = Mathf.Lerp(WaterRush, 0.46f, Time.deltaTime * FadeSpeed); //Latest for Water
        }
        else if (WaterValue <= 3) {
            VolumeValue = Mathf.Lerp(VolumeValue, 2.3f, Time.deltaTime * FadeSpeed);
            WaterRush = Mathf.Lerp(WaterRush, 0.76f, Time.deltaTime * FadeSpeed); //Latest for Water
        }
        else if (WaterValue <= 4) {
            VolumeValue = Mathf.Lerp(VolumeValue, 4.3f, Time.deltaTime * FadeSpeed);
            WaterRush = Mathf.Lerp(WaterRush, 0.76f, Time.deltaTime * FadeSpeed); //Latest for Water
        }
        else if (WaterValue <= 5) {
            VolumeValue = Mathf.Lerp(VolumeValue, 5.3f, Time.deltaTime * FadeSpeed);
            WaterRush = Mathf.Lerp(WaterRush, 0.81f, Time.deltaTime * FadeSpeed); //Latest for Water
        }
        else if (WaterValue <= 6) {
            VolumeValue = Mathf.Lerp(VolumeValue, 6.3f, Time.deltaTime * FadeSpeed);
            WaterRush = Mathf.Lerp(WaterRush, 1.1f, Time.deltaTime * FadeSpeed); //Latest for Water
            Debug.Log("six");
        }
        else {
            VolumeValue = Mathf.Lerp(VolumeValue, 6.3f, Time.deltaTime * FadeSpeed);

        }
        VolumeParameter.setValue(VolumeValue);
        EQParameter.setValue(VolumeValue); // new
        WaterParameter.setValue(WaterRush); //Latest for Water

    }

}