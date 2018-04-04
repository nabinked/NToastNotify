using NToastNotify.Helpers;
using Xunit;

namespace NToastNotify.Tests
{
    public class ToastNotificationTest
    {
        [Fact]
        public void MergeWith_ValidArguments_ReturnMergedObject()
        {
            //Arrange
            var obj1 = new ToastrOptions(){
                PositionClass = "primary",
                Title = "title1"
            };
            var obj2 = new ToastrOptions(){ 
               CloseClass = "Close",
               Title = "title2",
               
             };
            //Act
            obj1.MergeWith(obj2);

            //Assert
            Assert.Equal(obj1.CloseClass, obj2.CloseClass);
            Assert.Equal(obj1.Title, obj1.Title);
        }
    }
}
