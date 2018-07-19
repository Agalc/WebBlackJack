using System.Collections.Generic;
using System.Web.Mvc;
using BlackJack.Controllers;
using BlackJack.Core.Enteties;
using BlackJack.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlackJack.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void IndexViewModelNotNull()
    {
      // Arrange
      var mock = new Mock<IUnitOfWork>();
      mock.Setup(a => a.Users.GetAll()).Returns(new List<User>());
      HomeController controller = new HomeController(mock.Object);

      // Act
      ViewResult result = controller.Index() as ViewResult;

      // Assert
      Assert.IsNotNull(result.Model);
    }
  }
}
