namespace LancersSaveSelector.Model
{
	internal class SaveSlotNameList
	{
		public string? Slot0 { get; set; }
		public string? Slot1 { get; set; }
		public string? Slot2 { get; set; }
	}

	internal class ChapterList
	{
		public required SaveSlotNameList Chapter1 { get; set; }
		public required SaveSlotNameList Chapter2 { get; set; }
		public required SaveSlotNameList Chapter3 { get; set; }
		public required SaveSlotNameList Chapter4 { get; set; }
	}

	internal class ActiveSaveFileList
	{
		public required ChapterList Default { get; set; }
		public required ChapterList Completion { get; set; }
	}
}
