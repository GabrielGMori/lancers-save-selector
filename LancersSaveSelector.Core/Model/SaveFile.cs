namespace LancersSaveSelector.Core.Model
{
	public class SaveFile(string name, string creator, int chapter, string type = "", int? slot = null)
	{
		public string Name { get; set; } = name;
		public string Creator { get; set; } = creator;
		public int Chapter { get; set; } = chapter;
		public string Type {  get; set; } = type == "" ? "Default" : type;
		public int? Slot { get; set; } = slot;
	}
}
