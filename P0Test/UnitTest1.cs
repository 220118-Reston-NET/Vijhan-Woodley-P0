using Xunit;
using P0Model;

namespace P0Test;

public class NutrientTest
{
    [Fact]
    public void AgeSetData()
    {
        // Arrange
        Customer c = new Customer();
        int validage = 10;

        //Act
       c.Age = validage; 

       //Assert
       Assert.NotNull(c.Age);
       Assert.Equal(validage, c.Age);
        
    }
}