using UnityEngine;

public class SoundController : MonoBehaviour {

    public static AudioSource ReleasePresent;
    public static AudioSource Chimney;
    public static AudioSource PresentHouseHit;
    public static AudioSource SantaurThud;

    public float StartVolume = .2f;

	// Use this for initialization
	void Awake () {
        AudioSource[] audio = GetComponents<AudioSource>();

        ReleasePresent = audio[0];
        Chimney = audio[1];
        PresentHouseHit = audio[2];
        SantaurThud = audio[3];

        StartingVolume();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartingVolume()
    {
        ReleasePresent.volume = StartVolume;
        Chimney.volume = StartVolume;
        PresentHouseHit.volume = StartVolume;
        SantaurThud.volume = StartVolume;
    }

}
