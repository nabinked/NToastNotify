using Xunit;

namespace NToastNotify.Tests
{
    public class ToastNotificationTest
    {
        [Fact]
        public void MergeWith_ValidArguments_ReturnMergedObject()
        {
            //Arrange
            var primaryObject = new { prop1 = "p1", prop2 = "p2", prop3 = "p3" };
            var secondaryObject = new { prop1 = "s1", prop3 = "s3" };
            //Act
            primaryObject.MergeWith<object>(secondaryObject);

            //Assert
            Assert.Same(secondaryObject.prop3, primaryObject.prop3);
        }
    }
}
