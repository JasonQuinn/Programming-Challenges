using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem102;

namespace Problem102Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TestMethod()
        {
            Assert.IsTrue(new Triangle(new Vector2(-340, 495), new Vector2(-153, -910), new Vector2(835, -947)).CointainsOrigin());
            Assert.IsFalse(new Triangle(new Vector2(-175, 41), new Vector2(-421, -714), new Vector2(574, -645)).CointainsOrigin());
        }
    }
}
