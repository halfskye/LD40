using UnityEngine;

public class SoundController : MonoBehaviour {

    public static AudioSource ReleasePresent;
    public static AudioSource Chimney;
    public static AudioSource PresentHouseHit;
    public static AudioSource SantaurThud;
    public static AudioSource Sparkle;
    public static AudioSource ElfAlert;
    public static AudioSource DeliveredPayload;
    public static AudioSource Jetpack;

    public float StartVolume = .2f;

	// Use this for initialization
	void Awake () {
      AudioSource[] audio = GetComponents<AudioSource>();

      ReleasePresent = audio[0];
      Chimney = audio[1];
      PresentHouseHit = audio[2];
      SantaurThud = audio[3];
      Sparkle = audio[4];
      ElfAlert = audio[5];
      DeliveredPayload = audio[6];
      Jetpack = audio[7];

      StartingVolume();
	}

  public void StartingVolume()
  {
      ReleasePresent.volume = StartVolume;
      Chimney.volume = StartVolume;
      PresentHouseHit.volume = StartVolume;
      SantaurThud.volume = StartVolume;
      Sparkle.volume = StartVolume;
      ElfAlert.volume = StartVolume;
      DeliveredPayload.volume = StartVolume;
      Jetpack.volume = StartVolume;
  }
}
