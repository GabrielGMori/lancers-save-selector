namespace LancersSaveSelector.Core.Tests.FileManager
{
	public class UnitTest1
	{
		[InlineData(true)]
		[InlineData(false)]
		[Theory]
		public void XShouldReturnTrue(bool x)
		{
			
			Assert.True(x);
		}
	}
}