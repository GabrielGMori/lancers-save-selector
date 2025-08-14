namespace LancersSaveSelector.Model
{
	internal class MainConfig
	{
		public bool SeenIntro {  get; set; }
		public bool Fullscreen { get; set; }
		public int BackgroundTrack {  get; set; }
		public bool MuteBackgroundMusic {  get; set; }
		public bool MuteSoundEffects {  get; set; }
		public string? SaveFilesDirectory {  get; set; }
		public string? MainGameDirectory {  get; set; }
		public bool LancerMode {  get; set; }
	}
}
