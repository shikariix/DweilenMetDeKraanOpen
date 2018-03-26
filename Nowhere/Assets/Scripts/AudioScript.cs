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
    public FMOD.Studio.EventInstance Music;
    public FMOD.Studio.ParameterInstance VolumeParameter;
    public FMOD.Studio.ParameterInstance EQParameter; // new
    public float VolumeValue;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        Debug.Log(instance.gameObject.name);
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        Music = FMODUnity.RuntimeManager.CreateInstance(SoundThingy);
        Music.getParameter("Volumes", out VolumeParameter);
        Music.getParameter("EQ", out EQParameter); // new
        Music.start();
    }
    
    void Update() {
        try {
            goo = GameObject.Find("Goo").GetComponent<Goo>();
            WaterValue = goo.level / 4;
        }
        catch (Exception e) {
            WaterValue = 1;
        }
        VolumeParameter.setValue(VolumeValue);
        FadeSpeed = 1f;
        if (WaterValue <= 1) {
            VolumeValue = Mathf.Lerp(VolumeValue, 1.3f, Time.deltaTime * FadeSpeed);
            
        } else if (WaterValue <= 2) {
            VolumeValue = Mathf.Lerp(VolumeValue, 2.3f, Time.deltaTime * FadeSpeed);

        } else if (WaterValue <= 3) {
            VolumeValue = Mathf.Lerp(VolumeValue, 3.3f, Time.deltaTime * FadeSpeed);

        } else if (WaterValue <= 4) {
            VolumeValue = Mathf.Lerp(VolumeValue, 4.3f, Time.deltaTime * FadeSpeed);

        } else {
            VolumeValue = Mathf.Lerp(VolumeValue, 5.3f, Time.deltaTime * FadeSpeed);

        }
        VolumeParameter.setValue(VolumeValue);
        EQParameter.setValue(VolumeValue); // new


    }


}