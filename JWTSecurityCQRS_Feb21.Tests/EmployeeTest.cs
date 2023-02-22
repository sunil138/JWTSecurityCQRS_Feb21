using JWTSecurityCQRS_Feb21.Controllers;
using JWTSecurityCQRS_Feb21.DataAccess;
using MediatR;
using Moq;

namespace JWTSecurityCQRS_Feb21.Tests
{
    public class EmployeeTest
    {
       public Mock<IEmployee>mock=new Mock<IEmployee>();
        private readonly IMediator _mediator;
        public EmployeeTest(Mock<IEmployee> mock, IMediator mediator) 
        {
            this.mock = mock;
            _mediator = mediator;
        } 

        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public void GetMovieNameById()
        {
            //arrange
            mock.Setup(p => p.GetEmployeeNameById(1)).Returns("Lokesh");
            AdminController adminController = new AdminController((IMediator)mock.Object);

            //act
            var result = adminController.GetEmployeeNameById(1);

            //assert
            Assert.Equal((IEnumerable<char>)result, "Lokesh");    

        }
    }
}