using Moq;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UmbValidationAttributes.Services;

namespace UmbValidationAttributes.Test.Helpers
{
    public static class DependencyResolverHelper
    {
        public static void SetValidationMessageServiceIntoResolver(Mock<IValidationMessageService> mockService)
        {
            // dependency resolver
            var mockResolver = new Mock<IDependencyResolver>();
            mockResolver.Setup(r => r.GetService(typeof(IValidationMessageService))).Returns(mockService.Object);

            DependencyResolver.SetResolver(mockResolver.Object);
        }
    }
}
