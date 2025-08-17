namespace LancersSaveSelector.Core.Model
{
	public class ActiveSaveFiles
	{
		public Dictionary<string, Dictionary<string, List<SaveFile?>>> FileDict { get; set; }

		public ActiveSaveFiles()
		{
			FileDict = new()
			{
				["Default"] = [],
				["Completion"] = []
			};

			foreach (string key in FileDict.Keys)
			{
				for (int i = 0; i<3; i++)
				{
					FileDict[key][$"Chapter{i}"] = [null, null, null];
				}
			}
		}
	}
}
