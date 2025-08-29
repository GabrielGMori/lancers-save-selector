namespace LancersSaveSelector.Core.Tests.FileManagerTests
{
	internal class SaveFileManagerTests : IDisposable
	{
		private readonly string _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());



		public void Dispose()
		{
			if (Directory.Exists(_tempDir))
				Directory.Delete(_tempDir, true);
			GC.SuppressFinalize(this);
		}
	}
}
