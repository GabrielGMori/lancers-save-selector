namespace LancersSaveSelector.Core.Model
{
	public class MainConfig(
			bool seenIntro = false,
			bool fullscreen = false,
			int backgroundTrack = 0,
			bool muteBackgroundMusic = false,
			bool muteSoundEffects = false,
			string? saveFilesDirectory = null,
			string? mainGameDirectory = null,
			bool lancerMode = false
		)
	{
		public bool SeenIntro { get; set; } = seenIntro;
		public bool Fullscreen { get; set; } = fullscreen;
		public int BackgroundTrack { get; set; } = backgroundTrack;
		public bool MuteBackgroundMusic { get; set; } = muteBackgroundMusic;
		public bool MuteSoundEffects { get; set; } = muteSoundEffects;
		public string? SaveFilesDirectory { get; set; } = saveFilesDirectory;
		public string? MainGameDirectory { get; set; } = mainGameDirectory;
		public bool LancerMode { get; set; } = lancerMode;
	}
}
