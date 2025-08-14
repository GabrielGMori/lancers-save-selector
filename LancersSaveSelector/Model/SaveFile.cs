namespace LancersSaveSelector.Model
{
	internal class SaveFile(string name, int chapter, int slot, string type = "")
	{
		private string Name { get; set; } = name;
		private int Chapter { get; set; } = chapter;
		private int Slot { get; set; } = slot;
		private string Type {  get; set; } = type == "" ? "Default" : type; 
	}
}
