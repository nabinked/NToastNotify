using Xunit;

namespace NToastNotify.Tests
{
    public class ToastNotificationTest
    {
        [Fact]
        public void MergeWith_ValidArguments_ReturnMergedObject()
        {
            //Arrange
            var obj1 = new ToastOption(){
                PositionClass = "primary"
            };
            var obj2 = new ToastOption(){ 
               CloseClass = "Close" 
             };
            //Act
            obj2.MergeWith(obj1);

            //Assert
        }
    }
}
