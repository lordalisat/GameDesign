 #pragma strict
 @script RequireComponent(AudioSource)
  
  public var soundClips:AudioClip[] = new AudioClip[6];
 
 private var musicNumber:int = 0;
 private var playNextMusic:boolean = true;
     
 // Play default sound
 function Update ()
 {
     if(!GetComponent.<AudioSource>().isPlaying) {
         if (playNextMusic) PlayTheNextMusic();
     }
 }
 
 function PlayTheNextMusic() {
     playNextMusic = false;
     GetComponent.<AudioSource>().clip = soundClips[musicNumber];
     GetComponent.<AudioSource>().Play();
     yield WaitForSeconds (GetComponent.<AudioSource>().clip.length);
     playNextMusic = true;
     ++musicNumber;
    if (musicNumber == soundClips.Length) musicNumber = 0; // I'm not sure if it is Length or length here...
 }