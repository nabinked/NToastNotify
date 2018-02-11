using Xunit;

namespace NToastNotify.Tests
{
    public class ToastNotificationTest
    {
        [Fact]
        public void MergeWith_ValidArguments_ReturnMergedObject()
        {
            //Arrange
            var obj1 = new Option(){
                PositionClass = "primary"
            };
            var obj2 = new Option(){ 
               CloseClass = "Close" 
             };
            //Act
            obj2.MergeWith(obj1);

            //Assert
        }
    }
}
